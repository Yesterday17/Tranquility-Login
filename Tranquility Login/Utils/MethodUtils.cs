using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tranquility_Login.Compatible;

namespace Tranquility_Login.Utils
{
    static class MethodUtils
    {
        public static Repository reppo = null;

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
            return mcRepositoryIsValid(Constants.path);
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

        /// <summary>
        /// 切换到Latest分支
        /// </summary>
        public static void CheckoutLatest()
        {
            Constants.repo.Reset(ResetMode.Hard);
            Commands.Checkout(Constants.repo, Constants.latest);
        }

        /// <summary>
        /// 切换到Master分支
        /// </summary>
        public static void CheckoutMaster()
        {
            Constants.repo.Reset(ResetMode.Hard);
            Commands.Checkout(Constants.repo, Constants.master);
        }

        /// <summary>
        /// 配置MultiMC实例配置文件
        /// </summary>
        public static void MultiMCConfigure()
        {
            MultiMC launcher = new MultiMC();
            launcher.ModifyStartupExit();
            launcher.SaveMultiMCConfig();
            MessageBox.Show("MultiMC配置完成，请使用MultiMC启动！");
        }

        /// <summary>
        /// 加载Tranquility Login配置文件
        /// </summary>
        public static void ConfigLoad()
        {

        }
    }
}
