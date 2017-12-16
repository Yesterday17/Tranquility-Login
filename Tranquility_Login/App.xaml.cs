using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tranquility_Login.Utils;

namespace Tranquility_Login
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            foreach (string s in e.Args)
            {
                if (s[0] != '-')
                {
                    switch (s)
                    {
                        case "auto":
                            ArgumentHelper.auto = true;
                            break;

                        case "clone":
                            ArgumentHelper.run.Push(delegate { });
                            break;

                        case "pull":
                            ArgumentHelper.run.Push(delegate { });
                            break;

                        case "configure":
                            ArgumentHelper.run.Push(delegate { });
                            break;

                        case "start":
                        case "launch":
                            ArgumentHelper.run.Push(delegate { });
                            break;

                        default:
                            // TODO: 增加日志中的Warning，跳过
                            // Localization.zh_CN.wrn_101 + $"[{s}]";
                            break;
                    }
                }
                else
                {
                    // TODO: 处理[-options]参数
                }
            }
        }
    }
}
