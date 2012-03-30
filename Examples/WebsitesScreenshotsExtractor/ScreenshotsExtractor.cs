using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevRain.Data.Extracting;

namespace Eol.Extracting.WebsiteScreenshotsExtractor
{
    public partial class ScreenshotsExtractor : Form
    {
        private string FolderPath
        {
            get
            {
                return Settings.Default.FolderPath;
            }
            set
            {
                Settings.Default.FolderPath = value;
                Settings.Default.Save();
            }
        }

        public ScreenshotsExtractor()
        {
            InitializeComponent();

            this.btnSave.Image = Resources.Save;
            btnExtractScreenshot.Image = Resources.Extract;
            lStatusImage.Image = Resources.Info;
            lStatus.Text = "Set settings and click 'Extract Screenshot' button.";

            if (!string.IsNullOrEmpty(this.FolderPath))
            {
                tbFolderPath.Text = this.FolderPath;
                cbAutomaticallySaveToFolder.Checked = true;
            }
        }


        private void ScreenshotsExtractor_Load(object sender, EventArgs e)
        {
            ddlDimensions.SelectedIndex = 5;

            ContextMenu context = new ContextMenu();
            context.MenuItems.Add("Save Image", btnSave_Click);
            context.MenuItems.Add("Save Thumbnail", btnSaveThumbnail_Click);
            context.MenuItems.Add("Save All", SaveAll_Click);
            pictureBox.ContextMenu = context;

        }

        private void SaveAll_Click(object sender, EventArgs e)
        {

        }


        private void btnExtractScreenshot_Click(object sender, EventArgs e)
        {
            #region Check user input

            // Check if user enter the website url
            if (rbUrl.Checked && string.IsNullOrEmpty(tbUrl.Text))
            {
                lStatusImage.Image = Resources.Warning;
                lStatus.Text = "Website url can not be blank!";
                return;
            }

            if (rbFile.Checked && string.IsNullOrEmpty(tbFile.Text))

                if (cbAutomaticallySaveToFolder.Checked && string.IsNullOrEmpty(tbFolderPath.Text))
                {
                    lStatusImage.Image = Resources.Warning;
                    lStatus.Text = "Folder path can not be blank!";
                    return;
                }

            #endregion

            try
            {

                lStatusImage.Image = Resources.Loading;
                lStatus.Text = "Processing...";

                {


                    // From file checked
                    if (rbFile.Checked)
                    {
                        var urls = File.ReadAllLines(tbFile.Text);
                        foreach (var url in urls)
                        {
                            this.ExtractFromUrl(new Uri(url)).Save(tbFolderPath.Text + "1.jpg");
                        }
                    }

                    // if from url
                    if (rbUrl.Checked)
                    {
                        Bitmap image = this.ExtractFromUrl(new Uri(tbUrl.Text.Trim()));
                        pictureBox.Image = image;
                        thumbBox.Image = image.GetThumbnail((int)nThumbWidth.Value, (int)nThumbHeight.Value);
                    }
                }

                lStatusImage.Image = Resources.Completed;
                lStatus.Text = "Done!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lStatusImage.Image = Resources.Info;
                lStatus.Text = "Set settings and click 'Extract Screenshot' button.";
            }
        }

