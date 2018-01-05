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
                            MainWindow.Show();
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
                    if(StringUtils.SubStringMatch(s, "launcher", 1, 8))
                    {
                        // TODO: 根据启动器配置
                        continue;
                    }

                    if(StringUtils.SubStringMatch(s, "repo", 1, 4))
                    {
                        // TODO: 设置项目仓库
                        continue;
                    }

                    if(StringUtils.SubStringMatch(s, "account", 1, 7))
                    {
                        // TODO: 配置账号
                        continue;
                    }
                        
                    if( (s.Length == 2 && s[1] == '?') || StringUtils.SubStringMatch(s, "help", 1, 4))
                    {
                        MessageBox.Show(Localization.zh_CN.HelpData, "Tranquility Login 启动参数说明");
                        Application.Current.Shutdown();
                    }

                    if(StringUtils.SubStringMatch(s, "version", 1, 7))
                    {
                        MessageBox.Show($"{Localization.zh_CN.version_prefix}{Constants.version}{Localization.zh_CN.version_after}", "Tranquility Login 启动参数说明");
                        Application.Current.Shutdown();
                    }
                }
            }
        }
    }
}
