using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exodus.Version.Checker.Compare.Objects
{
    public class Comparer
    {
        private const string VersionInfo = "https://raw.githubusercontent.com/bigboje/Files/master/update0.json";

        public GameInfo Info { get; private set; }
        public GameFile[] Files { get { return pFiles.ToArray(); } }

        public float Progress
        {
            get { return pprogress; }
            private set
            {
                pprogress = value;
                OnProgressChanged?.BeginInvoke(value, OnProgressChanged.EndInvoke, null);
            }
        }

        public int Count { get; private set; }
        public int Compared
        {
            get { return pcompared; }
            private set
            {
                pcompared = value;
                if(Count > 0)
                    Progress = (100f / (float)Count) * (float)value;
            }
        }

        public bool IsRunning { get; private set; } = false;
        public bool IsInitialized { get; private set; } = false;

        public void Initialize()
        {
            if (IsInitialized)
                return;

            if(FileSelection.ShowDialog() == DialogResult.OK)
            {
                Info = new GameInfo(FileSelection.FileName);
                IsInitialized = true;
                CallAction("Action: Successfully Initialized Comparer.");
            }
            else
                CallAction("Action: Comparer Initialization Failed.");
        }

        public Comparer()
        {

        }

        public void Run()
        {
            if (IsInitialized && !IsRunning)
            {
                IsRunning = true;
                CompareAsync?.BeginInvoke(this, CompareAsync.EndInvoke, null);
            }
            else if (!IsInitialized)
                Initialize();
        }

        public event Action OnCompareBegin;
        public event Action OnCompareComplete;
        public event Action<string> OnAction;
        public event Action<float> OnProgressChanged;

        private Action<Comparer> CompareAsync = (sender) =>
        {
            using (WebClient web = new WebClient())
            {
                web.Headers[HttpRequestHeader.ContentType] = "application/json";
                sender.CallBegin();

                var Files = sender.Info.GetFiles();

                GameFile[] OnlineData = null;

                sender.CallAction($"Downloading 1.0.0.0 info...");
                try
                {
                    OnlineData = GameFile.DeserializeArray(web.DownloadString(VersionInfo));
                }
                catch (Exception e)
                {
                    sender.CallAction("an error occured during the download of the 1.0.0.0 info.");
                    MessageBox.Show(e.Message);
                    return;
                }


                sender.Compared = 0;
                sender.Count = Files.Length;
                sender.pFiles = new List<GameFile>();

                for (int i = 0; i < Files.Length; i++)
                {
                    GameFile OnlineGameFile = OnlineData.Where((x) => (Files[i].Name == x.Name)).FirstOrDefault();

                    if (OnlineGameFile == null || OnlineGameFile == default(GameFile))
                    {
                        sender.Compared = i + 1;
                        continue;
                    }

                    sender.CallAction($"Comparing file: {Files[i].Name} to 1.0.0.0 [Done: {i} of {Files.Length}]");

                    var CurrentGameFile = new GameFile(Files[i].FullName);

                    if (OnlineGameFile.MD5 != CurrentGameFile.MD5)
                        CurrentGameFile.IsSame = false;

                    sender.pFiles.Add(CurrentGameFile);
                    sender.Compared = i + 1;
                }
            }

            sender.CallEnd();
        };

        private void CallEnd()
        {
            OnCompareComplete?.BeginInvoke(OnCompareComplete.EndInvoke, null);
            IsRunning = false;
            CallAction("Action: Comparison Finished.");
        }

        private void CallBegin()
        {
            IsRunning = true;
            OnCompareBegin?.BeginInvoke(OnCompareBegin.EndInvoke, null);
            CallAction("Action: Beinning Comparison...");
        }

        private void CallAction(string Action)
        {
            OnAction?.BeginInvoke(Action, OnAction.EndInvoke, null);
        }
        
        private OpenFileDialog FileSelection = new OpenFileDialog() { Filter = "Metro Exodus Executable|MetroExodus.exe" };
        private List<GameFile> pFiles;
        private float pprogress;
        private int pcompared;
    }
}
