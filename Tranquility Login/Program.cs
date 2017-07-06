using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tranquility_Login.Utils;

namespace Tranquility_Login
{
    class MainJudge
    {
        private Constants.LoadState state;
        private DownloadForm frm_download;

        public MainJudge(String arg)
        {
            switch (arg)
            {
                case "startup":
                case "login":
                    state = Constants.LoadState.startup;
                    break;

                case "exit":
                    state = Constants.LoadState.exit;
                    break;

                case "init":
                    state = Constants.LoadState.init;
                    break;

                case "update":
                case "upgrade":
                    state = Constants.LoadState.update;
                    break;

                case "multimc":
                    state = Constants.LoadState.multimc;
                    break;

                default:
                    state = Constants.LoadState.init;
                    break;
            }
        }

        public MainJudge()
        {
            state = Constants.LoadState.init;
        }

        public void Load()
        {
            Boolean valid = Constants.mcRepositoryIsValid(Constants.path);

            if (valid)
            {
                Constants.repo = new Repository(Constants.path);
                switch (state)
                {
                    case Constants.LoadState.startup:
                        MethodUtils.CheckoutLatest();
                        Application.Run(new DownloadForm("更新"));
                        break;

                    case Constants.LoadState.exit:
                        MethodUtils.CheckoutMaster();
                        break;

                    case Constants.LoadState.init:
                        MessageBox.Show("工作目录已正常配置！请使用MultiMC启动！");
                        System.Environment.Exit(0);
                        break;

                    case Constants.LoadState.update:
                        frm_download = new DownloadForm("更新");
                        frm_download.Show();
                        break;

                    case Constants.LoadState.multimc:
                        MethodUtils.MultiMCConfigure();
                        break;
                }
            }
            else
            {
                Application.Run(new DownloadForm("下载"));
            }
        }
    }

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            MainJudge main;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 1)
                main = new MainJudge(args[0]);
            else
                main = new MainJudge();

            main.Load();
        }

    }
}
