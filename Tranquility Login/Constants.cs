using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tranquility_Login
{
    class Constants
    {
        public static Repository repo;

        public static Branch latest = null;
        public static Branch master = null;
        public static Branch origin_latest = null;
        public static Branch origin_master = null;

        public static String git_repository = "https://git.coding.net/yesterday17/TestMinecraft.git";

        public static Signature sign = new Signature("tan90", "tan90@yesterday17.cn", new DateTimeOffset());

        public static string path = System.Windows.Forms.Application.StartupPath + "/minecraft/";

        public enum LoadState
        {
            startup = 1,
            exit = 2,

            init = 3,
            update = 4
        };

        public static Boolean mcRepositoryIsValid(String path)
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
                            Constants.latest = b;
                            break;

                        case "master":
                            Constants.master = b;
                            break;

                        case "origin/latest":
                            Constants.origin_latest = b;
                            break;

                        case "origin/master":
                            Constants.origin_master = b;
                            break;
                    }
                }
                if (Constants.origin_latest == null || Constants.origin_master == null)
                    return false;

                if (Constants.latest == null)
                {
                    Constants.latest = branchTrack(repo, Constants.origin_latest);
                }
            }
            return true;
        }

        public static Boolean mcRepositoryIsValid()
        {
            return mcRepositoryIsValid(path);
        }

        public static Branch branchTrack(Repository repo, Branch originBranch)
        {
            Branch branch = repo.CreateBranch("latest", originBranch.Tip);
            repo.Branches.Update(branch, b => b.TrackedBranch = originBranch.CanonicalName);
            return branch;
        }
    }
}
