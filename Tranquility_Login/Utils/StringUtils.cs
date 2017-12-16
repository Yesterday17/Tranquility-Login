using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tranquility_Login.Utils
{
    public class StringUtils
    {
        public static StringUtils instance = new StringUtils();

        public UsernamePasswordCredentials getCredentials(string account)
        {
            string[] accountData = account.Split('@');
            try
            {
                if (accountData.Length != 2)
                {
                    throw new FormatException(Localization.zh_CN.err_101);
                }
            }
            catch(Exception e)
            {
                // TODO: 写入错误日志
                // e.Message

                // 将用户信息设置为程序缺省设置
                accountData[0] = Properties.Resources.DefaultUsername;
                accountData[1] = Properties.Resources.DefaultPassword;
            }

            return new UsernamePasswordCredentials { Username = accountData[0], Password = accountData[1] };
        }
    }
}
