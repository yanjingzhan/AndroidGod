using AndroidPackagePublisher.Models;
using AndroidPackagePublisher.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AndroidPackagePublisher
{
    public partial class AndriodPackagePublisherMainForm : Form
    {
        PushGameInfoModel _pushGameInfo;
        private void SetTipsInfo(string info)
        {
            this.label_Tips.Text = info;
        }

        private void SetStatusInfo(string info)
        {
            this.toolStripStatusLabel_Status.Text = DateTime.Now.ToString() + "----" + info;
        }

        private void SetStartButtonEnable()
        {
            this.button_Shot_GetNewGame.Enabled = true;
            this.button_DisableIt.Enabled = false;
            this.button_OpenPackageDir.Enabled = false;
            this.button_SubmitGameInfo.Enabled = false;
            this.button_DevAccountDie.Enabled = false;
            this.button_RePackage.Enabled = false;
            this.button_CopyKeyWords.Enabled = false;


            this.textBox_PackageDir.Clear();
            this.textBox_GameDetails.Clear();
            this.textBox_GameName.Clear();
            this.textBox_DevAccount.Clear();
            this.textBox_DevPassword.Clear();

            this.textBox_KeyWords1.Clear();
            this.textBox_KeyWords2.Clear();
            this.textBox_KeyWords3.Clear();
            this.textBox_KeyWords4.Clear();

            this.textBox_NewGameName.Clear();
        }

        private void SetDevelopingButtonEnable()
        {
            this.button_Shot_GetNewGame.Enabled = false;
            this.button_DisableIt.Enabled = true;
            this.button_OpenPackageDir.Enabled = true;
            this.button_SubmitGameInfo.Enabled = true;
            this.button_DevAccountDie.Enabled = true;
            this.button_RePackage.Enabled = true;
            this.button_CopyKeyWords.Enabled = true;
        }

        public AndriodPackagePublisherMainForm()
        {
            InitializeComponent();

            this.Load += AndriodPackagePublisherMainForm_Load;
        }

        void AndriodPackagePublisherMainForm_Load(object sender, EventArgs e)
        {
            SetStartButtonEnable();
            SetTipsInfo("请点击 获取新游戏打包 按钮");
        }

        private void ClearTempDir()
        {
            string tempDir = AppDomain.CurrentDomain.BaseDirectory + "temp";
            if (Directory.Exists(tempDir))
            {
                Directory.Delete(tempDir, true);
            }

            Directory.CreateDirectory(tempDir);

            string apkDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "安装包目录");

            if (Directory.Exists(apkDir))
            {
                foreach (var item in Directory.GetFiles(apkDir))
                {
                    File.Delete(item);
                }
            }
        }

        private void DeleteFrameworkAPk()
        {
            string apkPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                @"apktool\framework", "1.apk");

            if (File.Exists(apkPath))
            {
                File.Delete(apkPath);
            }
        }

        private async Task DecompileGame(string fileName)
        {
            string toolsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools");
            Directory.SetCurrentDirectory(toolsDir);

            string fileDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "android", Path.GetFileNameWithoutExtension(fileName));
            string filePath = Path.Combine(fileDir, fileName);

            string cmd1 = string.Format("d \"{0}\"", filePath);
            //Process.Start("apktool", cmd1).WaitForExit();
            Process p1 = new Process();
            p1.StartInfo.FileName = "apktool";
            p1.StartInfo.Arguments = cmd1;
            p1.StartInfo.CreateNoWindow = true;
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p1.Start();
            p1.WaitForExit();

            string unzipPackagePath = Path.Combine(toolsDir, Path.GetFileNameWithoutExtension(filePath));
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

        private void RepairYmlFile()
        {
            string tempDir = AppDomain.CurrentDomain.BaseDirectory + "temp";
            string ymlFile = Path.Combine(tempDir, "unzip\\apktool.yml");

            string content = File.ReadAllText(ymlFile);
            File.WriteAllText(ymlFile, content.Replace("- ''", ""));
        }

        private void DownloadIcon(string gameFileName, string logoUrl)
        {
            WebClient wc = new WebClient();
            string tempUnZipDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp", "unzip");

            string logoPath = Path.Combine(tempUnZipDir, "res\\drawable\\app_icon.png");
            wc.DownloadFile(logoUrl, logoPath);
        }

        private void SetAdmobAds(string bannerId, bool isBannerVisable, string chapingId, bool isChapingVisable)
        {
            string tempUnZipDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp", "unzip");
            string stringFile = Path.Combine(tempUnZipDir, "res\\values\\strings.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(stringFile);

            XmlElement rootElemt = doc.DocumentElement;

            foreach (XmlElement item in rootElemt.ChildNodes)
            {
                if (item.GetAttribute("name") == "banner_ad_unit_id")
                {
                    item.InnerText = bannerId;
                }

                if (item.GetAttribute("name") == "interstitial_ad_unit_id")
                {
                    item.InnerText = chapingId;
                }

                if (item.GetAttribute("name") == "googleBannerShow")
                {
                    item.InnerText = isBannerVisable ? "1" : "0";
                }

                if (item.GetAttribute("name") == "googleChaPingShow")
                {
                    item.InnerText = isChapingVisable ? "1" : "0";
                }
            }

            doc.Save(stringFile);
        }

        private void SetGameName(string gameName)
        {
            string tempUnZipDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp", "unzip");
            string stringFile = Path.Combine(tempUnZipDir, "res\\values\\strings.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(stringFile);

            XmlElement rootElemt = doc.DocumentElement;

            foreach (XmlElement item in rootElemt.ChildNodes)
            {
                if (item.GetAttribute("name") == "app_name")
                {
                    item.InnerText = gameName;
                    break;
                }
            }

            doc.Save(stringFile);
        }

        private void SetPackageName()
        {
            string tempUnZipDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp", "unzip");
            string manifestFile = Path.Combine(tempUnZipDir, "AndroidManifest.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(manifestFile);

            XmlElement rootElement = doc.DocumentElement;

            if (rootElement.GetAttribute("package") != null)
            {
                rootElement.SetAttribute("package", RandomHelper.GetPackageName());
            }

            doc.Save(manifestFile);
        }

        public void CompileFucking()
        {
            string toolsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools");
            Directory.SetCurrentDirectory(toolsDir);

            string cmd = string.Format("b ../temp/unzip");
            //Process.Start("apktool", cmd).WaitForExit();

            Process p = new Process();
            p.StartInfo.FileName = "apktool";
            p.StartInfo.Arguments = cmd;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit();
        }

        public void SignFucking(string fileName)
        {
            string toolsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools");
            Directory.SetCurrentDirectory(toolsDir);

            string toBeSignedApk = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp/unzip/dist"))[0];
            string signedApk = Path.Combine(Path.GetDirectoryName(toBeSignedApk), Path.GetFileNameWithoutExtension(toBeSignedApk) + "_signed.apk");

            //string apkDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "apks", version);

            string apkDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "安装包目录");
            if (!Directory.Exists(apkDir))
            {
                Directory.CreateDirectory(apkDir);
            }

            string finalApk = Path.Combine(apkDir, fileName);

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

        public void CopyPngFiles(string fileName)
        {
            string fileDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "android", Path.GetFileNameWithoutExtension(fileName));
            string apkDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "安装包目录");

            foreach (var item in Directory.GetFiles(fileDir, "*.png"))
            {
                File.Copy(item, Path.Combine(apkDir, Path.GetFileName(item)));
            }
        }

        public bool IsGameFileIn(string fileName)
        {
            string apkDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "安装包目录");
            return File.Exists(Path.Combine(apkDir, fileName));
        }

        public string GetKeyWords()
        {
            List<string> sList = HttpDataHelper.GetKeyWords(10);

            StringBuilder sb = new StringBuilder();

            foreach (var s in sList)
            {
                sb.Append(s);
                sb.Append(" ");
            }

            sb.Replace("  ", " ");

            return sb.ToString().Trim();
        }

        private async void button_Shot_GetNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                SetStatusInfo("正在执行……");

                //_pushGameInfo = HttpDataHelper.GetOneGameInfoAndChangeStateRandomForDev("安卓待提交", "安卓开发中");

                //test
                _pushGameInfo = new PushGameInfoModel
                {
                    FileName = "com.wulven.shadowera-3.1200_apkask.com.apk",
                    GameName = "Legend Shadow Era",
                    GameDetails = "ahusdnlfkmgthrjmfdf adoasdordafhth",
                    LogoPath = "http://gamemanager.pettostudio.net/resoures/wp/moniqi/Choplifter Thinking III L_logo.png",
                    RealDevAccount = "RealDevAccount",
                    RealDevPassword = "RealDevPassword"
                };

                this.textBox_GameDetails.Text = _pushGameInfo.GameDetails;
                this.textBox_GameName.Text = _pushGameInfo.GameName;
                this.textBox_DevAccount.Text = _pushGameInfo.RealDevAccount;
                this.textBox_DevPassword.Text = _pushGameInfo.RealDevPassword;

                SetStatusInfo("清理路径中……");
                ClearTempDir();

                SetStatusInfo("删除1.apk中……");
                DeleteFrameworkAPk();

                SetStatusInfo("反编译中……");
                await DecompileGame(_pushGameInfo.FileName);

                SetStatusInfo("yml文件修复中……");
                RepairYmlFile();

                SetStatusInfo("替换图标中……");
                DownloadIcon(_pushGameInfo.FileName, _pushGameInfo.LogoPath);

                SetStatusInfo("写入谷歌广告……");
                SetAdmobAds(_pushGameInfo.GoogleBanner, false, _pushGameInfo.GoogleChaping, true);

                SetStatusInfo("写入游戏名字……");
                SetGameName(_pushGameInfo.GameName);

                SetStatusInfo("修改包名……");
                SetPackageName();

                SetStatusInfo("编译中……");
                CompileFucking();

                SetStatusInfo("签名中……");
                SignFucking(_pushGameInfo.FileName);

                SetStatusInfo("复制截屏……");
                CopyPngFiles(_pushGameInfo.FileName);

                if (IsGameFileIn(_pushGameInfo.FileName))
                {
                    this.textBox_KeyWords.Text = GetKeyWords();

                    this.textBox_PackageDir.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "安装包目录"); SetDevelopingButtonEnable();

                    SetDevelopingButtonEnable();
                    SetTipsInfo("打包成功，请到 安装包目录 下的 apk 文件提交到商店，完成后点击 提交完成 按钮");
                    SetStatusInfo("打包成功.");
                }
                else
                {
                    throw new Exception(string.Format("没有打包成游戏文件！请重试或联系我！"));
                }
            }
            catch (Exception ex)
            {
                SetStatusInfo("打包游戏失败,\n" + ex.Message);
            }
        }

        private void button_CopyGameDetails_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_GameDetails.Text))
            {
                Clipboard.SetText(this.textBox_GameDetails.Text);
            }
        }

        private void button_CopyDevAccount_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_DevAccount.Text))
            {
                Clipboard.SetText(this.textBox_DevAccount.Text);
            }
        }

        private void button_CopyDevPassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_DevPassword.Text))
            {
                Clipboard.SetText(this.textBox_DevPassword.Text);
            }
        }

        private void button_CopyGameName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_GameName.Text))
            {
                Clipboard.SetText(this.textBox_GameName.Text);
            }
        }

        private void button_OpenPackageDir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_PackageDir.Text))
            {
                System.Diagnostics.Process.Start("explorer.exe", "\"" + this.textBox_PackageDir.Text + "\"");
            }
        }

        private void button_CopyKeyWords_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_GameName.Text))
            {
                Clipboard.SetText(this.textBox_KeyWords.Text);
            }
        }
    }
}
