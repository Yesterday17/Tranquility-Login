namespace Tranquility_Login
{
    partial class DownloadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lb_download = new System.Windows.Forms.Label();
            this.prog_download = new System.Windows.Forms.ProgressBar();
            this.lb_size = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(87, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "下载中……";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_download
            // 
            this.lb_download.AutoSize = true;
            this.lb_download.Location = new System.Drawing.Point(130, 122);
            this.lb_download.Name = "lb_download";
            this.lb_download.Size = new System.Drawing.Size(0, 15);
            this.lb_download.TabIndex = 1;
            // 
            // prog_download
            // 
            this.prog_download.Location = new System.Drawing.Point(52, 180);
            this.prog_download.Name = "prog_download";
            this.prog_download.Size = new System.Drawing.Size(181, 23);
            this.prog_download.TabIndex = 2;
            // 
            // lb_size
            // 
            this.lb_size.AutoSize = true;
            this.lb_size.Location = new System.Drawing.Point(63, 150);
            this.lb_size.Name = "lb_size";
            this.lb_size.Size = new System.Drawing.Size(67, 15);
            this.lb_size.TabIndex = 3;
            this.lb_size.Text = "已下载：";
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.lb_size);
            this.Controls.Add(this.prog_download);
            this.Controls.Add(this.lb_download);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户端下载中……";
            this.Load += new System.EventHandler(this.DownloadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_download;
        private System.Windows.Forms.ProgressBar prog_download;
        private System.Windows.Forms.Label lb_size;
    }
}