namespace RePackage
{
    partial class MainForm
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_SelectOldPackagePath = new System.Windows.Forms.Button();
            this.textBox_OldPackagePath = new System.Windows.Forms.TextBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_CurrentGameName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_FailCount = new System.Windows.Forms.Label();
            this.label_SucCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_NewPackagePath = new System.Windows.Forms.TextBox();
            this.button_SelectNewPackagePath = new System.Windows.Forms.Button();
            this.button_test = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Info
            // 
            this.textBox_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Info.Location = new System.Drawing.Point(0, 0);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Info.Size = new System.Drawing.Size(1185, 386);
            this.textBox_Info.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_Info);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 355);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1185, 386);
            this.panel2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "成功";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_test);
            this.groupBox2.Controls.Add(this.button_SelectNewPackagePath);
            this.groupBox2.Controls.Add(this.button_SelectOldPackagePath);
            this.groupBox2.Controls.Add(this.textBox_NewPackagePath);
            this.groupBox2.Controls.Add(this.textBox_OldPackagePath);
            this.groupBox2.Controls.Add(this.button_Start);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label_CurrentGameName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label_FailCount);
            this.groupBox2.Controls.Add(this.label_SucCount);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1185, 194);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信息";
            // 
            // button_SelectOldPackagePath
            // 
            this.button_SelectOldPackagePath.Location = new System.Drawing.Point(1027, 92);
            this.button_SelectOldPackagePath.Name = "button_SelectOldPackagePath";
            this.button_SelectOldPackagePath.Size = new System.Drawing.Size(146, 23);
            this.button_SelectOldPackagePath.TabIndex = 6;
            this.button_SelectOldPackagePath.Text = "选择";
            this.button_SelectOldPackagePath.UseVisualStyleBackColor = true;
            this.button_SelectOldPackagePath.Click += new System.EventHandler(this.button_SelectOldPackagePath_Click);
            // 
            // textBox_OldPackagePath
            // 
            this.textBox_OldPackagePath.Location = new System.Drawing.Point(82, 92);
            this.textBox_OldPackagePath.Name = "textBox_OldPackagePath";
            this.textBox_OldPackagePath.Size = new System.Drawing.Size(939, 25);
            this.textBox_OldPackagePath.TabIndex = 5;
            this.textBox_OldPackagePath.Text = "G:\\Android\\Games\\下载的\\temp\\unity可用";
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(1027, 24);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(146, 40);
            this.button_Start.TabIndex = 4;
            this.button_Start.Text = "开始";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "老包路径";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "当天";
            // 
            // label_CurrentGameName
            // 
            this.label_CurrentGameName.AutoSize = true;
            this.label_CurrentGameName.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CurrentGameName.Location = new System.Drawing.Point(399, 21);
            this.label_CurrentGameName.Name = "label_CurrentGameName";
            this.label_CurrentGameName.Size = new System.Drawing.Size(130, 31);
            this.label_CurrentGameName.TabIndex = 2;
            this.label_CurrentGameName.Text = "哦草。xap";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "失败";
            // 
            // label_FailCount
            // 
            this.label_FailCount.AutoSize = true;
            this.label_FailCount.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_FailCount.Location = new System.Drawing.Point(238, 21);
            this.label_FailCount.Name = "label_FailCount";
            this.label_FailCount.Size = new System.Drawing.Size(29, 31);
            this.label_FailCount.TabIndex = 2;
            this.label_FailCount.Text = "0";
            // 
            // label_SucCount
            // 
            this.label_SucCount.AutoSize = true;
            this.label_SucCount.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SucCount.Location = new System.Drawing.Point(72, 21);
            this.label_SucCount.Name = "label_SucCount";
            this.label_SucCount.Size = new System.Drawing.Size(29, 31);
            this.label_SucCount.TabIndex = 2;
            this.label_SucCount.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 194);
            this.panel1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 194);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1185, 161);
            this.panel3.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "新包路径";
            // 
            // textBox_NewPackagePath
            // 
            this.textBox_NewPackagePath.Location = new System.Drawing.Point(81, 130);
            this.textBox_NewPackagePath.Name = "textBox_NewPackagePath";
            this.textBox_NewPackagePath.Size = new System.Drawing.Size(939, 25);
            this.textBox_NewPackagePath.TabIndex = 5;
            this.textBox_NewPackagePath.Text = "G:\\Android\\RePackager\\apks";
            // 
            // button_SelectNewPackagePath
            // 
            this.button_SelectNewPackagePath.Location = new System.Drawing.Point(1026, 134);
            this.button_SelectNewPackagePath.Name = "button_SelectNewPackagePath";
            this.button_SelectNewPackagePath.Size = new System.Drawing.Size(146, 23);
            this.button_SelectNewPackagePath.TabIndex = 6;
            this.button_SelectNewPackagePath.Text = "选择";
            this.button_SelectNewPackagePath.UseVisualStyleBackColor = true;
            this.button_SelectNewPackagePath.Click += new System.EventHandler(this.button_SelectNewPackagePath_Click);
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(859, 41);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(75, 23);
            this.button_test.TabIndex = 7;
            this.button_test.Text = "test";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 741);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox_Info;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_FailCount;
        private System.Windows.Forms.Label label_SucCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_SelectOldPackagePath;
        private System.Windows.Forms.TextBox textBox_OldPackagePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_CurrentGameName;
        private System.Windows.Forms.Button button_SelectNewPackagePath;
        private System.Windows.Forms.TextBox textBox_NewPackagePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_test;
    }
}

