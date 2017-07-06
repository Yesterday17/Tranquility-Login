using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tranquility_Login.Utils
{
    class FileUtils
    {
        /// <summary>
        /// 基本文件读取
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>返回读取得到的数据</returns>
        public static String ReadFile(String fileName)
        {
            return new StreamReader(fileName, Encoding.UTF8).ReadToEnd();
        }

        /// <summary>
        /// 读取一个文件中的所有行 适用于MultiMC实例的cfg文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>读取得到的行的List</returns>
        public static List<String> ReadFileLines(String fileName)
        {
            List<String> lines = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(fileName, Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                System.Environment.Exit(-1);
            }
            return lines;
        }

        /// <summary>
        /// 创建并写入某文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="content">写入的内容</param>
        public static void WriteFile(String fileName, String content)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                sw.Write(content);

                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                System.Environment.Exit(-1);
            }

        }

        /// <summary>
        /// 创建并写入指定行字符串
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="lines">字符串行列表</param>
        public static void WriteLines(String fileName, List<String> lines)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                lines.ForEach(new Action<string>(_line =>
                {
                    sw.WriteLine(_line);
                }));

                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                System.Environment.Exit(-1);
            }
        }
    }
}
