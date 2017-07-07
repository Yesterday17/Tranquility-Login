using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tranquility_Login.Utils;

namespace Tranquility_Login
{
    class Constants
    {
        public static Repository repo;
        public static String git_repository = "https://git.coding.net/yesterday17/TestMinecraft.git";
        public static String self_name = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
        public static String self_path = System.Windows.Forms.Application.StartupPath;
        public static String self = self_path + "\\" + self_name + ".exe";

        public static string path
        {
            get
            {
                return multimc_path;
            }
        }

        private static string multimc_path = self_path + "\\minecraft\\";
        public static string multimc_config_path = self_path + "\\instance.cfg";

        public static readonly DateTime StartTime = DateTime.Now;

        public static Branch latest
        {
            get
            {
                if (MethodUtils.reppo != null)
                    return MethodUtils.reppo.Branches["latest"];
                else
                    return repo.Branches["latest"];
            }
            set
            {
                //repo.Branches["latest"] = value;
            }
        }
        public static Branch master
        {
            get
            {
                if (MethodUtils.reppo != null)
                    return MethodUtils.reppo.Branches["master"];
                else
                    return repo.Branches["master"];
            }
            set
            {
                //repo.Branches["latest"] = value;
            }
        }
        public static Branch origin_latest
        {
            get
            {
                if (MethodUtils.reppo != null)
                    return MethodUtils.reppo.Branches["origin/latest"];
                else
                    return repo.Branches["origin/latest"];
            }
            set
            {
                //repo.Branches["latest"] = value;
            }
        }
        public static Branch origin_master
        {
            get
            {
                if (MethodUtils.reppo != null)
                    return MethodUtils.reppo.Branches["origin/master"];
                else
                    return repo.Branches["origin/master"];
            }
            set
            {
                //repo.Branches["latest"] = value;
            }
        }

        /// <summary>
        /// 通过命令行判别的程序运行模式
        /// </summary>
        public enum LoadState
        {
            startup = 1,
            exit = 2,

            init = 3,
            update = 4,
            multimc = 5,

            track = 8,
            startupTrack = 9,

            daemon = 10,
        };

        public static Signature sign = new Signature(
            "tan90",                   //Username
            "tan90@yesterday17.cn",    //E-mail
            new DateTimeOffset()
        );

        public static CredentialsHandler credentials = (_url, _user, _cred) =>
        {
            return new UsernamePasswordCredentials
            {
                Username = "yesterday17",
                Password = "001206"
            };
        };

    }
}
