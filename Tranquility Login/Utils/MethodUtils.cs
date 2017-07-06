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
