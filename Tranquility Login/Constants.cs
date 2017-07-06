using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tranquility_Login
{
    class Constants
    {
        public static String git_repository = "https://git.coding.net/yesterday17/TestMinecraft.git";

        public static Signature sign = new Signature("tan90", "tan90@yesterday17.cn", new DateTimeOffset());

        public static string path = System.Windows.Forms.Application.StartupPath + "/minecraft/";
    }
}
