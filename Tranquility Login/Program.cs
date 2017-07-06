using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tranquility_Login
{
    class MainJudge
    {
        public Repository repo;
        public Branch latest = null;
        public Branch master = null;
        public Branch origin_latest = null;
        public Branch origin_master = null;

        public static string path = Application.StartupPath + "/minecraft/";

        public enum LoadState
        {
            startup = 1,
            exit = 2,

            init = 3,
            update = 4
        };
        private LoadState state;

        public MainJudge(String arg)
        {
            switch (arg)
            {
                case "startup":
                case "login":
                    state = LoadState.startup;
                    break;

                case "exit":
                    state = LoadState.exit;
                    break;

                case "init":
                    state = LoadState.startup;
                    break;

                case "update":
                case "upgrade":
                    state = LoadState.update;
                    break;

                default:
                    state = LoadState.init;
                    break;
            }
        }

        public MainJudge()
        {
            state = LoadState.init;
        }

        public Boolean mcRepositoryIsValid(String path)
        {
            if (!Repository.IsValid(path))
                return false;

            using (var repo = new Repository(path))
            {
                foreach (Branch b in repo.Branches)
                {
                    switch (b.FriendlyName)
                    {
                        case "latest":
                            this.latest = b;
                            break;

                        case "master":
                            this.master = b;
                            break;

                        case "origin/latest":
                            this.origin_latest = b;
                            break;

                        case "origin/master":
                            this.origin_master = b;
                            break;
                    }
                    MessageBox.Show(b.FriendlyName);
                }
            }

            if (this.origin_latest == null || this.origin_master == null)
                return false;

            return true;
        }

        public void Load()
        {
            Boolean valid = mcRepositoryIsValid(path);

            if (valid)
            {
                switch (state)
                {
                    case LoadState.startup:
                        repo = new Repository(path);
                        //$ git checkout .
                        Commands.Checkout(repo, master);
                        //$ git checkout latest
                        Commands.Checkout(repo, latest);
                        break;

                    case LoadState.exit:
                        repo = new Repository(path);
                        //$ git checkout .
                        Commands.Checkout(repo, latest);
                        //$ git checkout master
                        Commands.Checkout(repo, master);
                        break;

                    case LoadState.init:
                        MessageBox.Show("工作目录已正常配置！请使用MultiMC启动！");
                        System.Environment.Exit(0);
                        break;

                    case LoadState.update:
                        //
                        break;
                }
            }
            else
            {
                Application.Run(new DownloadForm("客户端下载中……"));
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

            MessageBox.Show(args.Length.ToString());

            if (args.Length == 1)
                main = new MainJudge(args[0]);
            else
                main = new MainJudge();

            main.Load();
            MessageBox.Show("exit");
        }
        
    }
}
