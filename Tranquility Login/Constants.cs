using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tranquility_Login
{
    class Constants
    {
        public static Repository repo;
        private static Repository reppo = null;

        public static Branch latest
        {
            get
            {
                if (reppo != null)
                    return reppo.Branches["latest"];
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
                if (reppo != null)
                    return reppo.Branches["master"];
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
                if (reppo != null)
                    return reppo.Branches["origin/latest"];
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
                if (reppo != null)
                    return reppo.Branches["origin/master"];
                else
                    return repo.Branches["origin/master"];
            }
            set
            {
                //repo.Branches["latest"] = value;
            }
        }



        public static string path = System.Windows.Forms.Application.StartupPath + "/minecraft/";

        public static string multimc_path = System.Windows.Forms.Application.StartupPath + "/minecraft/";
        public static string multimc_config_path = System.Windows.Forms.Application.StartupPath + "/instance.cfg";

        /// <summary>
        /// 通过命令行判别的程序运行模式
        /// </summary>
        public enum LoadState
        {
            startup = 1,
            exit = 2,

            init = 3,
            update = 4,
            multimc = 5
        };

        public static String git_repository = "https://git.coding.net/yesterday17/TestMinecraft.git";

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

        /// <summary>
        /// 判断一Minecraft仓库是否合法
        /// </summary>
        /// <param name="path">仓库地址</param>
        /// <returns>是否合法</returns>
        public static Boolean mcRepositoryIsValid(String path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return false;
            }

            if (!Repository.IsValid(path))
                return false;


            using (reppo = new Repository(path))
            {
                if (Constants.origin_latest == null || Constants.origin_master == null)
                    return false;

                if (Constants.latest == null)
                {
                    Constants.latest = branchTrack(reppo, Constants.origin_latest, "latest");
                }
                reppo = null;
            }
            return true;
        }

        /// <summary>
        /// 判断一Minecraft仓库是否合法
        /// </summary>
        /// <returns></returns>
        public static Boolean mcRepositoryIsValid()
        {
            return mcRepositoryIsValid(path);
        }

        /// <summary>
        /// 新建特定分支与远端分支建立Track
        /// </summary>
        /// <param name="repo">代码仓库</param>
        /// <param name="originBranch">远端分支</param>
        /// <returns></returns>
        public static Branch branchTrack(Repository repo, Branch originBranch, String newBranch)
        {
            Branch branch = repo.CreateBranch(newBranch, originBranch.Tip);
            repo.Branches.Update(branch, b => b.TrackedBranch = originBranch.CanonicalName);
            return branch;
        }
    }
}
