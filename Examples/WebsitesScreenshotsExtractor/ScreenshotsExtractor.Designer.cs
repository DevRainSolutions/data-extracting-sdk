namespace Eol.Extracting.WebsiteScreenshotsExtractor
{
    partial class ScreenshotsExtractor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenshotsExtractor));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lStatusImage = new System.Windows.Forms.ToolStripSplitButton();
            this.lStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbScrollNeeded = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnShowMaskHelp = new System.Windows.Forms.LinkLabel();
            this.btnSaveMasks = new System.Windows.Forms.LinkLabel();
            this.tbMaskThumbnail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMaskSreenshots = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFolderPath = new System.Windows.Forms.TextBox();
            this.cbThumbnailSave = new System.Windows.Forms.CheckBox();
            this.cbScreenshotSave = new System.Windows.Forms.CheckBox();
            this.btnSelectFolder = new System.Windows.Forms.LinkLabel();
            this.btnCleanPath = new System.Windows.Forms.LinkLabel();
            this.cbAutomaticallySaveToFolder = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSetThumbSizeManually = new System.Windows.Forms.CheckBox();
            this.nThumbWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nThumbHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nWidth = new System.Windows.Forms.NumericUpDown();
            this.lWidth = new System.Windows.Forms.Label();
            this.nHeight = new System.Windows.Forms.NumericUpDown();
            this.lHeight = new System.Windows.Forms.Label();
            this.ddlDimensions = new System.Windows.Forms.ComboBox();
            this.rbSetManuallyImageSize = new System.Windows.Forms.RadioButton();
            this.rbUseStandardImageFormat = new System.Windows.Forms.RadioButton();
            this.rbUseDefaultImageSize = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.thumbBox = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExtractScreenshot = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.btnSelectSourceFile = new System.Windows.Forms.Button();
            this.cbWatermark = new System.Windows.Forms.CheckBox();
            this.tbWatermark = new System.Windows.Forms.TextBox();
            this.rbUrl = new System.Windows.Forms.RadioButton();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nThumbWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nThumbHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHeight)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thumbBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lStatusImage,
            this.lStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 676);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(717, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lStatusImage
            // 
            this.lStatusImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lStatusImage.Image = ((System.Drawing.Image)(resources.GetObject("lStatusImage.Image")));
            this.lStatusImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lStatusImage.Name = "lStatusImage";
            this.lStatusImage.Size = new System.Drawing.Size(32, 20);
            this.lStatusImage.Text = "toolStripSplitButton1";
            this.lStatusImage.ButtonClick += new System.EventHandler(this.lStatusImage_ButtonClick);
            // 
            // lStatus
            // 
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(125, 18);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(505, 20);
            this.tbUrl.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbFile);
            this.groupBox2.Controls.Add(this.rbUrl);
            this.groupBox2.Controls.Add(this.btnSelectSourceFile);
            this.groupBox2.Controls.Add(this.tbFile);
            this.groupBox2.Controls.Add(this.cbScrollNeeded);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.tbUrl);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(717, 272);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Settings";
            // 
            // cbScrollNeeded
            // 
            this.cbScrollNeeded.AutoSize = true;
            this.cbScrollNeeded.Location = new System.Drawing.Point(635, 21);
            this.cbScrollNeeded.Name = "cbScrollNeeded";
            this.cbScrollNeeded.Size = new System.Drawing.Size(58, 17);
            this.cbScrollNeeded.TabIndex = 54;
            this.cbScrollNeeded.Text = "Scroll?";
            this.cbScrollNeeded.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 193);
            this.panel1.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(250, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(461, 193);
            this.panel4.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbWatermark);
            this.groupBox5.Controls.Add(this.cbWatermark);
            this.groupBox5.Controls.Add(this.btnShowMaskHelp);
            this.groupBox5.Controls.Add(this.btnSaveMasks);
            this.groupBox5.Controls.Add(this.tbMaskThumbnail);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.tbMaskSreenshots);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.tbFolderPath);
            this.groupBox5.Controls.Add(this.cbThumbnailSave);
            this.groupBox5.Controls.Add(this.cbScreenshotSave);
            this.groupBox5.Controls.Add(this.btnSelectFolder);
            this.groupBox5.Controls.Add(this.btnCleanPath);
            this.groupBox5.Controls.Add(this.cbAutomaticallySaveToFolder);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(461, 193);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Save Settings";
            // 
            // btnShowMaskHelp
            // 
            this.btnShowMaskHelp.AutoSize = true;
            this.btnShowMaskHelp.Location = new System.Drawing.Point(383, 140);
            this.btnShowMaskHelp.Name = "btnShowMaskHelp";
            this.btnShowMaskHelp.Size = new System.Drawing.Size(57, 13);
            this.btnShowMaskHelp.TabIndex = 53;
            this.btnShowMaskHelp.TabStop = true;
            this.btnShowMaskHelp.Text = "What is it?";
            this.btnShowMaskHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnShowMaskHelp_LinkClicked);
            // 
            // btnSaveMasks
            // 
            this.btnSaveMasks.AutoSize = true;
            this.btnSaveMasks.Location = new System.Drawing.Point(383, 165);
            this.btnSaveMasks.Name = "btnSaveMasks";
            this.btnSaveMasks.Size = new System.Drawing.Size(66, 13);
            this.btnSaveMasks.TabIndex = 52;
            this.btnSaveMasks.TabStop = true;
            this.btnSaveMasks.Text = "Save Masks";
            this.btnSaveMasks.Visible = false;
            this.btnSaveMasks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSaveMasks_LinkClicked);
            // 
            // tbMaskThumbnail
            // 
            this.tbMaskThumbnail.Enabled = false;
            this.tbMaskThumbnail.Location = new System.Drawing.Point(168, 162);
            this.tbMaskThumbnail.Name = "tbMaskThumbnail";
            this.tbMaskThumbnail.Size = new System.Drawing.Size(209, 20);
            this.tbMaskThumbnail.TabIndex = 51;
            this.tbMaskThumbnail.Text = "{0}_{1}{2}{3}_{4}_thumb.jpg";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Thumbnails names mask:";
            // 
            // tbMaskSreenshots
            // 
            this.tbMaskSreenshots.Enabled = false;
            this.tbMaskSreenshots.Location = new System.Drawing.Point(168, 136);
            this.tbMaskSreenshots.Name = "tbMaskSreenshots";
            this.tbMaskSreenshots.Size = new System.Drawing.Size(209, 20);
            this.tbMaskSreenshots.TabIndex = 49;
            this.tbMaskSreenshots.Text = "{0}_{1}{2}{3}_{4}.jpg";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Screenshots names mask:";
            // 
            // tbFolderPath
            // 
            this.tbFolderPath.Enabled = false;
            this.tbFolderPath.Location = new System.Drawing.Point(19, 41);
            this.tbFolderPath.Name = "tbFolderPath";
            this.tbFolderPath.Size = new System.Drawing.Size(358, 20);
            this.tbFolderPath.TabIndex = 47;
            // 
            // cbThumbnailSave
            // 
            this.cbThumbnailSave.AutoSize = true;
            this.cbThumbnailSave.Checked = true;
            this.cbThumbnailSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbThumbnailSave.Location = new System.Drawing.Point(19, 102);
            this.cbThumbnailSave.Name = "cbThumbnailSave";
            this.cbThumbnailSave.Size = new System.Drawing.Size(104, 17);
            this.cbThumbnailSave.TabIndex = 46;
            this.cbThumbnailSave.Text = "Save thumbnails";
            this.cbThumbnailSave.UseVisualStyleBackColor = true;
            // 
            // cbScreenshotSave
            // 
            this.cbScreenshotSave.AutoSize = true;
            this.cbScreenshotSave.Checked = true;
            this.cbScreenshotSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbScreenshotSave.Location = new System.Drawing.Point(19, 79);
            this.cbScreenshotSave.Name = "cbScreenshotSave";
            this.cbScreenshotSave.Size = new System.Drawing.Size(111, 17);
            this.cbScreenshotSave.TabIndex = 45;
            this.cbScreenshotSave.Text = "Save scrennshots";
            this.cbScreenshotSave.UseVisualStyleBackColor = true;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.AutoSize = true;
            this.btnSelectFolder.Location = new System.Drawing.Point(383, 44);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(69, 13);
            this.btnSelectFolder.TabIndex = 43;
            this.btnSelectFolder.TabStop = true;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSelectFolder_LinkClicked);
            // 
            // btnCleanPath
            // 
            this.btnCleanPath.AutoSize = true;
            this.btnCleanPath.Location = new System.Drawing.Point(319, 21);
            this.btnCleanPath.Name = "btnCleanPath";
            this.btnCleanPath.Size = new System.Drawing.Size(59, 13);
            this.btnCleanPath.TabIndex = 44;
            this.btnCleanPath.TabStop = true;
            this.btnCleanPath.Text = "Clean Path";
            this.btnCleanPath.Visible = false;
            this.btnCleanPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCleanPath_LinkClicked);
            // 
            // cbAutomaticallySaveToFolder
            // 
            this.cbAutomaticallySaveToFolder.AutoSize = true;
            this.cbAutomaticallySaveToFolder.Location = new System.Drawing.Point(19, 20);
            this.cbAutomaticallySaveToFolder.Name = "cbAutomaticallySaveToFolder";
            this.cbAutomaticallySaveToFolder.Size = new System.Drawing.Size(178, 17);
            this.cbAutomaticallySaveToFolder.TabIndex = 42;
            this.cbAutomaticallySaveToFolder.Text = "Automatically Save All To Folder";
            this.cbAutomaticallySaveToFolder.UseVisualStyleBackColor = true;
            this.cbAutomaticallySaveToFolder.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 193);
            this.panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSetThumbSizeManually);
            this.groupBox1.Controls.Add(this.nThumbWidth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nThumbHeight);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nWidth);
            this.groupBox1.Controls.Add(this.lWidth);
            this.groupBox1.Controls.Add(this.nHeight);
            this.groupBox1.Controls.Add(this.lHeight);
            this.groupBox1.Controls.Add(this.ddlDimensions);
            this.groupBox1.Controls.Add(this.rbSetManuallyImageSize);
            this.groupBox1.Controls.Add(this.rbUseStandardImageFormat);
            this.groupBox1.Controls.Add(this.rbUseDefaultImageSize);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Image Size";
            // 
            // cbSetThumbSizeManually
            // 
            this.cbSetThumbSizeManually.AutoSize = true;
            this.cbSetThumbSizeManually.Location = new System.Drawing.Point(22, 139);
            this.cbSetThumbSizeManually.Name = "cbSetThumbSizeManually";
            this.cbSetThumbSizeManually.Size = new System.Drawing.Size(155, 17);
            this.cbSetThumbSizeManually.TabIndex = 47;
            this.cbSetThumbSizeManually.Text = "Set thumbnail size manually";
            this.cbSetThumbSizeManually.UseVisualStyleBackColor = true;
            this.cbSetThumbSizeManually.CheckedChanged += new System.EventHandler(this.cbSetThumbSizeManually_CheckedChanged);
            // 
            // nThumbWidth
            // 
            this.nThumbWidth.Enabled = false;
            this.nThumbWidth.Location = new System.Drawing.Point(65, 161);
            this.nThumbWidth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nThumbWidth.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nThumbWidth.Name = "nThumbWidth";
            this.nThumbWidth.Size = new System.Drawing.Size(59, 20);
            this.nThumbWidth.TabIndex = 55;
            this.nThumbWidth.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(22, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Width:";
            // 
            // nThumbHeight
            // 
            this.nThumbHeight.Enabled = false;
            this.nThumbHeight.Location = new System.Drawing.Point(181, 161);
            this.nThumbHeight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nThumbHeight.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nThumbHeight.Name = "nThumbHeight";
            this.nThumbHeight.Size = new System.Drawing.Size(59, 20);
            this.nThumbHeight.TabIndex = 57;
            this.nThumbHeight.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(132, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Height:";
            // 
            // nWidth
            // 
            this.nWidth.Enabled = false;
            this.nWidth.Location = new System.Drawing.Point(65, 113);
            this.nWidth.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nWidth.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nWidth.Name = "nWidth";
            this.nWidth.Size = new System.Drawing.Size(59, 20);
            this.nWidth.TabIndex = 50;
            this.nWidth.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // lWidth
            // 
            this.lWidth.AutoSize = true;
            this.lWidth.Enabled = false;
            this.lWidth.Location = new System.Drawing.Point(22, 117);
            this.lWidth.Name = "lWidth";
            this.lWidth.Size = new System.Drawing.Size(38, 13);
            this.lWidth.TabIndex = 51;
            this.lWidth.Text = "Width:";
            // 
            // nHeight
            // 
            this.nHeight.Enabled = false;
            this.nHeight.Location = new System.Drawing.Point(181, 113);
            this.nHeight.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nHeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nHeight.Name = "nHeight";
            this.nHeight.Size = new System.Drawing.Size(59, 20);
            this.nHeight.TabIndex = 52;
            this.nHeight.Value = new decimal(new int[] {
            768,
            0,
            0,
            0});
            // 
            // lHeight
            // 
            this.lHeight.AutoSize = true;
            this.lHeight.Enabled = false;
            this.lHeight.Location = new System.Drawing.Point(132, 117);
            this.lHeight.Name = "lHeight";
            this.lHeight.Size = new System.Drawing.Size(41, 13);
            this.lHeight.TabIndex = 53;
            this.lHeight.Text = "Height:";
            // 
            // ddlDimensions
            // 
            this.ddlDimensions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDimensions.Enabled = false;
            this.ddlDimensions.FormattingEnabled = true;
            this.ddlDimensions.Items.AddRange(new object[] {
            "QVGA - 320×240; standard for PocketPC and Smartphones",
            "VGA - 640×480 - 0,3 MP",
            "WVGA - 800×480;",
            "SVGA - 800×600",
            "WSVGA - 1024×600",
            "XGA - 1024×768",
            "XGA+ - 1152×864",
            "WXGA - 1280×768 - 0.98 МP",
            "SXGA - 1280×1024 - 1.3 MP",
            "WXGA+ - 1440×900 - 1.3 MP",
            "SXGA+ - 1400×1050 - 1.5 MP",
            "WSXGA - 1600×1024 - 1.6 MP",
            "WSXGA+ - 1680×1050 - 1.8 MP",
            "UXGA - 1600×1200 - 1.9 MP",
            "Full HD - 1920×1080",
            "WUXGA - 1920×1200 - 2.3 MP",
            "QXGA - 2048×1536 - 3.1 MP",
            "QWXGA - 2048×1152 - 2.4 MP"});
            this.ddlDimensions.Location = new System.Drawing.Point(22, 64);
            this.ddlDimensions.Name = "ddlDimensions";
            this.ddlDimensions.Size = new System.Drawing.Size(218, 21);
            this.ddlDimensions.TabIndex = 49;
            // 
            // rbSetManuallyImageSize
            // 
            this.rbSetManuallyImageSize.AutoSize = true;
            this.rbSetManuallyImageSize.Location = new System.Drawing.Point(22, 91);
            this.rbSetManuallyImageSize.Name = "rbSetManuallyImageSize";
            this.rbSetManuallyImageSize.Size = new System.Drawing.Size(161, 17);
            this.rbSetManuallyImageSize.TabIndex = 2;
            this.rbSetManuallyImageSize.Text = "Set screenshot size manually";
            this.rbSetManuallyImageSize.UseVisualStyleBackColor = true;
            this.rbSetManuallyImageSize.CheckedChanged += new System.EventHandler(this.rbSetManuallyImageSize_CheckedChanged);
            // 
            // rbUseStandardImageFormat
            // 
            this.rbUseStandardImageFormat.AutoSize = true;
            this.rbUseStandardImageFormat.Location = new System.Drawing.Point(22, 42);
            this.rbUseStandardImageFormat.Name = "rbUseStandardImageFormat";
            this.rbUseStandardImageFormat.Size = new System.Drawing.Size(176, 17);
            this.rbUseStandardImageFormat.TabIndex = 1;
            this.rbUseStandardImageFormat.Text = "Use one of the standard formats";
            this.rbUseStandardImageFormat.UseVisualStyleBackColor = true;
            this.rbUseStandardImageFormat.CheckedChanged += new System.EventHandler(this.rbUseStandardImageFormat_CheckedChanged);
            // 
            // rbUseDefaultImageSize
            // 
            this.rbUseDefaultImageSize.AutoSize = true;
            this.rbUseDefaultImageSize.Checked = true;
            this.rbUseDefaultImageSize.Location = new System.Drawing.Point(22, 19);
            this.rbUseDefaultImageSize.Name = "rbUseDefaultImageSize";
            this.rbUseDefaultImageSize.Size = new System.Drawing.Size(174, 17);
            this.rbUseDefaultImageSize.TabIndex = 0;
            this.rbUseDefaultImageSize.TabStop = true;
            this.rbUseDefaultImageSize.Text = "Automatic detection (by default)";
            this.rbUseDefaultImageSize.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.thumbBox);
            this.groupBox3.Controls.Add(this.pictureBox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 297);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(717, 379);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // thumbBox
            // 
            this.thumbBox.BackColor = System.Drawing.SystemColors.Control;
            this.thumbBox.Location = new System.Drawing.Point(2, 16);
            this.thumbBox.Name = "thumbBox";
            this.thumbBox.Size = new System.Drawing.Size(125, 125);
            this.thumbBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.thumbBox.TabIndex = 0;
            this.thumbBox.TabStop = false;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(3, 16);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(711, 360);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExtractScreenshot,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(717, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExtractScreenshot
            // 
            this.btnExtractScreenshot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExtractScreenshot.Image = ((System.Drawing.Image)(resources.GetObject("btnExtractScreenshot.Image")));
            this.btnExtractScreenshot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExtractScreenshot.Name = "btnExtractScreenshot";
            this.btnExtractScreenshot.Size = new System.Drawing.Size(23, 22);
            this.btnExtractScreenshot.Text = "Extract Screenshot";
            this.btnExtractScreenshot.Click += new System.EventHandler(this.btnExtractScreenshot_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbFile
            // 
            this.tbFile.Enabled = false;
            this.tbFile.Location = new System.Drawing.Point(125, 50);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(505, 20);
            this.tbFile.TabIndex = 56;
            this.tbFile.TextChanged += new System.EventHandler(this.tbFile_TextChanged);
            // 
            // btnSelectSourceFile
            // 
            this.btnSelectSourceFile.Enabled = false;
            this.btnSelectSourceFile.Location = new System.Drawing.Point(635, 48);
            this.btnSelectSourceFile.Name = "btnSelectSourceFile";
            this.btnSelectSourceFile.Size = new System.Drawing.Size(70, 23);
            this.btnSelectSourceFile.TabIndex = 57;
            this.btnSelectSourceFile.Text = "Select";
            this.btnSelectSourceFile.UseVisualStyleBackColor = true;
            this.btnSelectSourceFile.Click += new System.EventHandler(this.btnSelectSourceFile_Click);
            // 
            // cbWatermark
            // 
            this.cbWatermark.AutoSize = true;
            this.cbWatermark.Checked = true;
            this.cbWatermark.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWatermark.Enabled = false;
            this.cbWatermark.Location = new System.Drawing.Point(168, 79);
            this.cbWatermark.Name = "cbWatermark";
            this.cbWatermark.Size = new System.Drawing.Size(78, 17);
            this.cbWatermark.TabIndex = 55;
            this.cbWatermark.Text = "Watermark";
            this.cbWatermark.UseVisualStyleBackColor = true;
            this.cbWatermark.CheckedChanged += new System.EventHandler(this.cbWatermark_CheckedChanged);
            // 
            // tbWatermark
            // 
            this.tbWatermark.Enabled = false;
            this.tbWatermark.Location = new System.Drawing.Point(252, 77);
            this.tbWatermark.Name = "tbWatermark";
            this.tbWatermark.Size = new System.Drawing.Size(197, 20);
            this.tbWatermark.TabIndex = 56;
            this.tbWatermark.Text = "Screenshots Extractor";
            // 
            // rbUrl
            // 
            this.rbUrl.AutoSize = true;
            this.rbUrl.Checked = true;
            this.rbUrl.Location = new System.Drawing.Point(25, 21);
            this.rbUrl.Name = "rbUrl";
            this.rbUrl.Size = new System.Drawing.Size(65, 17);
            this.rbUrl.TabIndex = 58;
            this.rbUrl.TabStop = true;
            this.rbUrl.Text = "From url:";
            this.rbUrl.UseVisualStyleBackColor = true;
            this.rbUrl.CheckedChanged += new System.EventHandler(this.rbUrl_CheckedChanged);
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Location = new System.Drawing.Point(25, 51);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(67, 17);
            this.rbFile.TabIndex = 59;
            this.rbFile.Text = "From file:";
            this.rbFile.UseVisualStyleBackColor = true;
            this.rbFile.CheckedChanged += new System.EventHandler(this.rbFile_CheckedChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // ScreenshotsExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 698);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(725, 725);
            this.Name = "ScreenshotsExtractor";
            this.Text = "Websites Screenshots & Thumbnails Extractor v.1.1";
            this.Load += new System.EventHandler(this.ScreenshotsExtractor_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nThumbWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nThumbHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHeight)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.thumbBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox thumbBox;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.ToolStripStatusLabel lStatus;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSetManuallyImageSize;
        private System.Windows.Forms.RadioButton rbUseStandardImageFormat;
        private System.Windows.Forms.RadioButton rbUseDefaultImageSize;
        private System.Windows.Forms.ComboBox ddlDimensions;
        private System.Windows.Forms.NumericUpDown nWidth;
        private System.Windows.Forms.Label lWidth;
        private System.Windows.Forms.NumericUpDown nHeight;
        private System.Windows.Forms.Label lHeight;
        private System.Windows.Forms.NumericUpDown nThumbWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nThumbHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbAutomaticallySaveToFolder;
        private System.Windows.Forms.LinkLabel btnSelectFolder;
        private System.Windows.Forms.LinkLabel btnCleanPath;
        private System.Windows.Forms.CheckBox cbThumbnailSave;
        private System.Windows.Forms.CheckBox cbScreenshotSave;
        private System.Windows.Forms.CheckBox cbSetThumbSizeManually;
        private System.Windows.Forms.ToolStripSplitButton lStatusImage;
        private System.Windows.Forms.TextBox tbFolderPath;
        private System.Windows.Forms.ToolStripButton btnExtractScreenshot;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.LinkLabel btnSaveMasks;
        private System.Windows.Forms.TextBox tbMaskThumbnail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMaskSreenshots;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel btnShowMaskHelp;
        private System.Windows.Forms.CheckBox cbScrollNeeded;
        private System.Windows.Forms.Button btnSelectSourceFile;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.TextBox tbWatermark;
        private System.Windows.Forms.CheckBox cbWatermark;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.RadioButton rbUrl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

    }
}