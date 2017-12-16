using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tranquility_Login.Utils
{
    /// <summary>
    /// 字符串处理的工具类
    /// </summary>
    public class StringUtils
    {
        /// <summary>
        /// 对非静态方法的封装
        /// </summary>
        public static StringUtils instance = new StringUtils();

        /// <summary>
        /// 根据输入的账号信息获取用户名和密码
        /// </summary>
        /// <param name="account">输入的账号信息</param>
        /// <returns>用于CloneOptions的用户数据信息</returns>
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
