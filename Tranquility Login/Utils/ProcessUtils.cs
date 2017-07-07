using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranquility_Login.Utils
{
    class ProcessUtils
    {
        public static DateTime findNoMinecraftProcessTime = Constants.StartTime;

        public static void Track()
        {
            Process[] processes;
            processes = System.Diagnostics.Process.GetProcesses();

            foreach (Process process in processes)
            {
                //System.Windows.Forms.MessageBox.Show($"Title: {process.MainWindowTitle.Substring(0, 9)}\nName: {process.ProcessName}\n");
                findNoMinecraftProcessTime = DateTime.Now;
                if ((process.ProcessName == "java" || process.ProcessName == "javaw")
                    && process.MainWindowTitle.Length >= 9
                    && process.MainWindowTitle.Substring(0, 9) == "Minecraft"
                    && MethodUtils.Alike(process.StartTime, Constants.StartTime, 60000))
                {
                    findNoMinecraftProcessTime = Constants.StartTime;
                }
            }
        }

        public static void StartProcess(String fileName, String arguments)
        {
            Process p = setProcess(fileName, arguments);

            Task start = new Task(new Action(() =>
           {
               p.Start();
           }));

            start.Start();
            System.Threading.Thread.Sleep(1000);
        }

        public static Process setProcess(String fileName, string arguments)
        {
            Process p = new Process();
            p.StartInfo.FileName = fileName;
            p.StartInfo.Arguments = arguments;

            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;

            return p;
        }
    }
}
