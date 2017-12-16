using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibGit2Sharp;

namespace Tranquility_Login.Utils
{
    public static class GitHelper
    {

        public static void Clone(string repo, string account)
        {
            // 进行用户名或密码的配置
            CloneOptions co = new CloneOptions();
            co.CredentialsProvider = (_url, _user, _cred) => StringUtils.instance.getCredentials(account);

            // Clone步骤
            Repository.Clone(repo, @"", co);
        }

        public static void Clone(string repo)
        {
            Clone(repo, "");
        }
    }
}
