using AndroidManager.Models;
using AndroidManager.Utility;
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

namespace AndroidManager
{
    public partial class MainForm : Form
    {
        DataGridViewRow _currentDataGridViewRow_MoNiQi = new DataGridViewRow();
        DataGridViewRow _currentDataGridViewRowDevAccount_MoNiQi = new DataGridViewRow();


        List<PushGameInfoModel> _pushGameInfoModelList_MoNiQi;
        List<WindowsDevAccounts> _windowsDevAccountList_MoNiQi;

        private string _currentLogo_MoNiQi;
        private string _currentBgImage_MoNiQi;

        public DataGridViewRow CurrentMoNiQiDataGridViewRow_MoNiQi
        {
            get { return _currentDataGridViewRow_MoNiQi; }
            set
            {

                if (_currentDataGridViewRow_MoNiQi != value)
                {
                    _currentDataGridViewRow_MoNiQi = value;

                    this.textBox_MoNiQi_GameName_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_GameName"].Value.ToString();
                    //this.textBox_MoNiQi_GameName_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_ADName"].Value.ToString();
                    this.comboBox_MoNiQi_State_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_State"].Value.ToString();

                    //this.textBox_MoNiQi_PubcenterAppID_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_PubcenterAppID"].Value.ToString();
                    //this.textBox_MoNiQi_PubcenterAdID_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_PubcenterAdID"].Value.ToString();
                    //this.textBox_MoNiQi_SurfaceAccountID_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_SurfaceAccountID"].Value.ToString();
                    //this.textBox_MoNiQi_SurfaceAdID_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_SurfaceAdID"].Value.ToString();
                    //this.textBox_MoNiQi_GoogleBanner_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_GoogleBanner"].Value.ToString();
                    //this.textBox_MoNiQi_GoogleChaping_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_GoogleChaping"].Value.ToString();

                    this.pictureBox_MoNiQi_Logo_Update.Image = null;

                    _currentBgImage_MoNiQi = string.Empty;
                    _currentLogo_MoNiQi = string.Empty;

                    GetSetScreenShot(Path.GetFileNameWithoutExtension(_currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_FileName"].Value.ToString()));
                }
            }
        }

        public DataGridViewRow CurrentDataGridViewRowDevAccount_MoNiQi
        {
            get { return _currentDataGridViewRowDevAccount_MoNiQi; }
            set
            {

                if (_currentDataGridViewRowDevAccount_MoNiQi != value)
                {
                    _currentDataGridViewRowDevAccount_MoNiQi = value;

                    this.textBox_MoNiQi_DevAccount_Update.Text = _currentDataGridViewRowDevAccount_MoNiQi.Cells["Column_MoNiQi_DevAccount"].Value.ToString().Trim();
                    this.textBox_MoNiQi_DevPassword_Update.Text = _currentDataGridViewRowDevAccount_MoNiQi.Cells["Column_MoNiQi_DevPassword"].Value.ToString().Trim();
                }
            }
        }

        private void GetSetScreenShot(string FixedGameName)
        {
            string romsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "android");

            string location = Path.Combine(romsPath, FixedGameName);
            this.textBox_MoNiQi_ScreenShotLocation.Text = location;

            this.label_MoNiQi_ScreenInfo.Text = string.Format("Sorry,{0},路径下没有截屏文件", location);
            this.pictureBox_MoNiQi_ScreenShot_1.Image = null;
            this.pictureBox_MoNiQi_ScreenShot_2.Image = null;
            this.pictureBox_MoNiQi_ScreenShot_3.Image = null;
            this.pictureBox_MoNiQi_ScreenShot_4.Image = null;

            List<string> imageList = new List<string>();
            List<PictureBox> pictureBoxList = new List<PictureBox>()
            {
                this.pictureBox_MoNiQi_ScreenShot_1,
                this.pictureBox_MoNiQi_ScreenShot_2,
                this.pictureBox_MoNiQi_ScreenShot_3,
                this.pictureBox_MoNiQi_ScreenShot_4
            };

            if (Directory.Exists(location))
            {
                foreach (var l in Directory.GetFiles(location))
                {
                    if (Path.GetExtension(l).ToLower() == ".png")
                    {
                        this.label_MoNiQi_ScreenInfo.Text = string.Empty;
                        imageList.Add(l);
                    }
                }
            }

            int lenth = Math.Min(imageList.Count, pictureBoxList.Count);

            for (int i = 0; i < lenth; i++)
            {
                pictureBoxList[i].ImageLocation = imageList[i];
            }
        }

        private void SetStatusInfo(string info)
        {
            this.toolStripStatusLabel_Status.Text = DateTime.Now.ToString() + "----" + info;
        }

        private void dataGridView_LiuMangAds_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_MoNiQi_GameList.SelectedCells.Count > 0)
            {
                int index_t = dataGridView_MoNiQi_GameList.SelectedCells[0].RowIndex;
                CurrentMoNiQiDataGridViewRow_MoNiQi = dataGridView_MoNiQi_GameList.Rows[index_t];
            }
        }

