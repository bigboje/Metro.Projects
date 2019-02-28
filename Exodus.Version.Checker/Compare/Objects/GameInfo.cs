using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Exodus.Version.Checker.Compare.Objects
{
    public class GameInfo
    {
        public string GameFolder { get; private set; }
        public string GameExecutable { get; private set; }
        public string GameVersion { get; private set; }

        public DirectoryInfo DirectoryInfo { get; private set; }

        public GameInfo(string MetroExodus)
        {
            GameFolder = Path.GetDirectoryName(MetroExodus);
            GameExecutable = MetroExodus;
            GameVersion = FileVersionInfo.GetVersionInfo(MetroExodus).FileVersion;

            DirectoryInfo = new DirectoryInfo(GameFolder);
        }

        public FileInfo[] GetFiles()
        {
            return DirectoryInfo.GetFiles().Where(x => (!x.Name.EndsWith(".mp3") && !x.Name.EndsWith(".webm") && !x.Name.EndsWith(".ini") && !x.Name.EndsWith(".json") && !x.Name.EndsWith("steam_api64.dll") && !x.Name.EndsWith("steamclient64.dll"))).ToArray();
        }
    }
}
