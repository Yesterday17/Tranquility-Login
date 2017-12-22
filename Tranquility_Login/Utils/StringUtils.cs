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
        /// 进行更加安全的字符串匹配
        /// </summary>
        /// <param name="original">原字符串</param>
        /// <param name="match">匹配字符串</param>
        /// <param name="start">开始位置</param>
        /// <param name="length">截取长度</param>
        /// <returns>是否匹配</returns>
        public static Boolean SubStringMatch(string original, string match, int start, int length)
        {
            if (original.Length < start + length)
                return false;

            return (original.Substring(start, length) == match);
        }

        /// <summary>
        /// 根据输入的账号信息获取用户名和密码
        /// </summary>
        /// <param name="account">输入的账号信息</param>
        /// <returns>用于CloneOptions的用户数据信息</returns>
        public UsernamePasswordCredentials GetCredentials(string account)
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
