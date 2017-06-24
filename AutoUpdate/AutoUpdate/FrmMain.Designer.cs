namespace AutoUpdate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblmsg = new System.Windows.Forms.Label();
            this.Btn_close = new System.Windows.Forms.Button();
            this.Btn_update = new System.Windows.Forms.Button();
            this.pB = new System.Windows.Forms.ProgressBar();
            this.Back_thread = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.Lb_count = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Lb_rlready = new System.Windows.Forms.Label();
            this.Lb_downfile = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "本程序可帮助你升级XXX公司产品";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(131, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "欢迎使用在线升级";
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Location = new System.Drawing.Point(131, 124);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(59, 12);
            this.lblmsg.TabIndex = 11;
            this.lblmsg.Text = "更新进度:";
            // 
            // Btn_close
            // 
            this.Btn_close.Location = new System.Drawing.Point(414, 151);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.Size = new System.Drawing.Size(82, 23);
            this.Btn_close.TabIndex = 10;
            this.Btn_close.Text = "取消";
            this.Btn_close.UseVisualStyleBackColor = true;
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // Btn_update
            // 
            this.Btn_update.Location = new System.Drawing.Point(327, 151);
            this.Btn_update.Name = "Btn_update";
            this.Btn_update.Size = new System.Drawing.Size(81, 23);
            this.Btn_update.TabIndex = 9;
            this.Btn_update.Text = "升级";
            this.Btn_update.UseVisualStyleBackColor = true;
            this.Btn_update.Click += new System.EventHandler(this.Btn_update_Click);
            // 
            // pB
            // 
            this.pB.Location = new System.Drawing.Point(195, 122);
            this.pB.Name = "pB";
            this.pB.Size = new System.Drawing.Size(301, 20);
            this.pB.TabIndex = 8;
            // 
            // Back_thread
            // 
            this.Back_thread.WorkerReportsProgress = true;
            this.Back_thread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Back_thread_DoWork);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "共需下载:";
            // 
            // Lb_count
            // 
            this.Lb_count.AutoSize = true;
            this.Lb_count.Location = new System.Drawing.Point(208, 58);
            this.Lb_count.Name = "Lb_count";
            this.Lb_count.Size = new System.Drawing.Size(29, 12);
            this.Lb_count.TabIndex = 13;
            this.Lb_count.Text = "0 MB";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "已下载:";
            // 
            // Lb_rlready
            // 
            this.Lb_rlready.AutoSize = true;
            this.Lb_rlready.Location = new System.Drawing.Point(208, 90);
            this.Lb_rlready.Name = "Lb_rlready";
            this.Lb_rlready.Size = new System.Drawing.Size(29, 12);
            this.Lb_rlready.TabIndex = 13;
            this.Lb_rlready.Text = "0 MB";
            // 
            // Lb_downfile
            // 
            this.Lb_downfile.FormattingEnabled = true;
            this.Lb_downfile.ItemHeight = 12;
            this.Lb_downfile.Location = new System.Drawing.Point(131, 180);
            this.Lb_downfile.Name = "Lb_downfile";
            this.Lb_downfile.Size = new System.Drawing.Size(365, 100);
            this.Lb_downfile.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "更新文件列表:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "正在执行后台升级程序请稍等";
            this.notifyIcon1.BalloonTipTitle = "升级";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "正在升级中.....";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 297);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(517, 297);
            this.Controls.Add(this.Lb_downfile);
            this.Controls.Add(this.Lb_rlready);
            this.Controls.Add(this.Lb_count);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.Btn_close);
            this.Controls.Add(this.Btn_update);
            this.Controls.Add(this.pB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动更新";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblmsg;
        private System.Windows.Forms.Button Btn_close;
        private System.Windows.Forms.Button Btn_update;
        private System.Windows.Forms.ProgressBar pB;
        private System.ComponentModel.BackgroundWorker Back_thread;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Lb_count;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Lb_rlready;
        private System.Windows.Forms.ListBox Lb_downfile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

