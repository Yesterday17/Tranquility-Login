using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tranquility_Login
{
    public partial class Main : Form
    {
        public static String git_address = @"C:\Program Files\Git\bin\git.exe";
        public static String git_repository = "https://git.coding.net/yesterday17/TestMinecraft.git";
        private Boolean exit = false;
        private Boolean init = true;

        public Main()
        {
            InitializeComponent();
        }

        public Main(String arg)
        {
            init = false;
            if(arg == "login")
            {
                //
            }
            else if(arg == "exit")
            {
                exit = true;
            }
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(init == true)
            {
                MessageBox.Show(exec("clone -b master " + git_repository + " . --depth=1"));
                MessageBox.Show(exec("fetch " + git_repository + " latest --depth=1"));
            }
            else
            {
                if (exit == true)
                {
                    //MessageBox.Show(exec("checkout ."));
                    MessageBox.Show(exec("checkout master"));
                }
                else
                {
                    MessageBox.Show(exec("checkout ."));
                    MessageBox.Show(exec("checkout latest"));
                }
            }
            
            System.Environment.Exit(0);
        }

        private Process git(String argu)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = git_address;
            proc.StartInfo.WorkingDirectory = Application.StartupPath + "/minecraft/";
            proc.StartInfo.Arguments = argu;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;

            return proc;
        }

        private String exec(Process p)
        {
            p.Start();
            p.WaitForExit();
            return p.StandardOutput.ReadToEnd();
        }

        private String exec(String argu)
        {
            return exec(git(argu));
        }
    }
}
