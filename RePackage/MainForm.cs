using RePackage.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RePackage
{
    public partial class MainForm : Form
    {
        private int _currentSucCount;

        public int CurrentSucCount
        {
            get { return _currentSucCount; }
            set
            {
                _currentSucCount = value;
                this.label_SucCount.Text = _currentSucCount.ToString();
            }
        }

        private int _currentFailCount;

        public int CurrentFailCount
        {
            get { return _currentFailCount; }
            set
            {
                _currentFailCount = value;
                this.label_FailCount.Text = _currentFailCount.ToString();
            }
        }

        private void SetInfo(string msg)
        {
            this.textBox_Info.AppendText(DateTime.Now.ToString() + "," + this.label_CurrentGameName.Text + "," + msg);
            this.textBox_Info.AppendText(Environment.NewLine);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void button_SelectOldPackagePath_Click(object sender, EventArgs e)
        {
            FolderDialog fd = new FolderDialog();

            if (fd.DisplayDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox_OldPackagePath.Text = fd.Path;
            }
        }

        private void button_SelectNewPackagePath_Click(object sender, EventArgs e)
        {
            FolderDialog fd = new FolderDialog();

            if (fd.DisplayDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox_NewPackagePath.Text = fd.Path;
            }
        }

        private void ClearTempDir()
        {
            string tempDir = AppDomain.CurrentDomain.BaseDirectory + "temp";
            if (Directory.Exists(tempDir))
            {
                Directory.Delete(tempDir, true);
            }

            Directory.CreateDirectory(tempDir);
        }

        private void CopyTemplateToTempDir(string version)
        {
            string cmd = string.Format("/e /y {0} {1}", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "template", version.Substring(0, 3)), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp", "template").TrimEnd('\\') + "\\");
            //Process.Start("xcopy", cmd).WaitForExit();
            Process p = new Process();
            p.StartInfo.FileName = "xcopy";
            p.StartInfo.Arguments = cmd;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit();
        }

        public void UnZipGamePacakge(string gamePackage)
        {
            string tempUnZipDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp", "unzip");
            if (!Directory.Exists(tempUnZipDir))
            {
                Directory.CreateDirectory(tempUnZipDir);
            }
            ZipHelper.ExtractZipFile(gamePackage, string.Empty, tempUnZipDir);
        }

        public async Task DecompileGame(string gamePackage)
        {
            string toolsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools");
            Directory.SetCurrentDirectory(toolsDir);

            string cmd1 = string.Format("d \"{0}\"", gamePackage);
            //Process.Start("apktool", cmd1).WaitForExit();
            Process p1 = new Process();
            p1.StartInfo.FileName = "apktool";
            p1.StartInfo.Arguments = cmd1;
            p1.StartInfo.CreateNoWindow = true;
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p1.Start();
            p1.WaitForExit();


            //await Task.Delay(TimeSpan.FromSeconds(2));

            string unzipPackagePath = Path.Combine(toolsDir, Path.GetFileNameWithoutExtension(gamePackage));
            string tempUnZipDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp", "unzip");
            if (!Directory.Exists(tempUnZipDir))
            {
                Directory.CreateDirectory(tempUnZipDir);
            }

            string cmd2 = string.Format("/e /y {0} {1}", unzipPackagePath, tempUnZipDir.TrimEnd('\\') + "\\");
            //Process.Start("xcopy", cmd2).WaitForExit();
            Process p2 = new Process();
            p2.StartInfo.FileName = "xcopy";
            p2.StartInfo.Arguments = cmd2;
            p2.StartInfo.CreateNoWindow = true;
            p2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p2.Start();
            p2.WaitForExit();

            await Task.Delay(TimeSpan.FromSeconds(2));

            Directory.Delete(unzipPackagePath, true);
        }

        public void SyncManifestFile()
        {
            string gameManifest = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"temp\unzip", "AndroidManifest.xml");
            string templateManifest = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"temp\template", "AndroidManifest.xml");

            XmlHelper.SetAndroidManifest(gameManifest, templateManifest);
        }

        private void OverWriteFuckingDataFile()
        {
            string tempUnZipDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp", "unzip");
            string tempTemplate = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp", "template");

            string binDir = Path.Combine(tempUnZipDir, "assets");
            string libDir = Path.Combine(tempUnZipDir, "lib");

            string tempBinDir = Path.Combine(tempTemplate, "assets");
            string tempLibDir = Path.Combine(tempTemplate, "lib");

            string cmd1 = string.Format("/e /y {0} {1}", binDir, tempBinDir);
            //Process.Start("xcopy", cmd1).WaitForExit();

            Process p1 = new Process();
            p1.StartInfo.FileName = "xcopy";
            p1.StartInfo.Arguments = cmd1;
            p1.StartInfo.CreateNoWindow = true;
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p1.Start();
            p1.WaitForExit();

            string cmd2 = string.Format("/e /y {0} {1}", libDir, tempLibDir);
            //Process.Start("xcopy", cmd2).WaitForExit();

            Process p2 = new Process();
            p2.StartInfo.FileName = "xcopy";
            p2.StartInfo.Arguments = cmd2;
            p2.StartInfo.CreateNoWindow = true;
            p2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p2.Start();
            p2.WaitForExit();
        }

        public void CompileFucking()
        {
            string toolsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools");
            Directory.SetCurrentDirectory(toolsDir);

            string cmd = string.Format("b ../temp/template");
            //Process.Start("apktool", cmd).WaitForExit();

            Process p = new Process();
            p.StartInfo.FileName = "apktool";
            p.StartInfo.Arguments = cmd;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit();
        }

        public void SignFucking(string version)
        {
            string toolsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools");
            Directory.SetCurrentDirectory(toolsDir);

            string toBeSignedApk = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp/template/dist"))[0];
            string signedApk = Path.Combine(Path.GetDirectoryName(toBeSignedApk), Path.GetFileNameWithoutExtension(toBeSignedApk) + "_signed.apk");

            //string apkDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "apks", version);

            string apkDir = Path.Combine(this.textBox_NewPackagePath.Text, version);
            if (!Directory.Exists(apkDir))
            {
                Directory.CreateDirectory(apkDir);
            }

            string finalApk = Path.Combine(apkDir, label_CurrentGameName.Text);

            string cmd1 = string.Format("-jar signapk.jar testkey.x509.pem testkey.pk8 \"{0}\" \"{1}\"", toBeSignedApk, signedApk);
            //Process.Start("java", cmd1).WaitForExit();

            Process p1 = new Process();
            p1.StartInfo.FileName = "java";
            p1.StartInfo.Arguments = cmd1;
            p1.StartInfo.CreateNoWindow = true;
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p1.Start();
            p1.WaitForExit();


            string cmd2 = string.Format("-v 4 \"{0}\" \"{1}\"", signedApk, finalApk);
            //Process.Start("zipalign.exe", cmd2).WaitForExit();

            Process p2 = new Process();
            p2.StartInfo.FileName = "zipalign";
            p2.StartInfo.Arguments = cmd2;
            p2.StartInfo.CreateNoWindow = true;
            p2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p2.Start();
            p2.WaitForExit();
        }

        public void MoveFuckDoneFile(string filePath)
        {
            string dir = Path.Combine(Path.GetDirectoryName(filePath), "done");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.Move(filePath, Path.Combine(dir, Path.GetFileName(filePath)));
        }

        public void MoveFuckFailFile(string filePath)
        {
            string dir = Path.Combine(Path.GetDirectoryName(filePath), "fail");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.Move(filePath, Path.Combine(dir, Path.GetFileName(filePath)));
        }

        private async void button_Start_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(this.textBox_OldPackagePath.Text))
            {
                return;
            }

            foreach (var dir in Directory.GetDirectories(this.textBox_OldPackagePath.Text))
            {
                while (Directory.GetFiles(dir).Length > 0)
                {
                    string version = Path.GetFileName(dir);
                    //test
                    //version = "4.6.8";

                    string gameFile = Directory.GetFiles(dir)[0];

                    try
                    {

                        this.label_CurrentGameName.Text = Path.GetFileName(gameFile);

                        SetInfo("清理门户");
                        ClearTempDir();

                        SetInfo("复制模板");
                        CopyTemplateToTempDir(version);

                        //SetInfo("解压游戏");
                        //UnZipGamePacakge(gameFile);
                        SetInfo("反编译游戏");
                        await DecompileGame(gameFile);

                        SetInfo("复制Data文件");
                        OverWriteFuckingDataFile();

                        SetInfo("修改Manifest文件");
                        SyncManifestFile();

                        SetInfo("编译");
                        CompileFucking();

                        SetInfo("签名优化");
                        SignFucking(version);

                        SetInfo("移动文件");
                        MoveFuckDoneFile(gameFile);

                        SetInfo("成功");

                        CurrentSucCount = CurrentSucCount + 1;

                        SetInfo("延时3秒装逼");
                        await Task.Delay(TimeSpan.FromSeconds(3));
                    }
                    catch (Exception ex)
                    {
                        MoveFuckFailFile(gameFile);
                        CurrentFailCount = CurrentFailCount + 1;
                        SetInfo(ex.Message);
                    }
                }
            }

            MessageBox.Show("Done");
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            XmlHelper.SetAndroidManifest(@"E:\Work\WinFrom\AndroidGod\RePackage\bin\Debug\test\AndroidManifest_old.xml",
                @"E:\Work\WinFrom\AndroidGod\RePackage\bin\Debug\test\AndroidManifest_new.xml");
        }


    }
}
