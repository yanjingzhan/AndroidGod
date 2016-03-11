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

namespace AndroidScreenShoter
{
    public partial class Form1 : Form
    {
        string _currentGameFile = string.Empty;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            SetStartButtonEnable();

            SetTipsInfo("请点击 获取新游戏打包 按钮");
        }

        private void SetStartButtonEnable()
        {
            this.button_Shot_GetNewGame.Enabled = true;
            this.button_DisableIt.Enabled = false;
            this.button_OpenPackageDir.Enabled = false;
            this.button_OpenScreenShotDir.Enabled = false;
            this.button_SubmitGameInfo.Enabled = false;

            this.textBox_ScreenShotDir.Clear();
            this.textBox_PackageDir.Clear();
        }

        private void SetDevelopingButtonEnable()
        {
            this.button_Shot_GetNewGame.Enabled = false;
            this.button_DisableIt.Enabled = true;
            this.button_OpenPackageDir.Enabled = true;
            this.button_OpenScreenShotDir.Enabled = true;
            this.button_SubmitGameInfo.Enabled = true;
        }

        private void SetTipsInfo(string info)
        {
            this.label_Tips.Text = info;
        }

        private void SetStatusInfo(string info)
        {
            this.toolStripStatusLabel_Status.Text = DateTime.Now.ToString() + "----" + info;
        }

        private void button_Shot_GetNewGame_Click(object sender, EventArgs e)
        {
            SetStatusInfo("正在执行……");

            try
            {
                string androidDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "apks");
                foreach (var a in Directory.GetDirectories(androidDir))
                {
                    foreach (var f in Directory.GetFiles(a))
                    {
                        _currentGameFile = f;
                    }
                }

                if (string.IsNullOrWhiteSpace(_currentGameFile))
                {
                    throw new Exception("没有游戏了！");
                }

                string tempDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "安装包目录");
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }

                File.Copy(_currentGameFile, Path.Combine(tempDir, Path.GetFileName(_currentGameFile)),true);
                this.textBox_PackageDir.Text = tempDir;

                string screenShotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "android", Path.GetFileNameWithoutExtension(_currentGameFile));
                if (!Directory.Exists(screenShotPath))
                {
                    Directory.CreateDirectory(screenShotPath);
                }
                this.textBox_ScreenShotDir.Text = screenShotPath;

                SetDevelopingButtonEnable();

                SetStatusInfo("打包成功.");
                SetTipsInfo("打包成功，请到 安装包目录 下安装游戏到手机中，并截屏。将截屏文件复制到 截屏图片存的位置 下");
            }
            catch (Exception ex)
            {
                SetStatusInfo("获取游戏失败,\n" + ex.Message);
            }
        }

        private void button_SubmitGameInfo_Click(object sender, EventArgs e)
        {
            string screenShotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "android", Path.GetFileNameWithoutExtension(_currentGameFile));
            File.Move(_currentGameFile, Path.Combine(screenShotPath, Path.GetFileName(_currentGameFile)));

            _currentGameFile = string.Empty;

            SetStartButtonEnable();

            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
            {
                foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                {
                    File.Delete(f);
                }
            }
        }

        private void button_DisableIt_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定这个游戏不可用？？？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                string shitPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "android", "shit");
                if(!Directory.Exists(shitPath))
                {
                    Directory.CreateDirectory(shitPath);
                }

                File.Move(_currentGameFile, Path.Combine(shitPath, Path.GetFileName(_currentGameFile)));

                _currentGameFile = string.Empty;

                try
                {
                    Directory.Delete(textBox_ScreenShotDir.Text, true);
                }
                catch { }

                SetStartButtonEnable();

                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                {
                    foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                    {
                        File.Delete(f);
                    }
                }
            }
        }

        private void button_OpenPackageDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "\"" + this.textBox_PackageDir.Text + "\"");
        }

        private void button_OpenScreenShotDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "\"" + this.textBox_ScreenShotDir.Text + "\"");
        }
    }
}