        private Bitmap ExtractFromUrl(Uri uri)
        {
            int width = -1;
            int height = -1;



            if (rbUseStandardImageFormat.Checked)
            {
                switch (ddlDimensions.SelectedIndex)
                {
                    case 0: width = 320; height = 240; break;
                    case 1: width = 640; height = 480; break;
                    case 2: width = 800; height = 480; break;
                    case 3: width = 800; height = 600; break;
                    case 4: width = 1024; height = 600; break;
                    case 5: width = 1024; height = 768; break;
                    case 6: width = 1152; height = 864; break;
                    case 7: width = 1280; height = 768; break;
                    case 8: width = 1280; height = 1024; break;
                    case 9: width = 1440; height = 900; break;
                    case 10: width = 1400; height = 1050; break;
                    case 11: width = 1600; height = 1024; break;
                    case 12: width = 1680; height = 1050; break;
                    case 13: width = 1600; height = 1200; break;
                    case 14: width = 1920; height = 1080; break;
                    case 15: width = 1920; height = 1200; break;
                    case 16: width = 2048; height = 1536; break;
                    case 17: width = 2048; height = 1152; break;
                    //case 18: width = 2560; height = 1600; break;
                    //case 19: width = 2560; height = 2048; break;
                    //case 20: width = 3200; height = 2048; break;
                    //case 21: width = 3200; height = 2400; break;
                    //case 22: width = 3840; height = 2400; break;
                    //case 23: width = 5120; height = 4096; break;
                    //case 24: width = 6400; height = 4096; break;
                    //case 25: width = 6400; height = 4800; break;
                    //case 26: width = 7680; height = 4800; break;

                }
            }

            if (rbSetManuallyImageSize.Checked)
            {
                width = (int)nWidth.Value;
                height = (int)nHeight.Value;
            }

            /*
                 
WQXGA - 2560×1600 - 4.1 MP
QSXGA - 2560×2048 - 5.2 MP
WQSXGA - 3200×2048 - 6.6 MP
QUXGA - 3200×2400 - 7.7 MP
WQUXGA - 3840×2400 - 9.2 MP
HSXGA - 5120×4096 - 21 MP
WHSXGA - 6400×4096 - 26 МP 
HUXGA - 6400×4800 - 31 МP
WHUXGA - 7680×4800 - 37 МP
            */

            int thumbWidth = 150;
            int thumbHeight = 150;

            if (cbSetThumbSizeManually.Checked)
            {
                thumbWidth = (int)nThumbWidth.Value;
                thumbHeight = (int)nThumbHeight.Value;
            }

            WebScreenshotExtractor web = new WebScreenshotExtractor(uri, width, height, cbScrollNeeded.Checked);
            return web.Image;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //openFileDialog.Filter = "*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image.Save(saveFileDialog.FileName);
                lStatusImage.Image = Resources.Completed;
                lStatus.Text = "Saved!";
            }
        }

        private void btnSaveThumbnail_Click(object sender, EventArgs e)
        {
            //  openFileDialog.Filter = "*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                thumbBox.Image.Save(saveFileDialog.FileName);
                lStatus.Text = "Saved!";
            }
        }

        private void btnSelectFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbFolderPath.Text = folderBrowserDialog.SelectedPath;
                this.FolderPath = tbFolderPath.Text;
            }
        }

        private void btnCleanPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.FolderPath = string.Empty;
            tbFolderPath.Text = this.FolderPath;
            cbAutomaticallySaveToFolder.Checked = false;
            lStatus.Text = "Folder path is cleaned!";
        }

        private void rbUseStandardImageFormat_CheckedChanged(object sender, EventArgs e)
        {
            ddlDimensions.Enabled = rbUseStandardImageFormat.Checked;
        }

        private void cbSetThumbSizeManually_CheckedChanged(object sender, EventArgs e)
        {
            nThumbWidth.Enabled = nThumbHeight.Enabled = cbSetThumbSizeManually.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tbFolderPath.Enabled = btnSelectFolder.Enabled = cbAutomaticallySaveToFolder.Checked;
            tbMaskSreenshots.Enabled = tbMaskThumbnail.Enabled = cbAutomaticallySaveToFolder.Checked;
        }

        private void rbSetManuallyImageSize_CheckedChanged(object sender, EventArgs e)
        {
            nWidth.Enabled = nHeight.Enabled = rbSetManuallyImageSize.Checked;
        }

        private void lStatusImage_ButtonClick(object sender, EventArgs e)
        {
            MessageBoxIcon icon = MessageBoxIcon.None;
            MessageBox.Show(lStatus.Text, "GrabData Screenshots Extractor", MessageBoxButtons.OK, icon);
        }



        private void btnShowMaskHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBoxIcon icon = MessageBoxIcon.Information;
            MessageBox.Show(
@"Use the following data:
{0} - website domain or 'PrintScreen' text
{1} - current year
{2} - current month
{3} - current day
{4} - current ticks

Do not change the masks' texts if you do not know how to use it!!!

Default mask for screenshot: {0}_{1}{2}{3}_{4}.jpg
Default mask for thumbnail: {0}_{1}{2}{3}_{4}_thumb.jpg

", "GrabData Screenshots Extractor", MessageBoxButtons.OK, icon);
        }

        private void btnSaveMasks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnSelectSourceFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbFile.Text = openFileDialog.FileName;
            }
        }

        private void cbWatermark_CheckedChanged(object sender, EventArgs e)
        {
            tbWatermark.Enabled = cbWatermark.Checked;
        }

        private void rbUrl_CheckedChanged(object sender, EventArgs e)
        {
            tbUrl.Enabled = rbUrl.Checked;
        }

        private void rbFile_CheckedChanged(object sender, EventArgs e)
        {
            tbFile.Enabled = rbFile.Checked;
            btnSelectSourceFile.Enabled = rbFile.Checked;
        }

        private void tbFile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

