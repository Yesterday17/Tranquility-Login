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

        public static StringUtils.configField PreLaunchCommand;
        public static StringUtils.configField PostExitCommand;

        public MultiMC()
        {
            config = StringUtils.getConfigFields(FileUtils.ReadFileLines(Constants.multimc_config_path));
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
            FileUtils.WriteLines(Constants.multimc_path, StringUtils.getConfigStrings(config));
        }
    }
}
