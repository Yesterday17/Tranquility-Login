using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tranquility_Login.Utils;

namespace Tranquility_Login.Compatible
{
    class MultiMC
    {
        public static List<StringUtils.configField> config;
        private static string location;

        public static StringUtils.configField PreLaunchCommand;
        public static StringUtils.configField PostExitCommand;

        public MultiMC()
        {
            location = Constants.multimc_config_path;
            config = StringUtils.getConfigFields(FileUtils.ReadFileLines(location));
        }

        public MultiMC(string addr)
        {
            location = addr;
            config = StringUtils.getConfigFields(FileUtils.ReadFileLines(location));
        }

        public void ModifyStartupExit()
        {
            PreLaunchCommand = StringUtils.getConfigFieldByName(config, "PreLaunchCommand");
            PostExitCommand = StringUtils.getConfigFieldByName(config, "PostExitCommand");

            PreLaunchCommand.data = "\"$INST_DIR/Tranquility Login.exe\" exit";
            PostExitCommand.data = "\"$INST_DIR/Tranquility Login.exe\" startup";

            config.Add(PreLaunchCommand);
            config.Add(PostExitCommand);
        }

        public void SaveMultiMCConfig()
        {
            FileUtils.WriteLines(location, StringUtils.getConfigStrings(config));
        }
    }
}
