using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibGit2Sharp;

namespace Tranquility_Login.Utils
{
    /// <summary>
    /// LibGit2Sharp的帮助类
    /// </summary>
    public static class GitHelper
    {
        /// <summary>
        /// 进行整合包的Clone
        /// </summary>
        /// <param name="repo">Git仓库地址</param>
        /// <param name="account">对应仓库的账号</param>
        public static void Clone(string repo, string account)
        {
            // 进行用户名或密码的配置
            CloneOptions co = new CloneOptions
            {
                CredentialsProvider = (_url, _user, _cred) => StringUtils.instance.getCredentials(account)
            };

            // Clone步骤
            Repository.Clone(repo, Constants.minecraft_path, co);
        }

        /// <summary>
        /// 进行公共整合包的Clone
        /// </summary>
        /// <param name="repo">Git仓库地址</param>
        public static void Clone(string repo)
        {
            Clone(repo, Constants.minecraft_path);
        }
    }
}
