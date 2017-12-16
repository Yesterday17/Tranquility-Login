using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tranquility_Login.Utils
{
    class StringUtils
    {
        /// <summary>
        /// 配置文件格式类
        /// </summary>
        public class configField
        {
            public string name;
            public string data;

            public configField(string tname, string tdata)
            {
                this.name = tname;
                this.data = tdata;
            }

            public configField()
            {
                this.name = null;
                this.data = null;
            }

            public static configField Format(string line)
            {
                string[] sArray = line.Split('=');
                return new configField(sArray[0], sArray[1] != null ? sArray[1] : "");
            }
            
            public override String ToString()
            {
                return $"{this.name}={this.data}";
            }

            public String Stringify()
            {
                return this.ToString();
            }

            public static String ToString(configField cfg)
            {
                return $"{cfg.name}={cfg.data}";
            }
        }

        /// <summary>
        /// 获得指定列表中对应tname的项的内容
        /// </summary>
        /// <param name="content">列表</param>
        /// <param name="tname">项的名称</param>
        /// <returns></returns>
        public static configField getConfigFieldByName(List<String> content, string tname)
        {
            configField rtn = null;

            content.ForEach(new Action<String>(_line =>
            {
                if (tname == configField.Format(_line).name)
                {
                    rtn = configField.Format(_line);
                    return;
                }
            }));
            return rtn == null ? new configField() : rtn;
        }

        /// <summary>
        /// 获得指定列表中对应tname的项的内容，并移除该项
        /// </summary>
        /// <param name="content">列表</param>
        /// <param name="tname">项的名称</param>
        /// <returns></returns>
        public static configField getConfigFieldByName(List<configField> content, string tname)
        {
            configField rtn = new configField(tname, "");

            content.ForEach(new Action<configField>(_cfg =>
            {
                if (tname == _cfg.name)
                {
                    rtn = _cfg;
                    content.Remove(_cfg);
                    return;
                }
            }));
            return rtn;
        }

        /// <summary>
        /// String List转configFiled List
        /// </summary>
        /// <param name="content">需要转换的String List</param>
        /// <returns>configField List</returns>
        public static List<configField> getConfigFields(List<String> content)
        {
            List<configField> cfgs = new List<configField>();

            content.ForEach(new Action<String>(_line =>
            {
                cfgs.Add(configField.Format(_line));
            }));

            return cfgs;
        }

        /// <summary>
        /// configFiled List转String List
        /// </summary>
        /// <param name="config">需要转换的configField List</param>
        /// <returns>String List</returns>
        public static List<String> getConfigStrings(List<configField> config)
        {
            List<String> content = new List<String>();

            config.ForEach(new Action<configField>(_cfg =>
            {
                content.Add(_cfg.Stringify());
            }));

            return content;
        }

        /// <summary>
        /// 将数组转换成参数形式，默认移除首项。
        /// </summary>
        /// <param name="args">参数数组</param>
        /// <returns>参数命令</returns>
        public static String getArrayArgumented(String[] args)
        {
            String output = "";
            Boolean first = true;

            foreach(String arg in args)
            {
                if (first)
                {
                    first = false;
                    continue;
                }

                output += arg + " ";
            }
            return output;
        }
    }
}
