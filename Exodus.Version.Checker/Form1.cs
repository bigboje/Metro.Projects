using Exodus.Version.Checker.Compare.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exodus.Version.Checker
{
    public partial class Form1 : Form
    {
        public static Comparer Compare = new Comparer();

        public Form1()
        {
            InitializeComponent();
        }

        private void compareVersion_Click(object sender, EventArgs e)
        {
            if(Compare.IsInitialized)
                Compare.Run();
            else
            {
                Compare.Initialize();
                if (Compare.IsInitialized)
                    compareVersion.Text = "Compare Version";
                else
                    compareVersion.Text = "Initialize Comparer";
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Compare.OnAction += Compare_OnAction;
            Compare.OnProgressChanged += Compare_OnProgressChanged;
            Compare.OnCompareBegin += Compare_OnCompareBegin;
            Compare.OnCompareComplete += Compare_OnCompareComplete;
        }

        private void Compare_OnCompareComplete()
        {
            InvokeControl(saveToFileCheck, (MethodInvoker)delegate {

                if (saveToFileCheck.Checked)
                {
                    SaveFileDialog SFD = new SaveFileDialog() { Filter = "JSON File|*.json" };
                    if (SFD.ShowDialog() == DialogResult.OK)
                    {
                        File.Create(SFD.FileName).Close();
                        File.WriteAllText(SFD.FileName, GameFile.SerializeArray(Compare.Files));
                    }
                }
            });
            InvokeControl(compareVersion, (MethodInvoker)delegate { compareVersion.Enabled = true; });
            InvokeControl(saveToFileCheck, (MethodInvoker)delegate { saveToFileCheck.Enabled = true; });
        }

        private void Compare_OnCompareBegin()
        {
            InvokeControl(compareVersion, (MethodInvoker)delegate { compareVersion.Enabled = false; });
            InvokeControl(saveToFileCheck, (MethodInvoker)delegate { saveToFileCheck.Enabled = false; });
        }

        private void Compare_OnProgressChanged(float obj)
        {
            InvokeControl(progressBar, (MethodInvoker)delegate { progressBar.Value = (int)Math.Round(obj); });
        }

        private void Compare_OnAction(string obj)
        {
            InvokeControl(progressText, (MethodInvoker)delegate { progressText.Text = obj; });
        }

        private void InvokeControl(Control C, Delegate D)
        {
            try
            {
                C.Invoke(D);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
