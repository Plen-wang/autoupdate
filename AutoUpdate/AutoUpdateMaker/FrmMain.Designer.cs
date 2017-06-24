namespace AutoUpdateMaker
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Tb_path = new System.Windows.Forms.TextBox();
            this.Bt_browser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Bt_close = new System.Windows.Forms.Button();
            this.Bt_execution = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Tb_webpath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tb_version = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Tb_path
            // 
            this.Tb_path.Location = new System.Drawing.Point(119, 4);
            this.Tb_path.Name = "Tb_path";
            this.Tb_path.ReadOnly = true;
            this.Tb_path.Size = new System.Drawing.Size(198, 21);
            this.Tb_path.TabIndex = 0;
            // 
            // Bt_browser
            // 
            this.Bt_browser.Location = new System.Drawing.Point(342, 2);
            this.Bt_browser.Name = "Bt_browser";
            this.Bt_browser.Size = new System.Drawing.Size(75, 23);
            this.Bt_browser.TabIndex = 1;
            this.Bt_browser.Text = "浏览";
            this.Bt_browser.UseVisualStyleBackColor = true;
            this.Bt_browser.Click += new System.EventHandler(this.Bt_browser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "更新包制作路径:";
            // 
            // Bt_close
            // 
            this.Bt_close.Location = new System.Drawing.Point(342, 112);
            this.Bt_close.Name = "Bt_close";
            this.Bt_close.Size = new System.Drawing.Size(75, 23);
            this.Bt_close.TabIndex = 4;
            this.Bt_close.Text = "退出";
            this.Bt_close.UseVisualStyleBackColor = true;
            this.Bt_close.Click += new System.EventHandler(this.Bt_close_Click);
            // 
            // Bt_execution
            // 
            this.Bt_execution.Location = new System.Drawing.Point(242, 112);
            this.Bt_execution.Name = "Bt_execution";
            this.Bt_execution.Size = new System.Drawing.Size(75, 23);
            this.Bt_execution.TabIndex = 3;
            this.Bt_execution.Text = "制作";
            this.Bt_execution.UseVisualStyleBackColor = true;
            this.Bt_execution.Click += new System.EventHandler(this.Bt_execution_Click);
            // 
            // Tb_webpath
            // 
            this.Tb_webpath.Location = new System.Drawing.Point(119, 39);
            this.Tb_webpath.MaxLength = 50;
            this.Tb_webpath.Name = "Tb_webpath";
            this.Tb_webpath.Size = new System.Drawing.Size(298, 21);
            this.Tb_webpath.TabIndex = 1;
            this.Tb_webpath.Text = "http://192.20.1.16:8088/HomePage/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "服务器下载地址:";
            // 
            // Tb_version
            // 
            this.Tb_version.Location = new System.Drawing.Point(119, 69);
            this.Tb_version.MaxLength = 7;
            this.Tb_version.Name = "Tb_version";
            this.Tb_version.Size = new System.Drawing.Size(298, 21);
            this.Tb_version.TabIndex = 2;
            this.Tb_version.Text = "1.0.0.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "软件版本号:";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 143);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(423, 23);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 166);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Bt_close);
            this.Controls.Add(this.Tb_version);
            this.Controls.Add(this.Bt_execution);
            this.Controls.Add(this.Tb_webpath);
            this.Controls.Add(this.Bt_browser);
            this.Controls.Add(this.Tb_path);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "升级包制作程序";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Tb_path;
        private System.Windows.Forms.Button Bt_browser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Bt_close;
        private System.Windows.Forms.Button Bt_execution;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox Tb_webpath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tb_version;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

