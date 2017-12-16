using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tranquility_Login.Utils
{
    public static class ArgumentHelper
    {
        /* 
         * 此处简单概括一下参数的使用方法。
         * 1.若没有参数，则默认执行configure任务。
         *   用法：Tranquility-Login <task> [-options]
         *   
         *   其中任务(<task>)包括：
         *      auto        根据实际情况决定进行clone、pull、configure、start
         *      clone       获取完整的整合包
         *      pull        获取最新的整合副本
         *      configure   自动配置启动器设置
         *      start | launch
         *                  启动游戏
         *   
         *   其中选项([-options])包括：
         *      -launcher [multimc | hmcl]
         *                  配置MultiMC或HMCL启动器的启动设置
         *      -repo=[:<repository name>] 
         *                  设置本程序获取的整合包地址
         *      -account=[:<username>@:<password>]
         *                  设置Clone仓库时使用的用户名和密码
         *      -? | -help  输出此帮助信息
         *      -version    输出产品版本并退出
         *      
         *   如果需要更详细的帮助信息，请提交Issue至 https://github.com/yesterday17/Tranquility-Login
         */

        public static Boolean auto = false;
        public static Boolean init = false;

        public static Stack<Action> run = new Stack<Action>();

    }
}
