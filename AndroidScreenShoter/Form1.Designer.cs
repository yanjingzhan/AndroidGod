namespace AndroidScreenShoter
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_NoUseNet = new System.Windows.Forms.CheckBox();
            this.label_Tips = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_DisableIt = new System.Windows.Forms.Button();
            this.button_SubmitGameInfo = new System.Windows.Forms.Button();
            this.button_Shot_GetNewGame = new System.Windows.Forms.Button();
            this.button_DownloadGame = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_OpenScreenShotDir = new System.Windows.Forms.Button();
            this.button_OpenPackageDir = new System.Windows.Forms.Button();
            this.textBox_ScreenShotDir = new System.Windows.Forms.TextBox();
            this.textBox_PackageDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_NoUseNet);
            this.groupBox1.Controls.Add(this.label_Tips);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button_DisableIt);
            this.groupBox1.Controls.Add(this.button_SubmitGameInfo);
            this.groupBox1.Controls.Add(this.button_Shot_GetNewGame);
            this.groupBox1.Controls.Add(this.button_DownloadGame);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(899, 258);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "主控信息";
            // 
            // checkBox_NoUseNet
            // 
            this.checkBox_NoUseNet.AutoSize = true;
            this.checkBox_NoUseNet.Checked = true;
            this.checkBox_NoUseNet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_NoUseNet.Enabled = false;
            this.checkBox_NoUseNet.Location = new System.Drawing.Point(20, 158);
            this.checkBox_NoUseNet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_NoUseNet.Name = "checkBox_NoUseNet";
            this.checkBox_NoUseNet.Size = new System.Drawing.Size(104, 19);
            this.checkBox_NoUseNet.TabIndex = 17;
            this.checkBox_NoUseNet.Text = "不使用网络";
            this.checkBox_NoUseNet.UseVisualStyleBackColor = true;
            // 
            // label_Tips
            // 
            this.label_Tips.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Tips.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Tips.ForeColor = System.Drawing.Color.Blue;
            this.label_Tips.Location = new System.Drawing.Point(3, 20);
            this.label_Tips.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Tips.Name = "label_Tips";
            this.label_Tips.Size = new System.Drawing.Size(893, 89);
            this.label_Tips.TabIndex = 5;
            this.label_Tips.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(624, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Iad广告AppKey（黑框那个）";
            this.label7.Visible = false;
            // 
            // button_DisableIt
            // 
            this.button_DisableIt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_DisableIt.ForeColor = System.Drawing.Color.Red;
            this.button_DisableIt.Location = new System.Drawing.Point(729, 182);
            this.button_DisableIt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_DisableIt.Name = "button_DisableIt";
            this.button_DisableIt.Size = new System.Drawing.Size(132, 51);
            this.button_DisableIt.TabIndex = 3;
            this.button_DisableIt.Text = "这个游戏用不了";
            this.button_DisableIt.UseVisualStyleBackColor = true;
            this.button_DisableIt.Click += new System.EventHandler(this.button_DisableIt_Click);
            // 
            // button_SubmitGameInfo
            // 
            this.button_SubmitGameInfo.Location = new System.Drawing.Point(392, 182);
            this.button_SubmitGameInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_SubmitGameInfo.Name = "button_SubmitGameInfo";
            this.button_SubmitGameInfo.Size = new System.Drawing.Size(132, 51);
            this.button_SubmitGameInfo.TabIndex = 2;
            this.button_SubmitGameInfo.Text = "游戏截屏完成";
            this.button_SubmitGameInfo.UseVisualStyleBackColor = true;
            this.button_SubmitGameInfo.Click += new System.EventHandler(this.button_SubmitGameInfo_Click);
            // 
            // button_Shot_GetNewGame
            // 
            this.button_Shot_GetNewGame.Location = new System.Drawing.Point(20, 182);
            this.button_Shot_GetNewGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Shot_GetNewGame.Name = "button_Shot_GetNewGame";
            this.button_Shot_GetNewGame.Size = new System.Drawing.Size(132, 51);
            this.button_Shot_GetNewGame.TabIndex = 0;
            this.button_Shot_GetNewGame.Text = "获取新游戏打包";
            this.button_Shot_GetNewGame.UseVisualStyleBackColor = true;
            this.button_Shot_GetNewGame.Click += new System.EventHandler(this.button_Shot_GetNewGame_Click);
            // 
            // button_DownloadGame
            // 
            this.button_DownloadGame.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_DownloadGame.ForeColor = System.Drawing.Color.MediumBlue;
            this.button_DownloadGame.Location = new System.Drawing.Point(1105, 26);
            this.button_DownloadGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_DownloadGame.Name = "button_DownloadGame";
            this.button_DownloadGame.Size = new System.Drawing.Size(93, 52);
            this.button_DownloadGame.TabIndex = 4;
            this.button_DownloadGame.Text = "下载游戏";
            this.button_DownloadGame.UseVisualStyleBackColor = true;
            this.button_DownloadGame.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 416);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(899, 30);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Status
            // 
            this.toolStripStatusLabel_Status.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
            this.toolStripStatusLabel_Status.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel_Status.Name = "toolStripStatusLabel_Status";
            this.toolStripStatusLabel_Status.Size = new System.Drawing.Size(27, 25);
            this.toolStripStatusLabel_Status.Text = "...";
            this.toolStripStatusLabel_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_OpenScreenShotDir
            // 
            this.button_OpenScreenShotDir.Location = new System.Drawing.Point(787, 308);
            this.button_OpenScreenShotDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_OpenScreenShotDir.Name = "button_OpenScreenShotDir";
            this.button_OpenScreenShotDir.Size = new System.Drawing.Size(75, 22);
            this.button_OpenScreenShotDir.TabIndex = 23;
            this.button_OpenScreenShotDir.Text = "打开";
            this.button_OpenScreenShotDir.UseVisualStyleBackColor = true;
            this.button_OpenScreenShotDir.Click += new System.EventHandler(this.button_OpenScreenShotDir_Click);
            // 
            // button_OpenPackageDir
            // 
            this.button_OpenPackageDir.Location = new System.Drawing.Point(787, 262);
            this.button_OpenPackageDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_OpenPackageDir.Name = "button_OpenPackageDir";
            this.button_OpenPackageDir.Size = new System.Drawing.Size(75, 22);
            this.button_OpenPackageDir.TabIndex = 21;
            this.button_OpenPackageDir.Text = "打开";
            this.button_OpenPackageDir.UseVisualStyleBackColor = true;
            this.button_OpenPackageDir.Click += new System.EventHandler(this.button_OpenPackageDir_Click);
            // 
            // textBox_ScreenShotDir
            // 
            this.textBox_ScreenShotDir.Location = new System.Drawing.Point(143, 306);
            this.textBox_ScreenShotDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ScreenShotDir.Name = "textBox_ScreenShotDir";
            this.textBox_ScreenShotDir.ReadOnly = true;
            this.textBox_ScreenShotDir.Size = new System.Drawing.Size(628, 25);
            this.textBox_ScreenShotDir.TabIndex = 22;
            // 
            // textBox_PackageDir
            // 
            this.textBox_PackageDir.Location = new System.Drawing.Point(143, 261);
            this.textBox_PackageDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_PackageDir.Name = "textBox_PackageDir";
            this.textBox_PackageDir.ReadOnly = true;
            this.textBox_PackageDir.Size = new System.Drawing.Size(628, 25);
            this.textBox_PackageDir.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "截屏图片存的位置:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "安装包目录:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 446);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_OpenScreenShotDir);
            this.Controls.Add(this.button_OpenPackageDir);
            this.Controls.Add(this.textBox_ScreenShotDir);
            this.Controls.Add(this.textBox_PackageDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试截屏专用者";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_NoUseNet;
        private System.Windows.Forms.Label label_Tips;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_DisableIt;
        private System.Windows.Forms.Button button_SubmitGameInfo;
        private System.Windows.Forms.Button button_Shot_GetNewGame;
        private System.Windows.Forms.Button button_DownloadGame;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Status;
        private System.Windows.Forms.Button button_OpenScreenShotDir;
        private System.Windows.Forms.Button button_OpenPackageDir;
        private System.Windows.Forms.TextBox textBox_ScreenShotDir;
        private System.Windows.Forms.TextBox textBox_PackageDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}

