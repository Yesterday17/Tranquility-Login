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
        private static Repository reppo;

        public static Branch latest
        {
            get
            {
                if(reppo != null)
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

            using (reppo = new Repository(path))
            {
                if (Constants.origin_latest == null || Constants.origin_master == null)
                    return false;

                if (Constants.latest == null)
                {
                    Constants.latest = branchTrack(reppo, Constants.origin_latest);
                }
                reppo = null;
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
