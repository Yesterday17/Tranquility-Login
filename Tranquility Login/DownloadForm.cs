using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tranquility_Login.Compatible;
using Tranquility_Login.Utils;

namespace Tranquility_Login
{
    public partial class DownloadForm : Form
    {
        private static Form frmDownload;
        private static Label label_download;
        private static Label label_size;
        private static ProgressBar progress_download;

        public Boolean exit = true;


        public static string mode = "下载";

        private Boolean clone_finished
        {
            get
            {
                return false;
            }
            set
            {
                if (exit)
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    this.Dispose();
                }
            }
        }

        delegate void textTip(double receive, double total);

        public DownloadForm()
        {
            init();
        }

        public DownloadForm(String text)
        {
            init();
            mode = text;

            this.Text = mode + "中……";
            this.label1.Text = this.Text;
        }

        private void init()
        {
            InitializeComponent();
            frmDownload = this;
            label_download = this.lb_download;
            label_size = this.lb_size;
            progress_download = this.prog_download;
        }

        public static bool TransferProgress(TransferProgress progress)
        {
            textTip textEdit = delegate (double receive, double total)
            {
                label_download.Text = (receive / total * 100).ToString("F2") + "%";
                label_size.Text = $"已{mode}：{progress.ReceivedBytes / 1024 / 1024} MB";
                progress_download.Value = (int)(receive / total * 100);
            };
            label_download.Invoke(textEdit, progress.ReceivedObjects, progress.TotalObjects);

            return true;
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
            if (mode == "下载")
            {
                Task clone = new Task(CloneMethod);
                clone.Start();
            }
            else if (mode == "更新")
            {
                Task update = new Task(PullMethod);
                update.Start();
            }
        }

        private void CloneMethod()
        {
            try
            {
                if (!Directory.Exists(Constants.path))
                    Directory.CreateDirectory(Constants.path);

                CloneOptions co = new CloneOptions
                {
                    //BranchName = "master",
                    OnTransferProgress = DownloadForm.TransferProgress,
                    CredentialsProvider = Constants.credentials
                };

                Repository.Clone(Constants.git_repository, Constants.path, co);

                if (Constants.mcRepositoryIsValid(Constants.path))
                {
                    MessageBox.Show(mode + "完成！");

                    MethodUtils.MultiMCConfigure();
                    clone_finished = true;
                }
                else
                {
                    throw new Exception("未知错误！可能未与远端分支绑定！");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show("请尝试重新启动该程序！");

                //删除并重建minecraft文件夹
                try
                {
                    Directory.Delete(Constants.path, true);
                    Directory.CreateDirectory(Constants.path);
                }
                finally
                {
                    System.Environment.Exit(-1);
                }
            }
        }

        private void PullMethod()
        {
            try
            {
                Commands.Pull(Constants.repo, Constants.sign, new PullOptions()
                {
                    FetchOptions = new FetchOptions()
                    {
                        CredentialsProvider = Constants.credentials,
                        OnTransferProgress = TransferProgress
                    }
                });

                if (Constants.mcRepositoryIsValid(Constants.path))
                {
                    MessageBox.Show(mode + "完成！");

                    MethodUtils.MultiMCConfigure();
                    clone_finished = true;
                }
                else
                {
                    throw new Exception("未知错误！");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show("请尝试重新启动该程序！");

                System.Environment.Exit(-1);
            }
        }
    }
}
