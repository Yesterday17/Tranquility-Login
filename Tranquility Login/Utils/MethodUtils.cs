using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tranquility_Login.Compatible;

namespace Tranquility_Login.Utils
{
    class MethodUtils
    {
        public static void MultiMCConfigure()
        {
            MultiMC launcher = new MultiMC();
            launcher.ModifyStartupExit();
            launcher.SaveMultiMCConfig();
            MessageBox.Show("MultiMC配置完成，请使用MultiMC启动！");
        }
    }
}