        private void dataGridView_MoNiQi_WinAccountsList_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_MoNiQi_WinAccountsList.SelectedCells.Count > 0)
            {
                int index_t = dataGridView_MoNiQi_WinAccountsList.SelectedCells[0].RowIndex;
                CurrentDataGridViewRowDevAccount_MoNiQi = dataGridView_MoNiQi_WinAccountsList.Rows[index_t];
            }
        }

        private void GetLiuLangAdsForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void GetLiuLangAdsForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (_pushGameInfoModelList_MoNiQi == null)
                {
                    return;
                }

                string[] ss = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (Path.GetExtension(ss[0]).ToLower() == ".png")
                {
                    using (FileStream fs = new FileStream(ss[0], FileMode.Open, FileAccess.Read))
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                        if (image.Width == 300 && image.Height == 300)
                        {
                            _currentLogo_MoNiQi = ss[0];
                            this.pictureBox_MoNiQi_Logo_Update.Image = new Bitmap(_currentLogo_MoNiQi);
                        }
                        else
                        {
                            //_currentBgImage_MoNiQi = ss[0];
                            //this.pictureBox_MoNiQi_BackImagePath_Update.Image = new Bitmap(_currentBgImage_MoNiQi);

                            SetStatusInfo("请选择300*300的Png图片作为Logo");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void pictureBox_MoNiQi_Logo_Update_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Png|*.png";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                    if (image.Width == 300 && image.Height == 300)
                    {
                        _currentLogo_MoNiQi = ofd.FileName;
                        this.pictureBox_MoNiQi_Logo_Update.Image = new Bitmap(_currentLogo_MoNiQi);
                    }
                    else
                    {
                        SetStatusInfo("请选择300*300的Png图片作为Logo");
                    }
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void button_MoNiQi_Search_Click(object sender, EventArgs e)
        {
            try
            {
                SetStatusInfo("正在获取……可能会比较慢,请稍候…………");

                dataGridView_MoNiQi_GameList.Rows.Clear();

                //_pushGameInfoModelList_MoNiQi = HttpDataHelper.GetGameList(this.textBox_MoNiQi_GameName.Text, this.comboBox_MoNiQi_State.Text, GlobalData.PusherName);

                _pushGameInfoModelList_MoNiQi = new List<PushGameInfoModel> { HttpDataHelper.GetOneGameInfoAndChangeStateRandom("安卓待申请", "安卓制作中") };

                if (_pushGameInfoModelList_MoNiQi == null || _pushGameInfoModelList_MoNiQi.Count == 0)
                {
                    SetStatusInfo("没有获取到游戏信息");
                    return;
                }


                for (int i = 0; i < _pushGameInfoModelList_MoNiQi.Count; i++)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = i + 1 });

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].ID });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].GameName });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].State });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].SurfaceAccountID });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].SurfaceAdID });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].GoogleBanner });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].GoogleChaping });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].PubcenterAppID });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].PubcenterAdID });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].AddTime });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].UpdateTime });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].SourceType });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].FileName });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].GameDetails });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].AdName });

                    dataGridView_MoNiQi_GameList.Rows.Add(dgvr);
                }

                dataGridView_MoNiQi_GameList.Columns[0].Width = 150;
                SetStatusInfo("获取成功");
            }
            catch (Exception ex)
            {
                SetStatusInfo("没有获取到游戏信息," + ex.Message);
            }
        }

        private void button_MoNiQi_Update_Click(object sender, EventArgs e)
        {
            if (!CheckIsAllFillIn())
            {
                SetStatusInfo("请将广告信息填写完毕，并将图标和背景图拖入！！！");
                return;
            }

            SetStatusInfo("开始提交");
            this.comboBox_MoNiQi_State_Update.Text = "安卓待提交";

            string tempDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");

            if (Directory.Exists(tempDir))
            {
                foreach (var item in Directory.GetFiles(tempDir))
                {
                    File.Delete(item);
                }
            }
            else
            {
                Directory.CreateDirectory(tempDir);
            }

            try
            {
                string bjImageUrl = string.Empty;

                string logoImageUrl = string.Empty;

                if (!string.IsNullOrWhiteSpace(_currentLogo_MoNiQi))
                {
                    //File.Copy(_currentLogo_MoNiQi, Path.Combine(tempDir, this.textBox_MoNiQi_GameName_Update.Text + "_logo.png"));
                    ImageHelper.MakeThumbnail(_currentLogo_MoNiQi, Path.Combine(tempDir,
                        Path.GetFileNameWithoutExtension(CurrentMoNiQiDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_FileName"].Value.ToString()) + "_logo.png"), 300, 300, "HW", "png");

                    HttpDataHelper.UploadImage(Path.Combine(tempDir,
                        Path.GetFileNameWithoutExtension(CurrentMoNiQiDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_FileName"].Value.ToString()) + "_logo.png"));
                    logoImageUrl = string.Format("http://gamemanager.pettostudio.net/resoures/wp/moniqi/{0}_logo.png",
                        Path.GetFileNameWithoutExtension(CurrentMoNiQiDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_FileName"].Value.ToString()));
                }

                HttpDataHelper.UpdatePushGameInfoByID(this.textBox_MoNiQi_GameName_Update.Text,
                                                      "", "",
                                                      "", "",
                                                      this.textBox_MoNiQi_GoogleBanner_Update.Text, this.textBox_MoNiQi_GoogleChaping_Update.Text,
                                                      logoImageUrl,
                                                      bjImageUrl,
                                                      _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_ID"].Value.ToString(), this.comboBox_MoNiQi_State_Update.Text,
                                                      "", "",
                                                      _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_SourceType"].Value.ToString());

                SetStatusInfo(string.Format("{0}更新成功", this.textBox_MoNiQi_GameName_Update.Text));

                CurrentMoNiQiDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_GameName"].Value = this.textBox_MoNiQi_GameName_Update.Text;
                CurrentMoNiQiDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_State"].Value = this.comboBox_MoNiQi_State_Update.Text;
                CurrentMoNiQiDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_GoogleBanner"].Value = this.textBox_MoNiQi_GoogleBanner_Update.Text;
                CurrentMoNiQiDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_GoogleChaping"].Value = this.textBox_MoNiQi_GoogleChaping_Update.Text;

                //UpdateDevAccountList();
                this.dataGridView_MoNiQi_GameList.Rows.Remove(_currentDataGridViewRow_MoNiQi);

                ClearTextBox();
                button_MoNiQi_Search_Click(sender, e);


            }
            catch (Exception ex)
            {
                SetStatusInfo("更新失败," + ex.Message);
            }
        }

        private bool CheckIsAllFillIn()
        {
            return (!string.IsNullOrWhiteSpace(this.textBox_MoNiQi_GameName_Update.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_MoNiQi_GoogleBanner_Update.Text) &&
                    !string.IsNullOrWhiteSpace(this.textBox_MoNiQi_GoogleChaping_Update.Text) &&
                //!string.IsNullOrWhiteSpace(this.textBox_MoNiQi_SurfaceAccountID_Update.Text) &&
                //!string.IsNullOrWhiteSpace(this.textBox_MoNiQi_SurfaceAdID_Update.Text) &&
                //!string.IsNullOrWhiteSpace(_currentBgImage_MoNiQi) &&
                    !string.IsNullOrWhiteSpace(_currentLogo_MoNiQi));
        }

        private void ClearTextBox()
        {
            this.textBox_MoNiQi_GoogleBanner_Update.Clear();
            this.textBox_MoNiQi_GoogleChaping_Update.Clear();

            this.pictureBox_MoNiQi_Logo_Update.Image = null;
        }

        private void button_MoNiQi_OpenScreenShotLocation_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "\"" + this.textBox_MoNiQi_ScreenShotLocation.Text + "\"");
        }
    }
}
