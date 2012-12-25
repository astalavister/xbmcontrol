namespace XBMControl
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.ilMediaType = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsControls = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPause = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsStop = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNext = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMute = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsXBMC = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSendMediaUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsShowScreenshot = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsXBMCrestart = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsXBMCreboot = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsXBMCshutdown = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsView = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsViewPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsViewMediaBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSeperatorFolders = new System.Windows.Forms.ToolStripSeparator();
            this.cmsSaveMedia = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSeperatorSaveSend = new System.Windows.Forms.ToolStripSeparator();
            this.cmsShow = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsConfigure = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pDetails = new System.Windows.Forms.Panel();
            this.pbThumbnail = new System.Windows.Forms.PictureBox();
            this.lTitle = new System.Windows.Forms.Label();
            this.lAlbumTitle = new System.Windows.Forms.Label();
            this.lArtist = new System.Windows.Forms.Label();
            this.lTitleTitle = new System.Windows.Forms.Label();
            this.lAlbum = new System.Windows.Forms.Label();
            this.lArtistTitle = new System.Windows.Forms.Label();
            this.pNowPlayingInfo = new System.Windows.Forms.Panel();
            this.pTime = new System.Windows.Forms.Panel();
            this.pLastFmButtons = new System.Windows.Forms.Panel();
            this.bLastFmHate = new System.Windows.Forms.Button();
            this.bLastFmLove = new System.Windows.Forms.Button();
            this.lTimePlayed = new System.Windows.Forms.Label();
            this.lArtistSong = new System.Windows.Forms.Label();
            this.pbMediaType = new System.Windows.Forms.PictureBox();
            this.lSamplerate = new System.Windows.Forms.Label();
            this.lSamplerateTitle = new System.Windows.Forms.Label();
            this.lBitrate = new System.Windows.Forms.Label();
            this.lBitrateTitle = new System.Windows.Forms.Label();
            this.pControls = new System.Windows.Forms.Panel();
            this.bNavigator = new System.Windows.Forms.Button();
            this.bPlaylist = new System.Windows.Forms.Button();
            this.bPartymode = new System.Windows.Forms.Button();
            this.bShuffle = new System.Windows.Forms.Button();
            this.bRepeat = new System.Windows.Forms.Button();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.bMute = new System.Windows.Forms.Button();
            this.bOpen = new System.Windows.Forms.Button();
            this.tbProgress = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bNext = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.bPause = new System.Windows.Forms.Button();
            this.bPlay = new System.Windows.Forms.Button();
            this.bPrevious = new System.Windows.Forms.Button();
            this.pToolbar = new System.Windows.Forms.Panel();
            this.lMainTitle = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbMinimize = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MainContextMenu.SuspendLayout();
            this.pDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).BeginInit();
            this.pNowPlayingInfo.SuspendLayout();
            this.pTime.SuspendLayout();
            this.pLastFmButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMediaType)).BeginInit();
            this.pControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // ilMediaType
            // 
            this.ilMediaType.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMediaType.ImageStream")));
            this.ilMediaType.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMediaType.Images.SetKeyName(0, "video-32x32.png");
            this.ilMediaType.Images.SetKeyName(1, "audio-cd-32x32.png");
            this.ilMediaType.Images.SetKeyName(2, "pictures-32x32.png");
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Click to open the XBMController";
            this.notifyIcon1.BalloonTipTitle = "XBMController";
            this.notifyIcon1.ContextMenuStrip = this.MainContextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "XBMControl";
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseUp);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // MainContextMenu
            // 
            this.MainContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsControls,
            this.cmsXBMC,
            this.cmsView,
            this.cmsSeperatorFolders,
            this.cmsSaveMedia,
            this.cmsSeperatorSaveSend,
            this.cmsShow,
            this.cmsHide,
            this.toolStripSeparator1,
            this.cmsConfigure,
            this.toolStripSeparator3,
            this.cmsExit});
            this.MainContextMenu.Name = "cmsNotifyIcon";
            this.MainContextMenu.Size = new System.Drawing.Size(153, 226);
            this.MainContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.MainContextMenu_Opening);
            // 
            // cmsControls
            // 
            this.cmsControls.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsPrevious,
            this.cmsPlay,
            this.cmsPause,
            this.cmsStop,
            this.cmsNext,
            this.cmsMute});
            this.cmsControls.Image = ((System.Drawing.Image)(resources.GetObject("cmsControls.Image")));
            this.cmsControls.Name = "cmsControls";
            this.cmsControls.Size = new System.Drawing.Size(152, 22);
            // 
            // cmsPrevious
            // 
            this.cmsPrevious.Image = ((System.Drawing.Image)(resources.GetObject("cmsPrevious.Image")));
            this.cmsPrevious.Name = "cmsPrevious";
            this.cmsPrevious.Size = new System.Drawing.Size(67, 22);
            this.cmsPrevious.Click += new System.EventHandler(this.cmsNotifyPrevious_Click);
            // 
            // cmsPlay
            // 
            this.cmsPlay.Image = ((System.Drawing.Image)(resources.GetObject("cmsPlay.Image")));
            this.cmsPlay.Name = "cmsPlay";
            this.cmsPlay.Size = new System.Drawing.Size(67, 22);
            this.cmsPlay.Click += new System.EventHandler(this.cmsNotifyPlay_Click);
            // 
            // cmsPause
            // 
            this.cmsPause.Image = ((System.Drawing.Image)(resources.GetObject("cmsPause.Image")));
            this.cmsPause.Name = "cmsPause";
            this.cmsPause.Size = new System.Drawing.Size(67, 22);
            this.cmsPause.Click += new System.EventHandler(this.cmsNotifyPause_Click);
            // 
            // cmsStop
            // 
            this.cmsStop.Image = ((System.Drawing.Image)(resources.GetObject("cmsStop.Image")));
            this.cmsStop.Name = "cmsStop";
            this.cmsStop.Size = new System.Drawing.Size(67, 22);
            this.cmsStop.Click += new System.EventHandler(this.cmsNotifyStop_Click);
            // 
            // cmsNext
            // 
            this.cmsNext.Image = ((System.Drawing.Image)(resources.GetObject("cmsNext.Image")));
            this.cmsNext.Name = "cmsNext";
            this.cmsNext.Size = new System.Drawing.Size(67, 22);
            this.cmsNext.Click += new System.EventHandler(this.cmsNotifyNext_Click);
            // 
            // cmsMute
            // 
            this.cmsMute.Image = ((System.Drawing.Image)(resources.GetObject("cmsMute.Image")));
            this.cmsMute.Name = "cmsMute";
            this.cmsMute.Size = new System.Drawing.Size(67, 22);
            this.cmsMute.Click += new System.EventHandler(this.cmsNotifyMute_Click);
            // 
            // cmsXBMC
            // 
            this.cmsXBMC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsSendMediaUrl,
            this.cmsShowScreenshot,
            this.toolStripSeparator4,
            this.cmsXBMCrestart,
            this.cmsXBMCreboot,
            this.cmsXBMCshutdown});
            this.cmsXBMC.Image = ((System.Drawing.Image)(resources.GetObject("cmsXBMC.Image")));
            this.cmsXBMC.Name = "cmsXBMC";
            this.cmsXBMC.Size = new System.Drawing.Size(152, 22);
            // 
            // cmsSendMediaUrl
            // 
            this.cmsSendMediaUrl.Image = ((System.Drawing.Image)(resources.GetObject("cmsSendMediaUrl.Image")));
            this.cmsSendMediaUrl.Name = "cmsSendMediaUrl";
            this.cmsSendMediaUrl.Size = new System.Drawing.Size(67, 22);
            this.cmsSendMediaUrl.Click += new System.EventHandler(this.cmsSendMediaUrl_Click);
            // 
            // cmsShowScreenshot
            // 
            this.cmsShowScreenshot.Image = ((System.Drawing.Image)(resources.GetObject("cmsShowScreenshot.Image")));
            this.cmsShowScreenshot.Name = "cmsShowScreenshot";
            this.cmsShowScreenshot.Size = new System.Drawing.Size(67, 22);
            this.cmsShowScreenshot.Click += new System.EventHandler(this.cmsShowScreenshot_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(64, 6);
            // 
            // cmsXBMCrestart
            // 
            this.cmsXBMCrestart.Image = ((System.Drawing.Image)(resources.GetObject("cmsXBMCrestart.Image")));
            this.cmsXBMCrestart.Name = "cmsXBMCrestart";
            this.cmsXBMCrestart.Size = new System.Drawing.Size(67, 22);
            this.cmsXBMCrestart.Click += new System.EventHandler(this.cmsXBMCrebootXBMC_Click);
            // 
            // cmsXBMCreboot
            // 
            this.cmsXBMCreboot.Image = ((System.Drawing.Image)(resources.GetObject("cmsXBMCreboot.Image")));
            this.cmsXBMCreboot.Name = "cmsXBMCreboot";
            this.cmsXBMCreboot.Size = new System.Drawing.Size(67, 22);
            this.cmsXBMCreboot.Click += new System.EventHandler(this.cmsXBMCrebootComputer_Click);
            // 
            // cmsXBMCshutdown
            // 
            this.cmsXBMCshutdown.Image = ((System.Drawing.Image)(resources.GetObject("cmsXBMCshutdown.Image")));
            this.cmsXBMCshutdown.Name = "cmsXBMCshutdown";
            this.cmsXBMCshutdown.Size = new System.Drawing.Size(67, 22);
            this.cmsXBMCshutdown.Click += new System.EventHandler(this.cmsXBMCshutdown_Click);
            // 
            // cmsView
            // 
            this.cmsView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsViewPlaylist,
            this.cmsViewMediaBrowser});
            this.cmsView.Image = ((System.Drawing.Image)(resources.GetObject("cmsView.Image")));
            this.cmsView.Name = "cmsView";
            this.cmsView.Size = new System.Drawing.Size(152, 22);
            // 
            // cmsViewPlaylist
            // 
            this.cmsViewPlaylist.Name = "cmsViewPlaylist";
            this.cmsViewPlaylist.Size = new System.Drawing.Size(152, 22);
            this.cmsViewPlaylist.Click += new System.EventHandler(this.cmsViewPlaylist_Click);
            // 
            // cmsViewMediaBrowser
            // 
            this.cmsViewMediaBrowser.Name = "cmsViewMediaBrowser";
            this.cmsViewMediaBrowser.Size = new System.Drawing.Size(152, 22);
            this.cmsViewMediaBrowser.Click += new System.EventHandler(this.cmsViewMediaBrowser_Click);
            // 
            // cmsSeperatorFolders
            // 
            this.cmsSeperatorFolders.Name = "cmsSeperatorFolders";
            this.cmsSeperatorFolders.Size = new System.Drawing.Size(149, 6);
            // 
            // cmsSaveMedia
            // 
            this.cmsSaveMedia.Image = ((System.Drawing.Image)(resources.GetObject("cmsSaveMedia.Image")));
            this.cmsSaveMedia.Name = "cmsSaveMedia";
            this.cmsSaveMedia.Size = new System.Drawing.Size(152, 22);
            this.cmsSaveMedia.Visible = false;
            this.cmsSaveMedia.Click += new System.EventHandler(this.cmsSaveMedia_Click);
            // 
            // cmsSeperatorSaveSend
            // 
            this.cmsSeperatorSaveSend.Name = "cmsSeperatorSaveSend";
            this.cmsSeperatorSaveSend.Size = new System.Drawing.Size(149, 6);
            this.cmsSeperatorSaveSend.Visible = false;
            // 
            // cmsShow
            // 
            this.cmsShow.Image = ((System.Drawing.Image)(resources.GetObject("cmsShow.Image")));
            this.cmsShow.Name = "cmsShow";
            this.cmsShow.Size = new System.Drawing.Size(152, 22);
            this.cmsShow.Click += new System.EventHandler(this.cmsNotifyShow_Click);
            // 
            // cmsHide
            // 
            this.cmsHide.Image = ((System.Drawing.Image)(resources.GetObject("cmsHide.Image")));
            this.cmsHide.Name = "cmsHide";
            this.cmsHide.Size = new System.Drawing.Size(152, 22);
            this.cmsHide.Click += new System.EventHandler(this.cmsNotifyHide_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // cmsConfigure
            // 
            this.cmsConfigure.Image = ((System.Drawing.Image)(resources.GetObject("cmsConfigure.Image")));
            this.cmsConfigure.Name = "cmsConfigure";
            this.cmsConfigure.Size = new System.Drawing.Size(152, 22);
            this.cmsConfigure.Click += new System.EventHandler(this.cmsConfigure_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // cmsExit
            // 
            this.cmsExit.Image = ((System.Drawing.Image)(resources.GetObject("cmsExit.Image")));
            this.cmsExit.Name = "cmsExit";
            this.cmsExit.Size = new System.Drawing.Size(152, 22);
            this.cmsExit.Click += new System.EventHandler(this.cmsNotifyExit_Click);
            // 
            // pDetails
            // 
            this.pDetails.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pDetails.BackColor = System.Drawing.Color.Transparent;
            this.pDetails.BackgroundImage = global::XBMControl.Properties.Resources.background_details3;
            this.pDetails.Controls.Add(this.pbThumbnail);
            this.pDetails.Controls.Add(this.lTitle);
            this.pDetails.Controls.Add(this.lAlbumTitle);
            this.pDetails.Controls.Add(this.lArtist);
            this.pDetails.Controls.Add(this.lTitleTitle);
            this.pDetails.Controls.Add(this.lAlbum);
            this.pDetails.Controls.Add(this.lArtistTitle);
            this.pDetails.Location = new System.Drawing.Point(2, 79);
            this.pDetails.Name = "pDetails";
            this.pDetails.Size = new System.Drawing.Size(264, 54);
            this.pDetails.TabIndex = 18;
            // 
            // pbThumbnail
            // 
            this.pbThumbnail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbThumbnail.Cursor = System.Windows.Forms.Cursors.Help;
            this.pbThumbnail.ErrorImage = null;
            this.pbThumbnail.Image = ((System.Drawing.Image)(resources.GetObject("pbThumbnail.Image")));
            this.pbThumbnail.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbThumbnail.InitialImage")));
            this.pbThumbnail.Location = new System.Drawing.Point(212, 1);
            this.pbThumbnail.Name = "pbThumbnail";
            this.pbThumbnail.Size = new System.Drawing.Size(52, 52);
            this.pbThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThumbnail.TabIndex = 39;
            this.pbThumbnail.TabStop = false;
            this.toolTip1.SetToolTip(this.pbThumbnail, "Click to show full size cover art");
            this.pbThumbnail.MouseLeave += new System.EventHandler(this.pbThumbnail_MouseLeave);
            this.pbThumbnail.Click += new System.EventHandler(this.pbThumbnail_Click);
            this.pbThumbnail.MouseEnter += new System.EventHandler(this.pbThumbnail_MouseHover);
            // 
            // lTitle
            // 
            this.lTitle.BackColor = System.Drawing.Color.Transparent;
            this.lTitle.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.lTitle.Location = new System.Drawing.Point(43, 19);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(171, 13);
            this.lTitle.TabIndex = 38;
            // 
            // lAlbumTitle
            // 
            this.lAlbumTitle.BackColor = System.Drawing.Color.Transparent;
            this.lAlbumTitle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lAlbumTitle.ForeColor = System.Drawing.Color.Silver;
            this.lAlbumTitle.Location = new System.Drawing.Point(2, 32);
            this.lAlbumTitle.Name = "lAlbumTitle";
            this.lAlbumTitle.Size = new System.Drawing.Size(44, 13);
            this.lAlbumTitle.TabIndex = 35;
            this.lAlbumTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lArtist
            // 
            this.lArtist.BackColor = System.Drawing.Color.Transparent;
            this.lArtist.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.lArtist.Location = new System.Drawing.Point(43, 6);
            this.lArtist.Name = "lArtist";
            this.lArtist.Size = new System.Drawing.Size(171, 13);
            this.lArtist.TabIndex = 37;
            // 
            // lTitleTitle
            // 
            this.lTitleTitle.BackColor = System.Drawing.Color.Transparent;
            this.lTitleTitle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lTitleTitle.ForeColor = System.Drawing.Color.Silver;
            this.lTitleTitle.Location = new System.Drawing.Point(2, 19);
            this.lTitleTitle.Name = "lTitleTitle";
            this.lTitleTitle.Size = new System.Drawing.Size(44, 13);
            this.lTitleTitle.TabIndex = 34;
            this.lTitleTitle.Tag = "";
            this.lTitleTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lAlbum
            // 
            this.lAlbum.BackColor = System.Drawing.Color.Transparent;
            this.lAlbum.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lAlbum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.lAlbum.Location = new System.Drawing.Point(43, 32);
            this.lAlbum.Name = "lAlbum";
            this.lAlbum.Size = new System.Drawing.Size(170, 13);
            this.lAlbum.TabIndex = 36;
            // 
            // lArtistTitle
            // 
            this.lArtistTitle.BackColor = System.Drawing.Color.Transparent;
            this.lArtistTitle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lArtistTitle.ForeColor = System.Drawing.Color.Silver;
            this.lArtistTitle.Location = new System.Drawing.Point(2, 6);
            this.lArtistTitle.Name = "lArtistTitle";
            this.lArtistTitle.Size = new System.Drawing.Size(44, 13);
            this.lArtistTitle.TabIndex = 33;
            this.lArtistTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pNowPlayingInfo
            // 
            this.pNowPlayingInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pNowPlayingInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(245)))), ((int)(((byte)(242)))));
            this.pNowPlayingInfo.Controls.Add(this.pTime);
            this.pNowPlayingInfo.Controls.Add(this.lArtistSong);
            this.pNowPlayingInfo.Controls.Add(this.pbMediaType);
            this.pNowPlayingInfo.Controls.Add(this.lSamplerate);
            this.pNowPlayingInfo.Controls.Add(this.lSamplerateTitle);
            this.pNowPlayingInfo.Controls.Add(this.lBitrate);
            this.pNowPlayingInfo.Controls.Add(this.lBitrateTitle);
            this.pNowPlayingInfo.Location = new System.Drawing.Point(2, 22);
            this.pNowPlayingInfo.Name = "pNowPlayingInfo";
            this.pNowPlayingInfo.Size = new System.Drawing.Size(264, 57);
            this.pNowPlayingInfo.TabIndex = 21;
            // 
            // pTime
            // 
            this.pTime.BackgroundImage = global::XBMControl.Properties.Resources.background_pTime1;
            this.pTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pTime.Controls.Add(this.pLastFmButtons);
            this.pTime.Controls.Add(this.lTimePlayed);
            this.pTime.Location = new System.Drawing.Point(4, 0);
            this.pTime.Name = "pTime";
            this.pTime.Size = new System.Drawing.Size(173, 31);
            this.pTime.TabIndex = 8;
            // 
            // pLastFmButtons
            // 
            this.pLastFmButtons.BackColor = System.Drawing.Color.Transparent;
            this.pLastFmButtons.Controls.Add(this.bLastFmHate);
            this.pLastFmButtons.Controls.Add(this.bLastFmLove);
            this.pLastFmButtons.ForeColor = System.Drawing.Color.Transparent;
            this.pLastFmButtons.Location = new System.Drawing.Point(161, 1);
            this.pLastFmButtons.Name = "pLastFmButtons";
            this.pLastFmButtons.Size = new System.Drawing.Size(11, 29);
            this.pLastFmButtons.TabIndex = 22;
            this.pLastFmButtons.Visible = false;
            // 
            // bLastFmHate
            // 
            this.bLastFmHate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bLastFmHate.BackColor = System.Drawing.Color.Transparent;
            this.bLastFmHate.BackgroundImage = global::XBMControl.Properties.Resources.lastfm_hate5;
            this.bLastFmHate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bLastFmHate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLastFmHate.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.bLastFmHate.FlatAppearance.BorderSize = 0;
            this.bLastFmHate.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bLastFmHate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bLastFmHate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bLastFmHate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLastFmHate.ForeColor = System.Drawing.Color.Transparent;
            this.bLastFmHate.Location = new System.Drawing.Point(1, 3);
            this.bLastFmHate.Name = "bLastFmHate";
            this.bLastFmHate.Size = new System.Drawing.Size(9, 9);
            this.bLastFmHate.TabIndex = 22;
            this.toolTip1.SetToolTip(this.bLastFmHate, "Ban track on Last.FM");
            this.bLastFmHate.UseVisualStyleBackColor = false;
            this.bLastFmHate.Click += new System.EventHandler(this.bLastFmHate_Click_1);
            // 
            // bLastFmLove
            // 
            this.bLastFmLove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bLastFmLove.BackColor = System.Drawing.Color.Transparent;
            this.bLastFmLove.BackgroundImage = global::XBMControl.Properties.Resources.lastfm_love1;
            this.bLastFmLove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bLastFmLove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLastFmLove.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.bLastFmLove.FlatAppearance.BorderSize = 0;
            this.bLastFmLove.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bLastFmLove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bLastFmLove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bLastFmLove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLastFmLove.ForeColor = System.Drawing.Color.Transparent;
            this.bLastFmLove.Location = new System.Drawing.Point(1, 18);
            this.bLastFmLove.Name = "bLastFmLove";
            this.bLastFmLove.Size = new System.Drawing.Size(9, 9);
            this.bLastFmLove.TabIndex = 23;
            this.toolTip1.SetToolTip(this.bLastFmLove, "Love track on Last.FM");
            this.bLastFmLove.UseVisualStyleBackColor = false;
            this.bLastFmLove.Click += new System.EventHandler(this.bLastFmLove_Click_1);
            // 
            // lTimePlayed
            // 
            this.lTimePlayed.BackColor = System.Drawing.Color.Transparent;
            this.lTimePlayed.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTimePlayed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.lTimePlayed.Location = new System.Drawing.Point(0, 0);
            this.lTimePlayed.Name = "lTimePlayed";
            this.lTimePlayed.Size = new System.Drawing.Size(156, 27);
            this.lTimePlayed.TabIndex = 1;
            // 
            // lArtistSong
            // 
            this.lArtistSong.BackColor = System.Drawing.Color.Transparent;
            this.lArtistSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lArtistSong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lArtistSong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.lArtistSong.Location = new System.Drawing.Point(2, 37);
            this.lArtistSong.Margin = new System.Windows.Forms.Padding(0);
            this.lArtistSong.Name = "lArtistSong";
            this.lArtistSong.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lArtistSong.Size = new System.Drawing.Size(259, 19);
            this.lArtistSong.TabIndex = 7;
            this.lArtistSong.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.lArtistSong, "Click to show now playing media details");
            this.lArtistSong.Click += new System.EventHandler(this.lArtistSong_Click);
            // 
            // pbMediaType
            // 
            this.pbMediaType.Location = new System.Drawing.Point(231, -1);
            this.pbMediaType.Name = "pbMediaType";
            this.pbMediaType.Size = new System.Drawing.Size(32, 32);
            this.pbMediaType.TabIndex = 6;
            this.pbMediaType.TabStop = false;
            this.toolTip1.SetToolTip(this.pbMediaType, "Currently playing media type");
            this.pbMediaType.Visible = false;
            this.pbMediaType.Click += new System.EventHandler(this.pbMediaType_Click);
            // 
            // lSamplerate
            // 
            this.lSamplerate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lSamplerate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.lSamplerate.Location = new System.Drawing.Point(180, 14);
            this.lSamplerate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lSamplerate.Name = "lSamplerate";
            this.lSamplerate.Size = new System.Drawing.Size(23, 10);
            this.lSamplerate.TabIndex = 4;
            this.lSamplerate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lSamplerateTitle
            // 
            this.lSamplerateTitle.AutoSize = true;
            this.lSamplerateTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lSamplerateTitle.ForeColor = System.Drawing.Color.Silver;
            this.lSamplerateTitle.Location = new System.Drawing.Point(206, 14);
            this.lSamplerateTitle.Name = "lSamplerateTitle";
            this.lSamplerateTitle.Size = new System.Drawing.Size(19, 11);
            this.lSamplerateTitle.TabIndex = 3;
            this.lSamplerateTitle.Text = "khz";
            // 
            // lBitrate
            // 
            this.lBitrate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lBitrate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.lBitrate.Location = new System.Drawing.Point(179, 4);
            this.lBitrate.Margin = new System.Windows.Forms.Padding(0);
            this.lBitrate.Name = "lBitrate";
            this.lBitrate.Size = new System.Drawing.Size(25, 10);
            this.lBitrate.TabIndex = 2;
            this.lBitrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lBitrateTitle
            // 
            this.lBitrateTitle.AutoSize = true;
            this.lBitrateTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lBitrateTitle.ForeColor = System.Drawing.Color.Silver;
            this.lBitrateTitle.Location = new System.Drawing.Point(206, 3);
            this.lBitrateTitle.Name = "lBitrateTitle";
            this.lBitrateTitle.Size = new System.Drawing.Size(24, 11);
            this.lBitrateTitle.TabIndex = 1;
            this.lBitrateTitle.Text = "kbps";
            // 
            // pControls
            // 
            this.pControls.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(245)))), ((int)(((byte)(242)))));
            this.pControls.BackgroundImage = global::XBMControl.Properties.Resources.background_controls2;
            this.pControls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pControls.Controls.Add(this.bNavigator);
            this.pControls.Controls.Add(this.bPlaylist);
            this.pControls.Controls.Add(this.bPartymode);
            this.pControls.Controls.Add(this.bShuffle);
            this.pControls.Controls.Add(this.bRepeat);
            this.pControls.Controls.Add(this.tbVolume);
            this.pControls.Controls.Add(this.bMute);
            this.pControls.Controls.Add(this.bOpen);
            this.pControls.Controls.Add(this.tbProgress);
            this.pControls.Controls.Add(this.pictureBox1);
            this.pControls.Controls.Add(this.bNext);
            this.pControls.Controls.Add(this.bStop);
            this.pControls.Controls.Add(this.bPause);
            this.pControls.Controls.Add(this.bPlay);
            this.pControls.Controls.Add(this.bPrevious);
            this.pControls.Location = new System.Drawing.Point(1, 133);
            this.pControls.Name = "pControls";
            this.pControls.Size = new System.Drawing.Size(266, 50);
            this.pControls.TabIndex = 16;
            // 
            // bNavigator
            // 
            this.bNavigator.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bNavigator.BackColor = System.Drawing.Color.Transparent;
            this.bNavigator.BackgroundImage = global::XBMControl.Properties.Resources.button_remote;
            this.bNavigator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bNavigator.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.bNavigator.FlatAppearance.BorderSize = 0;
            this.bNavigator.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bNavigator.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bNavigator.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bNavigator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNavigator.ForeColor = System.Drawing.Color.Transparent;
            this.bNavigator.Location = new System.Drawing.Point(239, 22);
            this.bNavigator.Name = "bNavigator";
            this.bNavigator.Size = new System.Drawing.Size(16, 15);
            this.bNavigator.TabIndex = 28;
            this.toolTip1.SetToolTip(this.bNavigator, "Show Navigator Control");
            this.bNavigator.UseVisualStyleBackColor = false;
            this.bNavigator.MouseLeave += new System.EventHandler(this.bNavigator_MouseLeave);
            this.bNavigator.Click += new System.EventHandler(this.bNavigator_Click);
            this.bNavigator.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bNavigator_MouseDown);
            this.bNavigator.MouseHover += new System.EventHandler(this.bNavigator_MouseHover);
            this.bNavigator.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bNavigator_MouseUp);
            // 
            // bPlaylist
            // 
            this.bPlaylist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bPlaylist.BackColor = System.Drawing.Color.Transparent;
            this.bPlaylist.BackgroundImage = global::XBMControl.Properties.Resources.button_playlist;
            this.bPlaylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPlaylist.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.bPlaylist.FlatAppearance.BorderSize = 0;
            this.bPlaylist.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bPlaylist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bPlaylist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPlaylist.ForeColor = System.Drawing.Color.Transparent;
            this.bPlaylist.Location = new System.Drawing.Point(221, 22);
            this.bPlaylist.Name = "bPlaylist";
            this.bPlaylist.Size = new System.Drawing.Size(16, 15);
            this.bPlaylist.TabIndex = 26;
            this.toolTip1.SetToolTip(this.bPlaylist, "Show Playlist");
            this.bPlaylist.UseVisualStyleBackColor = false;
            this.bPlaylist.MouseLeave += new System.EventHandler(this.bPlaylist_MouseLeave);
            this.bPlaylist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bPlaylist_MouseDown);
            this.bPlaylist.MouseHover += new System.EventHandler(this.bPlaylist_MouseHover);
            this.bPlaylist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bPlaylist_MouseUp);
            // 
            // bPartymode
            // 
            this.bPartymode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bPartymode.BackColor = System.Drawing.Color.Transparent;
            this.bPartymode.BackgroundImage = global::XBMControl.Properties.Resources.button_partymode;
            this.bPartymode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPartymode.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.bPartymode.FlatAppearance.BorderSize = 0;
            this.bPartymode.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bPartymode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bPartymode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bPartymode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPartymode.ForeColor = System.Drawing.Color.Transparent;
            this.bPartymode.Location = new System.Drawing.Point(196, 22);
            this.bPartymode.Name = "bPartymode";
            this.bPartymode.Size = new System.Drawing.Size(16, 15);
            this.bPartymode.TabIndex = 25;
            this.toolTip1.SetToolTip(this.bPartymode, "\'Party Mode\' on/off");
            this.bPartymode.UseVisualStyleBackColor = false;
            this.bPartymode.MouseLeave += new System.EventHandler(this.bPartymode_MouseLeave);
            this.bPartymode.Click += new System.EventHandler(this.bPartymode_Click);
            this.bPartymode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bPartymode_MouseDown);
            this.bPartymode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bPartymode_MouseUp);
            this.bPartymode.MouseEnter += new System.EventHandler(this.bPartymode_MouseEnter);
            // 
            // bShuffle
            // 
            this.bShuffle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bShuffle.BackColor = System.Drawing.Color.Transparent;
            this.bShuffle.BackgroundImage = global::XBMControl.Properties.Resources.button_shuffle;
            this.bShuffle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bShuffle.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.bShuffle.FlatAppearance.BorderSize = 0;
            this.bShuffle.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bShuffle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bShuffle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bShuffle.ForeColor = System.Drawing.Color.Transparent;
            this.bShuffle.Location = new System.Drawing.Point(179, 22);
            this.bShuffle.Name = "bShuffle";
            this.bShuffle.Size = new System.Drawing.Size(16, 15);
            this.bShuffle.TabIndex = 24;
            this.toolTip1.SetToolTip(this.bShuffle, "Shuffle");
            this.bShuffle.UseVisualStyleBackColor = false;
            this.bShuffle.MouseLeave += new System.EventHandler(this.bShuffle_MouseLeave);
            this.bShuffle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bShuffle_MouseDown);
            this.bShuffle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bShuffle_MouseUp);
            this.bShuffle.MouseEnter += new System.EventHandler(this.bShuffle_MouseEnter);
            // 
            // bRepeat
            // 
            this.bRepeat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bRepeat.BackColor = System.Drawing.Color.Transparent;
            this.bRepeat.BackgroundImage = global::XBMControl.Properties.Resources.button_repeat;
            this.bRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bRepeat.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.bRepeat.FlatAppearance.BorderSize = 0;
            this.bRepeat.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bRepeat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bRepeat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRepeat.ForeColor = System.Drawing.Color.Transparent;
            this.bRepeat.Location = new System.Drawing.Point(162, 22);
            this.bRepeat.Name = "bRepeat";
            this.bRepeat.Size = new System.Drawing.Size(16, 15);
            this.bRepeat.TabIndex = 23;
            this.toolTip1.SetToolTip(this.bRepeat, "Repeat on/off");
            this.bRepeat.UseVisualStyleBackColor = false;
            this.bRepeat.MouseLeave += new System.EventHandler(this.bRepeat_MouseLeave);
            this.bRepeat.Click += new System.EventHandler(this.bRepeat_Click);
            this.bRepeat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bRepeat_MouseDown);
            this.bRepeat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bRepeat_MouseUp);
            this.bRepeat.MouseEnter += new System.EventHandler(this.bRepeat_MouseEnter);
            // 
            // tbVolume
            // 
            this.tbVolume.AutoSize = false;
            this.tbVolume.LargeChange = 2;
            this.tbVolume.Location = new System.Drawing.Point(172, 2);
            this.tbVolume.Maximum = 100;
            this.tbVolume.MaximumSize = new System.Drawing.Size(200, 21);
            this.tbVolume.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(65, 18);
            this.tbVolume.TabIndex = 22;
            this.tbVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.tbVolume, "Volume");
            this.tbVolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbVolume_MouseDown);
            this.tbVolume.MouseHover += new System.EventHandler(this.tbVolume_MouseHover);
            this.tbVolume.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbVolume_MouseUp);
            // 
            // bMute
            // 
            this.bMute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bMute.BackColor = System.Drawing.Color.Transparent;
            this.bMute.BackgroundImage = global::XBMControl.Properties.Resources.button_mute;
            this.bMute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bMute.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.bMute.FlatAppearance.BorderSize = 0;
            this.bMute.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bMute.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bMute.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMute.ForeColor = System.Drawing.Color.Transparent;
            this.bMute.Location = new System.Drawing.Point(236, 2);
            this.bMute.Margin = new System.Windows.Forms.Padding(0);
            this.bMute.Name = "bMute";
            this.bMute.Size = new System.Drawing.Size(24, 18);
            this.bMute.TabIndex = 21;
            this.toolTip1.SetToolTip(this.bMute, "Mute");
            this.bMute.UseVisualStyleBackColor = false;
            this.bMute.MouseLeave += new System.EventHandler(this.bMute_MouseLeave);
            this.bMute.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bMute_MouseDown);
            this.bMute.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bMute_MouseUp);
            this.bMute.MouseEnter += new System.EventHandler(this.bMute_MouseEnter);
            // 
            // bOpen
            // 
            this.bOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bOpen.BackColor = System.Drawing.Color.Transparent;
            this.bOpen.BackgroundImage = global::XBMControl.Properties.Resources.button_open;
            this.bOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bOpen.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.bOpen.FlatAppearance.BorderSize = 0;
            this.bOpen.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bOpen.ForeColor = System.Drawing.Color.Transparent;
            this.bOpen.Location = new System.Drawing.Point(130, 22);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(24, 20);
            this.bOpen.TabIndex = 20;
            this.toolTip1.SetToolTip(this.bOpen, "Show Media Browser");
            this.bOpen.UseVisualStyleBackColor = false;
            this.bOpen.MouseLeave += new System.EventHandler(this.bOpen_MouseLeave);
            this.bOpen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bOpen_MouseDown);
            this.bOpen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bOpen_MouseUp);
            this.bOpen.MouseEnter += new System.EventHandler(this.bOpen_MouseEnter);
            // 
            // tbProgress
            // 
            this.tbProgress.AutoSize = false;
            this.tbProgress.Location = new System.Drawing.Point(5, 2);
            this.tbProgress.Maximum = 100;
            this.tbProgress.MaximumSize = new System.Drawing.Size(350, 22);
            this.tbProgress.Minimum = 1;
            this.tbProgress.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.Size = new System.Drawing.Size(164, 18);
            this.tbProgress.TabIndex = 19;
            this.tbProgress.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.tbProgress, "Progress");
            this.tbProgress.Value = 1;
            this.tbProgress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbProgress_MouseDown);
            this.tbProgress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbProgress_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XBMControl.Properties.Resources.openContextMenuArrow1;
            this.pictureBox1.Location = new System.Drawing.Point(254, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(12, 12);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Show context menu");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // bNext
            // 
            this.bNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bNext.BackColor = System.Drawing.Color.Transparent;
            this.bNext.BackgroundImage = global::XBMControl.Properties.Resources.button_next;
            this.bNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.bNext.FlatAppearance.BorderSize = 0;
            this.bNext.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNext.ForeColor = System.Drawing.Color.Transparent;
            this.bNext.Location = new System.Drawing.Point(104, 22);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(24, 20);
            this.bNext.TabIndex = 16;
            this.toolTip1.SetToolTip(this.bNext, "Next");
            this.bNext.UseVisualStyleBackColor = false;
            this.bNext.MouseLeave += new System.EventHandler(this.bNext_MouseLeave);
            this.bNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bNext_MouseDown);
            this.bNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bNext_MouseUp);
            this.bNext.MouseEnter += new System.EventHandler(this.bNext_MouseEnter);
            // 
            // bStop
            // 
            this.bStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bStop.BackColor = System.Drawing.Color.Transparent;
            this.bStop.BackgroundImage = global::XBMControl.Properties.Resources.button_stop;
            this.bStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bStop.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.bStop.FlatAppearance.BorderSize = 0;
            this.bStop.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStop.ForeColor = System.Drawing.Color.Transparent;
            this.bStop.Location = new System.Drawing.Point(81, 22);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(24, 20);
            this.bStop.TabIndex = 15;
            this.toolTip1.SetToolTip(this.bStop, "Stop");
            this.bStop.UseVisualStyleBackColor = false;
            this.bStop.MouseLeave += new System.EventHandler(this.bStop_MouseLeave);
            this.bStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bStop_MouseDown);
            this.bStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bStop_MouseUp);
            this.bStop.MouseEnter += new System.EventHandler(this.bStop_MouseEnter);
            // 
            // bPause
            // 
            this.bPause.BackColor = System.Drawing.Color.Transparent;
            this.bPause.BackgroundImage = global::XBMControl.Properties.Resources.button_pause;
            this.bPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPause.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.bPause.FlatAppearance.BorderSize = 0;
            this.bPause.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPause.ForeColor = System.Drawing.Color.Transparent;
            this.bPause.Location = new System.Drawing.Point(58, 22);
            this.bPause.Name = "bPause";
            this.bPause.Size = new System.Drawing.Size(24, 20);
            this.bPause.TabIndex = 14;
            this.toolTip1.SetToolTip(this.bPause, "Pause/Resume");
            this.bPause.UseVisualStyleBackColor = false;
            this.bPause.MouseLeave += new System.EventHandler(this.bPause_MouseLeave);
            this.bPause.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bPause_MouseDown);
            this.bPause.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bPause_MouseUp);
            this.bPause.MouseEnter += new System.EventHandler(this.bPause_MouseEnter);
            // 
            // bPlay
            // 
            this.bPlay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bPlay.BackColor = System.Drawing.Color.Transparent;
            this.bPlay.BackgroundImage = global::XBMControl.Properties.Resources.button_play;
            this.bPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPlay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(245)))), ((int)(((byte)(242)))));
            this.bPlay.FlatAppearance.BorderSize = 0;
            this.bPlay.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPlay.ForeColor = System.Drawing.Color.Transparent;
            this.bPlay.Location = new System.Drawing.Point(35, 22);
            this.bPlay.Margin = new System.Windows.Forms.Padding(0);
            this.bPlay.Name = "bPlay";
            this.bPlay.Size = new System.Drawing.Size(24, 20);
            this.bPlay.TabIndex = 1;
            this.toolTip1.SetToolTip(this.bPlay, "Play/Resume");
            this.bPlay.UseVisualStyleBackColor = false;
            this.bPlay.MouseLeave += new System.EventHandler(this.bPlay_MouseLeave);
            this.bPlay.Click += new System.EventHandler(this.bPlay_Click);
            this.bPlay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bPlay_MouseDown);
            this.bPlay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bPlay_MouseUp);
            this.bPlay.MouseEnter += new System.EventHandler(this.bPlay_MouseEnter);
            // 
            // bPrevious
            // 
            this.bPrevious.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bPrevious.BackColor = System.Drawing.Color.Transparent;
            this.bPrevious.BackgroundImage = global::XBMControl.Properties.Resources.button_previous;
            this.bPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPrevious.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.bPrevious.FlatAppearance.BorderSize = 0;
            this.bPrevious.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.bPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPrevious.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.bPrevious.ForeColor = System.Drawing.Color.Transparent;
            this.bPrevious.Location = new System.Drawing.Point(12, 22);
            this.bPrevious.Margin = new System.Windows.Forms.Padding(0);
            this.bPrevious.Name = "bPrevious";
            this.bPrevious.Size = new System.Drawing.Size(24, 20);
            this.bPrevious.TabIndex = 1;
            this.bPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.bPrevious, "Previous");
            this.bPrevious.UseVisualStyleBackColor = false;
            this.bPrevious.MouseLeave += new System.EventHandler(this.bPrevious_MouseLeave);
            this.bPrevious.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bPrevious_MouseDown);
            this.bPrevious.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bPrevious_MouseUp);
            this.bPrevious.MouseEnter += new System.EventHandler(this.bPrevious_MouseEnter);
            // 
            // pToolbar
            // 
            this.pToolbar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pToolbar.BackgroundImage = global::XBMControl.Properties.Resources.toolbar1;
            this.pToolbar.Controls.Add(this.lMainTitle);
            this.pToolbar.Controls.Add(this.pictureBox2);
            this.pToolbar.Controls.Add(this.pbMinimize);
            this.pToolbar.Controls.Add(this.pbClose);
            this.pToolbar.Location = new System.Drawing.Point(2, 2);
            this.pToolbar.Name = "pToolbar";
            this.pToolbar.Size = new System.Drawing.Size(264, 20);
            this.pToolbar.TabIndex = 22;
            this.pToolbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pToolbar_MouseMove);
            this.pToolbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pToolbar_MouseDown);
            this.pToolbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pToolbar_MouseUp);
            // 
            // lMainTitle
            // 
            this.lMainTitle.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lMainTitle.ForeColor = System.Drawing.Color.Silver;
            this.lMainTitle.Location = new System.Drawing.Point(29, 3);
            this.lMainTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lMainTitle.Name = "lMainTitle";
            this.lMainTitle.Size = new System.Drawing.Size(212, 13);
            this.lMainTitle.TabIndex = 3;
            this.lMainTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pToolbar_MouseMove);
            this.lMainTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pToolbar_MouseDown);
            this.lMainTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pToolbar_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::XBMControl.Properties.Resources.XBMC;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(4, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "Show context menu");
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pToolbar_MouseMove);
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pToolbar_MouseDown);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pToolbar_MouseUp);
            // 
            // pbMinimize
            // 
            this.pbMinimize.BackColor = System.Drawing.Color.Transparent;
            this.pbMinimize.BackgroundImage = global::XBMControl.Properties.Resources.minimize1;
            this.pbMinimize.Location = new System.Drawing.Point(244, 4);
            this.pbMinimize.Name = "pbMinimize";
            this.pbMinimize.Size = new System.Drawing.Size(9, 9);
            this.pbMinimize.TabIndex = 1;
            this.pbMinimize.TabStop = false;
            this.pbMinimize.MouseLeave += new System.EventHandler(this.pbMinimize_MouseLeave);
            this.pbMinimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbMinimize_MouseUp);
            this.pbMinimize.MouseEnter += new System.EventHandler(this.pbMinimize_MouseEnter);
            // 
            // pbClose
            // 
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.BackgroundImage = global::XBMControl.Properties.Resources.close1;
            this.pbClose.Location = new System.Drawing.Point(251, 4);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(9, 9);
            this.pbClose.TabIndex = 0;
            this.pbClose.TabStop = false;
            this.pbClose.MouseLeave += new System.EventHandler(this.pbClose_MouseLeave);
            this.pbClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbClose_MouseUp);
            this.pbClose.MouseEnter += new System.EventHandler(this.pbClose_MouseEnter);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // MainForm
            // 
            this.AccessibleName = "MainForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(245)))), ((int)(((byte)(242)))));
            this.BackgroundImage = global::XBMControl.Properties.Resources.MainFormBackground2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(268, 184);
            this.ControlBox = false;
            this.Controls.Add(this.pToolbar);
            this.Controls.Add(this.pNowPlayingInfo);
            this.Controls.Add(this.pDetails);
            this.Controls.Add(this.pControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XBMControl";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MainContextMenu.ResumeLayout(false);
            this.pDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).EndInit();
            this.pNowPlayingInfo.ResumeLayout(false);
            this.pNowPlayingInfo.PerformLayout();
            this.pTime.ResumeLayout(false);
            this.pLastFmButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMediaType)).EndInit();
            this.pControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.ImageList ilMediaType;
        private System.Windows.Forms.Panel pControls;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bPause;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip MainContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmsExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator cmsSeperatorFolders;
        private System.Windows.Forms.ToolStripMenuItem cmsShow;
        private System.Windows.Forms.ToolStripMenuItem cmsHide;
        private System.Windows.Forms.ToolStripMenuItem cmsConfigure;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmsControls;
        private System.Windows.Forms.ToolStripMenuItem cmsPrevious;
        private System.Windows.Forms.ToolStripMenuItem cmsPlay;
        private System.Windows.Forms.ToolStripMenuItem cmsPause;
        private System.Windows.Forms.ToolStripMenuItem cmsStop;
        private System.Windows.Forms.ToolStripMenuItem cmsNext;
        private System.Windows.Forms.ToolStripMenuItem cmsMute;
        private System.Windows.Forms.ToolStripMenuItem cmsXBMC;
        private System.Windows.Forms.ToolStripMenuItem cmsXBMCreboot;
        private System.Windows.Forms.ToolStripMenuItem cmsXBMCrestart;
        private System.Windows.Forms.ToolStripMenuItem cmsXBMCshutdown;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem cmsSaveMedia;
        private System.Windows.Forms.ToolStripSeparator cmsSeperatorSaveSend;
        private System.Windows.Forms.ToolStripMenuItem cmsShowScreenshot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TrackBar tbProgress;
        private System.Windows.Forms.Panel pDetails;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lAlbumTitle;
        private System.Windows.Forms.Label lArtist;
        private System.Windows.Forms.Label lTitleTitle;
        private System.Windows.Forms.Label lAlbum;
        private System.Windows.Forms.Label lArtistTitle;
        private System.Windows.Forms.Button bPrevious;
        private System.Windows.Forms.Button bPlay;
        private System.Windows.Forms.PictureBox pbThumbnail;
        private System.Windows.Forms.Panel pNowPlayingInfo;
        private System.Windows.Forms.PictureBox pbMediaType;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.Label lArtistSong;
        private System.Windows.Forms.Panel pToolbar;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.PictureBox pbMinimize;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lMainTitle;
        private System.Windows.Forms.Button bMute;
        private System.Windows.Forms.TrackBar tbVolume;
        private System.Windows.Forms.Panel pTime;
        private System.Windows.Forms.Label lTimePlayed;
        private System.Windows.Forms.Label lSamplerate;
        private System.Windows.Forms.Label lSamplerateTitle;
        private System.Windows.Forms.Label lBitrate;
        private System.Windows.Forms.Label lBitrateTitle;
        private System.Windows.Forms.ToolStripMenuItem cmsSendMediaUrl;
        private System.Windows.Forms.Button bRepeat;
        private System.Windows.Forms.Button bShuffle;
        private System.Windows.Forms.Button bPartymode;
        private System.Windows.Forms.Panel pLastFmButtons;
        private System.Windows.Forms.Button bLastFmHate;
        private System.Windows.Forms.Button bLastFmLove;
        private System.Windows.Forms.ToolStripMenuItem cmsView;
        private System.Windows.Forms.ToolStripMenuItem cmsViewPlaylist;
        private System.Windows.Forms.ToolStripMenuItem cmsViewMediaBrowser;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bPlaylist;
        private System.Windows.Forms.Button bNavigator;
    }
}

