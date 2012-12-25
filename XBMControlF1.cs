// ------------------------------------------------------------------------
//    XBMControl - A compact remote controller for XBMC (.NET 3.5)
//    Copyright (C) 2008  Bram van Oploo (bramvano@gmail.com)
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.
// ------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XBMC;
using System.IO;
using System.Threading;
using XBMControl;
using XBMControl.Properties;
using XBMControl.Language;
using XBMControl.PlayStatusForm;

namespace XBMControl
{
    public partial class MainForm : Form
    {
        private MediaBrowserF1 ShareBrowser;
        internal XBMC_Communicator XBMC;
        internal XBMCLanguage Language;
        private ConfigurationF1 ConfigForm;
        private FullSizeImageF1 fullSizeImage;
        private VolumeControlF1 sysTrayVolumeControl;
        public videoInfoF1 videoInfoForm;
        internal PlaylistF1 Playlist = null;
        internal NavigatorF1 Navigator = null;

        internal bool configFormOpened = false;
        internal bool shareBrowserOpened = false;
        internal bool volumeControlOpened = false;
        internal bool videoInfoOpened = false;

        private int updateTimerConnected = 1000;
        private int updateTimerDisconnected = 10000;

        private string[,] maNowPlayingInfo      = new string[50, 2];

        private bool playStatusMessageShowed    = false;
        private bool showedConnectionStatus     = false;
        private bool showConfigurationAtStart   = false;
        private bool resetToDefault             = false;
        private bool isDragging                 = false;
        private int clickOffsetX, clickOffsetY;
        private int originalWindowHeight;

        private bool repeatEnabled              = false;
        private bool partyModeEnabled           = false;
       
        public MainForm()
        {
            Language = new XBMCLanguage();
            XBMC = new XBMC_Communicator();
            XBMC.SetIp(Settings.Default.Ip);
            XBMC.SetConnectionTimeout(Settings.Default.ConnectionTimeout);
            XBMC.SetCredentials(Settings.Default.Username, Settings.Default.Password);
            InitializeComponent();
            ApplySettings();
            SetLanguageStrings();
            Initialize();
        }

        private void Initialize()
        {
            originalWindowHeight = this.Height;
            ToggleShowDetails();

            if (XBMC.Status.IsConnected())
            {
                if (!XBMC.Status.WebServerEnabled())
                {
                    // Webserver inactive: Ask for continue (default is no)
                    DialogResult dlgRet = MessageBox.Show(Language.GetString("mainform/dialog/webserverDisabled"),
                        Language.GetString("mainform/dialog/webserverDisabledTitle"), 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.None, 
                        MessageBoxDefaultButton.Button2);
                    if (dlgRet == DialogResult.No)
                    {
                        this.Dispose();
                        return;
                    }
                }
                
                updateTimer.Enabled = true;
            }
            else
            {
                if (Settings.Default.ShowConfigurationAtStart == true)
                {
                    if (Settings.Default.Ip == "")
                        MessageBox.Show(Language.GetString("mainform/dialog/ipNotConfigured"), Language.GetString("mainform/dialog/ipNotConfiguredTitle"));
                    else
                        MessageBox.Show(Language.GetString("mainform/dialog/unableToConnect"), Language.GetString("mainform/dialog/unableToConnectTitle"));

                    ShowConfigurationForm();
                }
                updateTimer.Enabled = true;
            }
        }

//START Helper functions
        private void SetControlsEnabled(bool enabled)
        {
            bPrevious.Enabled = enabled;
            bPlay.Enabled = enabled;
            bPause.Enabled = enabled;
            bStop.Enabled = enabled;
            bNext.Enabled = enabled;
            bOpen.Enabled = enabled;
            bMute.Enabled = enabled;
            bRepeat.Enabled = enabled;
            bShuffle.Enabled = enabled;
            bPartymode.Enabled = enabled;
            tbProgress.Enabled = enabled;
            tbVolume.Enabled = enabled;
            cmsXBMC.Visible = enabled;
            cmsControls.Visible = enabled;
            cmsSeperatorFolders.Visible = enabled;
        }

        internal void ApplySettings()
        {
            XBMC.SetConnectionTimeout(Settings.Default.ConnectionTimeout);
            XBMC.SetCredentials(Settings.Default.Username, Settings.Default.Password);
            XBMC.SetIp(Settings.Default.Ip);

            Language.SetLanguage(Settings.Default.Language);
            notifyIcon1.Visible = Settings.Default.ShowInSystemTray;
            
            this.Visible = Settings.Default.ShowInTaskbar;
            this.WindowState = (Settings.Default.StartMinimized) ? FormWindowState.Minimized : FormWindowState.Normal;
            this.SetLanguageStrings();
        }

        private void SetLanguageStrings()
        {
            //MainForm
            this.Text = Language.GetString("global/appName") + " v" + Settings.Default.Version;
            lMainTitle.Text = Language.GetString("global/appName") + " v" + Settings.Default.Version;
            lArtistTitle.Text = Language.GetString("mainform/label/artist");
            lTitleTitle.Text = Language.GetString("mainform/label/title");
            lAlbumTitle.Text = Language.GetString("mainform/label/album");

            //Context Menu
            cmsControls.Text = Language.GetString("contextMenu/controls/title");
            cmsPrevious.Text = Language.GetString("contextMenu/controls/previous");
            cmsPlay.Text = Language.GetString("contextMenu/controls/play");
            cmsPause.Text = Language.GetString("contextMenu/controls/pause");
            cmsStop.Text = Language.GetString("contextMenu/controls/stop");
            cmsNext.Text = Language.GetString("contextMenu/controls/next");
            cmsMute.Text = Language.GetString("contextMenu/controls/mute");
            cmsXBMC.Text = Language.GetString("contextMenu/xbmc/title");
            cmsSendMediaUrl.Text = Language.GetString("contextMenu/xbmc/sendMediaUrl");
            cmsShowScreenshot.Text = Language.GetString("contextMenu/xbmc/showScreenshot");
            cmsXBMCreboot.Text = Language.GetString("contextMenu/xbmc/reboot");
            cmsXBMCrestart.Text = Language.GetString("contextMenu/xbmc/restart");
            cmsXBMCshutdown.Text = Language.GetString("contextMenu/xbmc/shutdown");
            cmsSaveMedia.Text = Language.GetString("contextMenu/saveMedia");
            cmsShow.Text = Language.GetString("contextMenu/show");
            cmsHide.Text = Language.GetString("contextMenu/hide");
            cmsConfigure.Text = Language.GetString("contextMenu/configure");
            cmsExit.Text = Language.GetString("contextMenu/exit");
        }
        //END Helper functions

//START Timer events
        internal void UpdateData()
        {
            resetToDefault = (!XBMC.Status.IsConnected() || XBMC.Status.IsNotPlaying()) ? true : false;

            if (XBMC.Status.IsConnected())
            {
                updateTimer.Interval = updateTimerConnected;
                updateTimer.Enabled = true;

                XBMC.Status.Refresh();
                SetControlsEnabled(true);
                tbProgress.Value = XBMC.Status.GetProgress();
                tbVolume.Value = XBMC.Status.GetVolume();
                SetNowPlayingTimePlayed(resetToDefault);
                GetNowPlayingSongInfo(resetToDefault);
                ShowNowPlayingInfo(resetToDefault);
                ShowPlayStatusInfo();
                SetMediaTypeImage();

                //Set control button states
                bOpen.BackgroundImage   = (shareBrowserOpened) ? Resources.button_open_click : Resources.button_open;
                bPause.BackgroundImage = (XBMC.Status.IsPaused()) ? Resources.button_pause_click : Resources.button_pause;
                bPlay.BackgroundImage = (XBMC.Status.IsPlaying()) ? Resources.button_play_click : Resources.button_play;
                bStop.BackgroundImage = (XBMC.Status.IsNotPlaying()) ? Resources.button_stop_click : Resources.button_stop;
                bMute.BackgroundImage = (XBMC.Status.IsMuted()) ? Resources.button_mute_click : Resources.button_mute;
                bLastFmHate.Visible = (XBMC.Status.IsPlaying("lastfm")) ? true : false;
                bLastFmLove.Visible = (XBMC.NowPlaying.GetMediaType() == "Audio") ? true : false;
                bPlaylist.BackgroundImage = (Settings.Default.playlistOpened && Playlist != null) ? Resources.button_playlist_click : Resources.button_playlist ;
                bNavigator.BackgroundImage = (Settings.Default.NavigatorOpened && Navigator != null) ? Resources.button_remote_click : Resources.button_remote;

                if (Settings.Default.playlistOpened && Playlist == null)
                    this.cmsViewPlaylist_Click(null, null);
            }
            else
            {
                updateTimer.Interval = updateTimerDisconnected;
                updateTimer.Enabled = true;

                SetControlsEnabled(false);
                this.ShowConnectionInfo();
                ShowNowPlayingInfo(resetToDefault);
                SetNowPlayingTimePlayed(resetToDefault);
                SetMediaTypeImage();
                bPause.BackgroundImage = Resources.button_pause;
                bPlay.BackgroundImage = Resources.button_play;
                bMute.BackgroundImage = Resources.button_mute;

                if (Playlist != null)
                    Playlist.Hide();
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            UpdateData();
        }
//END Timer events

//START Main window events
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
                this.Visible = Settings.Default.ShowInTaskbar;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Visible = Settings.Default.ShowInTaskbar;
            if (Settings.Default.playlistOpened && Playlist != null && !Settings.Default.StartMinimized)
            {
                Playlist.Show();
                Playlist.Focus();
                this.Focus();
            }
        }

        private void ToggleShowDetails()
        {
            if (this.Height == originalWindowHeight)
            {
                this.Height = (this.Height - pDetails.Height);
                pDetails.Height = 0;
            }
            else
            {
                pDetails.Height = (originalWindowHeight - this.Height);
                this.Height = originalWindowHeight;
            }
        }

        private void GetNowPlayingSongInfo(bool resetToDefault)
        {
            if (!this.XBMC.Status.IsPlaying() && !this.XBMC.Status.IsPaused())
            {
                lArtistSong.Text    = Language.GetString("mainform/playing/nothing");
                pbThumbnail.Image   = Resources.XBMClogo;
                lBitrate.Text       = "";
                lSamplerate.Text    = "";
                lArtist.Text        = "";
                lTitle.Text         = "";
                lAlbum.Text         = "";
            }
            else if (this.XBMC.Status.IsNewMediaPlaying())
            {
                if(Settings.Default.playlistOpened && this.Playlist != null) this.Playlist.RefreshPlaylist();
                Image coverArt = this.XBMC.NowPlaying.GetCoverArt();
                pbThumbnail.Image       = (coverArt == null) ? Resources.XBMClogo : coverArt;
                string year = (this.XBMC.NowPlaying.Get("year") == null) ? "" : " [" + this.XBMC.NowPlaying.Get("year") + "]";
                lBitrate.Text = this.XBMC.NowPlaying.Get("bitrate");
                lSamplerate.Text = this.XBMC.NowPlaying.Get("samplerate");
                string genre = (this.XBMC.NowPlaying.Get("genre") == null) ? "" : " [" + this.XBMC.NowPlaying.Get("genre") + "]";
                string artistLable = (this.XBMC.NowPlaying.Get("artist") == "" || this.XBMC.NowPlaying.Get("artist") == null) ? "" : this.XBMC.NowPlaying.Get("artist") + " - ";
                lArtistSong.Text = artistLable + this.XBMC.NowPlaying.Get("title");
                lArtist.Text = this.XBMC.NowPlaying.Get("artist") + genre;
                lTitle.Text = this.XBMC.NowPlaying.Get("title") + " [" + this.XBMC.NowPlaying.Get("duration") + "]";
                lAlbum.Text = this.XBMC.NowPlaying.Get("album") + year;
                pLastFmButtons.Visible  = (this.XBMC.Status.LastFmEnabled()) ? true : false;
            }
        }

        public void SetMediaTypeImage()
        {
            if (!this.XBMC.Status.IsPlaying() && !this.XBMC.Status.IsPaused())
                pbMediaType.Visible = false;
            else
            {
                if (this.XBMC.NowPlaying.GetMediaType() == "Audio" || this.XBMC.Status.IsPlaying("lastfm"))
                {
                    pbMediaType.Cursor  = Cursors.Hand;
                    pbMediaType.Image   = (this.XBMC.Status.IsPlaying("lastfm")) ? Resources.lastfm_32x32 : Resources.audio_cd_32x32;
                }
                else if (this.XBMC.NowPlaying.GetMediaType() == "Video")
                {
                    pbMediaType.Cursor  = Cursors.Default;
                    pbMediaType.Image   = Resources.video_32x32;
                }
                else if (this.XBMC.NowPlaying.GetMediaType() == "Picture")
                {
                    pbMediaType.Cursor  = Cursors.Default;
                    pbMediaType.Image   = Resources.pictures_32x32;
                }
                pbMediaType.Visible = true;
            }
        }

        private void SetNowPlayingTimePlayed(bool resetToDefault)
        {
            lTimePlayed.Text = (resetToDefault) ? "00:00" : this.XBMC.NowPlaying.Get("time");
        }

        private void pbThumbnail_Click(object sender, EventArgs e)
        {
            Image coverArt = this.XBMC.NowPlaying.GetCoverArt();
            if (coverArt != null)
            {
                fullSizeImage = new FullSizeImageF1(coverArt);
                fullSizeImage.Show();
            }
        }

        private void pbThumbnail_MouseHover(object sender, EventArgs e)
        {
            if (this.XBMC.NowPlaying.Get("thumb") != "defaultAlbumCover.png")
                pbThumbnail.Cursor = Cursors.Hand;
        }

        private void pbThumbnail_MouseLeave(object sender, EventArgs e)
        {
            if (this.XBMC.NowPlaying.Get("thumb") != "defaultAlbumCover.png")
                pbThumbnail.Cursor = Cursors.Default;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainContextMenu.Show(pictureBox1, new System.Drawing.Point(0, pictureBox1.Height));
        }

        private void pbMediaType_Click(object sender, EventArgs e)
        {
            if (this.XBMC.NowPlaying.GetMediaType() == "Audio" || this.XBMC.Status.IsPlaying("lastfm")) pbLastFM_Click();
        }

        private void pbLastFM_Click()
        {
            string artist = this.XBMC.NowPlaying.Get("artist");
            artist = (artist == null) ? "" : artist.Replace(" ", "+");

            string lastFmUrl = "http://www.last.fm/music/" + artist;
            Help.ShowHelp(this, lastFmUrl);
        }

        private void lArtistSong_Click(object sender, EventArgs e)
        {
            if (this.XBMC.Status.IsPlaying() || this.XBMC.Status.IsPaused()) ToggleShowDetails();
        }
 //END Main window events

//START Notification events
        private void ShowNowPlayingInfo(bool resetToDefault)
        {
            string tempString;

            if (Settings.Default.ShowNowPlayingBalloonTips)
            {
                if (!this.XBMC.Status.IsNotPlaying() && this.XBMC.Status.IsNewMediaPlaying())
                {
                    string currentFilename = this.XBMC.NowPlaying.Get("filename");
                    string genre = (this.XBMC.NowPlaying.Get("genre") == "" || this.XBMC.NowPlaying.Get("genre") == null) ? "" : " [" + this.XBMC.NowPlaying.Get("genre") + "]";
                    string artist = this.XBMC.NowPlaying.Get("artist");
                    string duration = this.XBMC.NowPlaying.Get("duration");
                    string time = (duration == "" || duration == null) ? "" : " [" + duration + "]";
                    string title = this.XBMC.NowPlaying.Get("title");
                    string year = this.XBMC.NowPlaying.Get("year");
                    year = (year == "" || year == null) ? "" : " [" + year + "]";
                    string album = this.XBMC.NowPlaying.Get("album") + year;
                    string lastFM = (currentFilename.Substring(0, 6) == "lastfm") ? "(Last.FM)" : "";

                    if (this.XBMC.Status.IsConnected() && Settings.Default.ShowPlayStatusBalloonTips)
                    {
                        notifyIcon1.ShowBalloonTip(2000, "XBMControl : " + Language.GetString("mainform/playing/now") + lastFM, artist + genre + "\n" + title + time + "\n" + album, ToolTipIcon.Info);
                        tempString = artist + "\n" + title;
                        // System tray tooltip text for "hover" can only be 64 characters long maximum.
                        if (tempString.Length > 64)
                            tempString = tempString.Substring(0, 63);
                        notifyIcon1.Text = tempString;
                    }
                }  
            }
        }

        private void ShowPlayStatusInfo()
        {
            if (!this.XBMC.Status.IsConnected() && Settings.Default.ShowPlayStatusBalloonTips)
            {
                if (this.XBMC.Status.IsNotPlaying())
                {
                    if (!playStatusMessageShowed)
                    {
                        notifyIcon1.ShowBalloonTip(2000, Language.GetString("global/appName"), Language.GetString("mainform/playing/nothing"), ToolTipIcon.Info);
                        playStatusMessageShowed = true;
                    }
                }
                else if (this.XBMC.Status.IsPaused())
                {
                    if (!playStatusMessageShowed)
                    {
                        notifyIcon1.ShowBalloonTip(2000, Language.GetString("global/appName"), Language.GetString("mainform/playing/paused"), ToolTipIcon.Info);
                        notifyIcon1.Text = "XBMControl\n" + Language.GetString("mainform/playing/paused");
                        playStatusMessageShowed = true;
                    }
                }
                else
                    playStatusMessageShowed = false;
            }
        }

        private void ShowConnectionInfo() 
        {
            if (!this.XBMC.Status.IsConnected() && Settings.Default.ShowConnectionInfo)
            {
                if (!showedConnectionStatus)
                {
                    lArtistSong.Text = Language.GetString("mainform/connection/none");
                    if (Settings.Default.ShowConnectionInfo)
                    {
                        notifyIcon1.ShowBalloonTip(2000, Language.GetString("global/appName"), Language.GetString("mainform/connection/none"), ToolTipIcon.Error);
                        notifyIcon1.Text = "XBMControl\n" + Language.GetString("mainform/connection/none");
                    }
                    else
                        MessageBox.Show(Language.GetString("mainform/connection/none"));

                    showedConnectionStatus = true;
                }
            }
            else
                showedConnectionStatus = false;
        }

        private void ShowConfigurationAtStart()
        {
            if (!this.XBMC.Status.IsConnected() && Settings.Default.ShowConfigurationAtStart)
            {
                if (!showConfigurationAtStart)
                {
                    lArtistSong.Text = Language.GetString("mainform/connection/none");
                    if (Settings.Default.ShowConfigurationAtStart)
                    {
                        notifyIcon1.ShowBalloonTip(2000, Language.GetString("global/appName"), Language.GetString("mainform/connection/none"), ToolTipIcon.Error);
                        notifyIcon1.Text = "XBMControl\n" + Language.GetString("mainform/connection/none");
                    }
                    else
                        MessageBox.Show(Language.GetString("mainform/connection/none"));

                    showConfigurationAtStart = true;
                }
            }
            else
                showConfigurationAtStart = false;
        }
//END Notification events

//START Configuration form events
        private void ShowConfigurationForm()
        {
            if (!configFormOpened)
            {
                ConfigForm              = new ConfigurationF1(this);
                ConfigForm.Show();
            }
        }
//END Configuration form events

//START Volume control events
        private void ToggleShowVolumeControl()
        {
            if (this.XBMC.Status.IsConnected())
            {
                if (!volumeControlOpened)
                {
                    sysTrayVolumeControl = new VolumeControlF1(this);
                    sysTrayVolumeControl.FormClosed += new FormClosedEventHandler(VolumeControlClosed);
                    sysTrayVolumeControl.Left = Cursor.Position.X - (sysTrayVolumeControl.Width / 2);
                    sysTrayVolumeControl.Top = Cursor.Position.Y - (sysTrayVolumeControl.Height + 15);
                    sysTrayVolumeControl.Show();
                    sysTrayVolumeControl.Focus();
                    volumeControlOpened = true;
                }
                else
                {
                    sysTrayVolumeControl.Dispose();
                    volumeControlOpened = false;
                }
            }
        }

        public void VolumeControlClosed(object sender, EventArgs e)
        {
            volumeControlOpened = false;
        }
//END Volume control events

//START Progress bar events
        private void tbProgress_MouseUp(object sender, MouseEventArgs e)
        {
            XBMC.Controls.SeekPercentage(tbProgress.Value);
            updateTimer.Enabled = true;
        }

        private void tbProgress_MouseDown(object sender, MouseEventArgs e)
        {
            updateTimer.Enabled = false;
        }

        private void tbProgress_MouseHover(object sender, EventArgs e)
        {
            tbProgress.Focus();
        }
//END Progress bar events

//START Volume bar events
        private void tbVolume_MouseHover(object sender, EventArgs e)
        {
            tbVolume.Focus();
        }

        private void tbVolume_MouseDown(object sender, MouseEventArgs e)
        {
            updateTimer.Enabled = false;
        }

        private void tbVolume_MouseUp(object sender, MouseEventArgs e)
        {
            XBMC.Controls.SetVolume(tbVolume.Value);
            updateTimer.Enabled = true;
        }
//START Volume bar events

//START Context menu events
        private void MainContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (this.XBMC.Status.IsPlaying())
            {
                //cmsSeperatorSaveMedia.Visible = true;
                //cmsSaveMedia.Visible          = true;
            }
        }

        private void cmsNotifyExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmsNotifyPrevious_Click(object sender, EventArgs e)
        {
            XBMC.Controls.Previous();
        }

        private void cmsNotifyPlay_Click(object sender, EventArgs e)
        {
            XBMC.Controls.Play();
        }

        private void cmsNotifyPause_Click(object sender, EventArgs e)
        {
            XBMC.Controls.Play();
        }

        private void cmsNotifyStop_Click(object sender, EventArgs e)
        {
            XBMC.Controls.Stop();
        }

        private void cmsNotifyNext_Click(object sender, EventArgs e)
        {
            XBMC.Controls.Next();
        }

        private void cmsNotifyMute_Click(object sender, EventArgs e)
        {
            XBMC.Controls.ToggleMute();
        }

        private void cmsNotifyShow_Click(object sender, EventArgs e)
        {
            this.Visible        = true;
            this.WindowState    = System.Windows.Forms.FormWindowState.Normal;
            this.Focus();
        }

        private void cmsNotifyHide_Click(object sender, EventArgs e)
        {
            this.WindowState    = System.Windows.Forms.FormWindowState.Minimized;
            this.Visible        = Settings.Default.ShowInTaskbar;
        }

        private void cmsConfigure_Click(object sender, EventArgs e)
        {
            ShowConfigurationForm();
        }

        private void cmsXBMCrebootComputer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.GetString("configuration/ipAddress/proceedMessage"), Language.GetString("contextMenu/xbmc/reboot"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                XBMC.Controls.Reboot();
        }

        private void cmsXBMCrebootXBMC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.GetString("configuration/ipAddress/proceedMessage"), Language.GetString("contextMenu/xbmc/restart"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                XBMC.Controls.Restart();
        }

        private void cmsXBMCshutdown_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.GetString("configuration/ipAddress/proceedMessage"), Language.GetString("contextMenu/xbmc/shutdown"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                XBMC.Controls.Shutdown();
        }

        private void cmsSaveMedia_Click(object sender, EventArgs e)
        {

        }

        private void cmsShowScreenshot_Click(object sender, EventArgs e)
        {
            Image screenshot = XBMC.Controls.GetScreenshot();

            if (screenshot == null)
                MessageBox.Show("Failed taking screenshot");
            else
            {
                fullSizeImage = new FullSizeImageF1(screenshot);
                fullSizeImage.Show();
            }
        }

        private void cmsSendMediaUrl_Click(object sender, EventArgs e)
        {
            SendMediaUrl SendMedia = new SendMediaUrl(this);
            SendMedia.Show();
        }

        private void cmsViewPlaylist_Click(object sender, EventArgs e)
        {
            if (Playlist == null || !Settings.Default.playlistOpened)
            {
                Playlist = new PlaylistF1(this);
                //Playlist.Scale(new SizeF((float)2, (float)2));
                Playlist.Show();
                Playlist.Top = this.Top;
                Playlist.Left = (this.Left + this.Width);
            }
            else if (Settings.Default.playlistOpened && Playlist != null)
                Playlist.Focus();
        }
//END Context menu events

//START Notify icon events
        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            if (volumeControlOpened) sysTrayVolumeControl.Focus();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ToggleShowMainWindow();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle)
                this.ToggleShowVolumeControl();
        }

        private void ToggleShowMainWindow()
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Normal)
            {
                this.WindowState    = FormWindowState.Minimized;
                this.Visible        = Settings.Default.ShowInTaskbar;

                if (Settings.Default.playlistOpened && Playlist != null)
                    Playlist.Hide();
            }
            else
            {
                this.Visible        = true;
                this.WindowState    = FormWindowState.Normal;

                if (Settings.Default.playlistOpened && Playlist != null)
                {
                    Playlist.Show();
                    Playlist.Focus();
                    this.Focus();
                }
            }
        }
//END Notify icon events

//START PREVIOUS BUTTON
        private void bPrevious_MouseEnter(object sender, EventArgs e)
        {
            bPrevious.BackgroundImage = Resources.button_previous_hover;
            //ToggelHoverImage(bPrevious);
        }

        private void bPrevious_MouseLeave(object sender, EventArgs e)
        {
            bPrevious.BackgroundImage = Resources.button_previous;
        }

        private void bPrevious_MouseDown(object sender, MouseEventArgs e)
        {
            bPrevious.BackgroundImage = Resources.button_previous_click;
            this.XBMC.Controls.Previous();
            if (Settings.Default.playlistOpened && this.Playlist != null)
                this.Playlist.RefreshPlaylist();
        }

        private void bPrevious_MouseUp(object sender, MouseEventArgs e)
        {
            bPrevious.BackgroundImage = Resources.button_previous_hover;
        }
//END PREVIOUS BUTTON

//START PLAY BUTTON
        private void bPlay_MouseEnter(object sender, EventArgs e)
        {
            bPlay.BackgroundImage = Resources.button_play_hover;
        }

        private void bPlay_MouseLeave(object sender, EventArgs e)
        {
            bPlay.BackgroundImage = Resources.button_play_hover;
        }

        private void bPlay_MouseDown(object sender, MouseEventArgs e)
        {
            bPlay.BackgroundImage = Resources.button_play_click;
            if(this.XBMC.Status.IsPaused())
                this.XBMC.Controls.Play();
            else if (Settings.Default.playlistOpened && this.Playlist != null)
                this.Playlist.PlaySelectedEntry();
        }

        private void bPlay_MouseUp(object sender, MouseEventArgs e)
        {
            bPlay.BackgroundImage = Resources.button_play_hover;
        }
//END PLAY BUTTON

//START PAUSE BUTTON
        private void bPause_MouseEnter(object sender, EventArgs e)
        {
            if (!this.XBMC.Status.IsPaused()) bPause.BackgroundImage = Resources.button_pause_hover;
        }

        private void bPause_MouseLeave(object sender, EventArgs e)
        {
            if (!this.XBMC.Status.IsPaused()) bPause.BackgroundImage = Resources.button_pause;
        }

        private void bPause_MouseDown(object sender, MouseEventArgs e)
        {
            bPause.BackgroundImage = Resources.button_pause_click;
            this.XBMC.Controls.Play();
        }

        private void bPause_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.XBMC.Status.IsPaused()) bPause.BackgroundImage = Resources.button_pause_hover;
        }
//END PAUSE BUTTON

//START STOP BUTTON
        private void bStop_MouseEnter(object sender, EventArgs e)
        {
            if (this.XBMC.Status.IsPlaying() || this.XBMC.Status.IsPaused()) bStop.BackgroundImage = Resources.button_stop_hover;
        }

        private void bStop_MouseLeave(object sender, EventArgs e)
        {
            if (this.XBMC.Status.IsPlaying() || this.XBMC.Status.IsPaused()) bStop.BackgroundImage = Resources.button_stop;
        }

        private void bStop_MouseDown(object sender, MouseEventArgs e)
        {
            bStop.BackgroundImage = Resources.button_stop_click;
            this.XBMC.Controls.Stop();
            if (Settings.Default.playlistOpened && this.Playlist != null)
                this.Playlist.RefreshPlaylist();
        }

        private void bStop_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.XBMC.Status.IsPlaying() || this.XBMC.Status.IsPaused()) bStop.BackgroundImage = Resources.button_stop_hover;
            GetNowPlayingSongInfo(resetToDefault);
            if (Settings.Default.ShowNowPlayingBalloonTips) ShowNowPlayingInfo(resetToDefault);
        }
//END STOP BUTTON

//START NEXT BUTTON
        private void bNext_MouseEnter(object sender, EventArgs e)
        {
            bNext.BackgroundImage = Resources.button_next_hover;
        }

        private void bNext_MouseLeave(object sender, EventArgs e)
        {
            bNext.BackgroundImage = Resources.button_next;
        }

        private void bNext_MouseDown(object sender, MouseEventArgs e)
        {
            bNext.BackgroundImage = Resources.button_next_click;
            this.XBMC.Controls.Next();
            if (Settings.Default.playlistOpened && this.Playlist != null)
                this.Playlist.RefreshPlaylist();
        }

        private void bNext_MouseUp(object sender, MouseEventArgs e)
        {
            bNext.BackgroundImage = Resources.button_next_hover;
        }

//END NEXT BUTTON

//START OPEN BUTTON
        private void bOpen_MouseEnter(object sender, EventArgs e)
        {
            bOpen.BackgroundImage = Resources.button_open_hover;
        }

        private void bOpen_MouseLeave(object sender, EventArgs e)
        {
            bOpen.BackgroundImage = Resources.button_open;
        }

        private void bOpen_MouseDown(object sender, MouseEventArgs e)
        {
            bOpen.BackgroundImage = Resources.button_open_click;
            if (!shareBrowserOpened)
            {
                this.ShareBrowser = new MediaBrowserF1(this);
                this.ShareBrowser.Show();
                this.shareBrowserOpened = true;
            }
        }

        private void bOpen_MouseUp(object sender, MouseEventArgs e)
        {
            bOpen.BackgroundImage = Resources.button_open_hover;
        }

//END OPEN BUTTON

//START MUTE BUTTON
        private void bMute_MouseEnter(object sender, EventArgs e)
        {
            if (!this.XBMC.Status.IsPaused()) bMute.BackgroundImage = Resources.button_mute_hover;
        }

        private void bMute_MouseLeave(object sender, EventArgs e)
        {
            if (!this.XBMC.Status.IsPaused()) bMute.BackgroundImage = Resources.button_mute;
        }

        private void bMute_MouseDown(object sender, MouseEventArgs e)
        {
            bMute.BackgroundImage = Resources.button_mute_click;
            this.XBMC.Controls.ToggleMute();
        }

        private void bMute_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.XBMC.Status.IsPaused()) bMute.BackgroundImage = Resources.button_mute_hover;
        }
//END MUTE BUTTON

//START LASTFM BUTTONS
        private void bLastFmLove_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show(this.Language.GetString("mainform/dialog/lastfmLove"), this.Language.GetString("mainform/dialog/lastfmLoveTitle"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.XBMC.Controls.LastFmLove();
        }

        private void bLastFmHate_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show(this.Language.GetString("mainform/dialog/lastfmHate"), this.Language.GetString("mainform/dialog/lastfmHateTitle"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.XBMC.Controls.LastFmHate();
        }
//END LASTFM BUTTONS

//START MINIMIZE BUTTON
        private void pbMinimize_MouseEnter(object sender, EventArgs e)
        {
            pbMinimize.BackgroundImage = Resources.minimize1_hover;
        }

        private void pbMinimize_MouseLeave(object sender, EventArgs e)
        {
            pbMinimize.BackgroundImage = Resources.minimize1;
        }

        private void pbMinimize_MouseUp(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }
//END MINIMIZE BUTTON

//START CLOSE BUTTON
        private void pbClose_MouseEnter(object sender, EventArgs e)
        {
            pbClose.BackgroundImage = Resources.close1_hover;
        }

        private void pbClose_MouseLeave(object sender, EventArgs e)
        {
            pbClose.BackgroundImage = Resources.close1;
        }

        private void pbClose_MouseUp(object sender, MouseEventArgs e)
        {
            this.Dispose();
        }
//END CLOSE BUTTON

//START REPEAT BUTTON
        private void bRepeat_MouseEnter(object sender, EventArgs e)
        {
            bRepeat.BackgroundImage = Resources.button_repeat_hover;
        }

        private void bRepeat_MouseLeave(object sender, EventArgs e)
        {
            if (repeatEnabled)
                bRepeat.BackgroundImage = Resources.button_repeat_selected;
            else
                bRepeat.BackgroundImage = Resources.button_repeat;
        }

        private void bRepeat_MouseDown(object sender, MouseEventArgs e)
        {
            bRepeat.BackgroundImage = Resources.button_repeat_click;
        }

        private void bRepeat_MouseUp(object sender, MouseEventArgs e)
        {
            if (repeatEnabled)
                bRepeat.BackgroundImage = Resources.button_repeat_selected;
            else
                bRepeat.BackgroundImage = Resources.button_repeat;
        }

        private void bRepeat_Click(object sender, EventArgs e)
        {
            repeatEnabled = (repeatEnabled) ? false : true;
            this.XBMC.Controls.Repeat(repeatEnabled);
        }

//END REPEAT BUTTON

//START SHUFFLE BUTTON
        private void bShuffle_MouseEnter(object sender, EventArgs e)
        {
            bShuffle.BackgroundImage = Resources.button_shuffle_hover;
        }

        private void bShuffle_MouseLeave(object sender, EventArgs e)
        {
            bShuffle.BackgroundImage = Resources.button_shuffle;
        }

        private void bShuffle_MouseDown(object sender, MouseEventArgs e)
        {
            bShuffle.BackgroundImage = Resources.button_shuffle_click;
            this.XBMC.Controls.ToggleShuffle();
        }

        private void bShuffle_MouseUp(object sender, MouseEventArgs e)
        {
            bShuffle.BackgroundImage = Resources.button_shuffle_hover;
        }
//END SHUFFLE BUTTON

//START PARTYMODE BUTTON
        private void bPartymode_MouseEnter(object sender, EventArgs e)
        {
            bPartymode.BackgroundImage = Resources.button_partymode_hover;
        }

        private void bPartymode_MouseLeave(object sender, EventArgs e)
        {
            if (partyModeEnabled)
                bPartymode.BackgroundImage = Resources.button_partymode_selected;
            else
                bPartymode.BackgroundImage = Resources.button_partymode;
        }

        private void bPartymode_MouseDown(object sender, MouseEventArgs e)
        {
            bPartymode.BackgroundImage = Resources.button_partymode_click;
        }

        private void bPartymode_MouseUp(object sender, MouseEventArgs e)
        {
            if (partyModeEnabled)
                bPartymode.BackgroundImage = Resources.button_partymode_selected;
            else
                bPartymode.BackgroundImage = Resources.button_partymode;
        }

        private void bPartymode_Click(object sender, EventArgs e)
        {
            partyModeEnabled = (partyModeEnabled) ? false : true;
            this.XBMC.Controls.TogglePartymode();
        }
        //END PARTYMODE BUTTON

//START PLAYLIST BUTTON
        private void bPlaylist_MouseHover(object sender, EventArgs e)
        {
            bPlaylist.BackgroundImage = Resources.button_playlist_hover;
        }

        private void bPlaylist_MouseLeave(object sender, EventArgs e)
        {
            bPlaylist.BackgroundImage = Resources.button_playlist;
        }

        private void bPlaylist_MouseDown(object sender, MouseEventArgs e)
        {
            bPlaylist.BackgroundImage = Resources.button_playlist_click;
        }

        private void bPlaylist_MouseUp(object sender, MouseEventArgs e)
        {
            bPlaylist.BackgroundImage = Resources.button_playlist_hover;

            if (Settings.Default.playlistOpened && Playlist != null)
            {
                Playlist.Show();
                Playlist.Focus();
                this.Focus();
            }
            else
                cmsViewPlaylist_Click(null, null);
        }

        private void cmsViewNavigator_Click(object sender, EventArgs e)
        {
            if (Navigator == null || !Settings.Default.NavigatorOpened)
            {
                Navigator = new NavigatorF1(this);
                Navigator.Show();
                Navigator.Top = this.Top;
                Navigator.Left = (this.Left + this.Width);
            }
            else if (Settings.Default.NavigatorOpened && Navigator != null)
                Navigator.Focus();
        }
//END PLAYLIST BUTTON

//START NAVIGATOR BUTTON
        private void bNavigator_MouseHover(object sender, EventArgs e)
        {
            bNavigator.BackgroundImage = Resources.button_remote_hover;
        }

        private void bNavigator_MouseLeave(object sender, EventArgs e)
        {
            bNavigator.BackgroundImage = Resources.button_remote;
        }

        private void bNavigator_MouseDown(object sender, MouseEventArgs e)
        {
            bNavigator.BackgroundImage = Resources.button_remote_click;
        }

        private void bNavigator_MouseUp(object sender, MouseEventArgs e)
        {
            bNavigator.BackgroundImage = Resources.button_remote_hover;

            if (Settings.Default.NavigatorOpened && Navigator != null)
            {
                Navigator.Show();
                Navigator.Focus();
                this.Focus();
            }
            else
                cmsViewNavigator_Click(null, null);
        }
//END NAVIGATOR BUTTON
        
//START FAKE DRAG DROP
        private void pToolbar_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging   = true;
            clickOffsetX = e.X;
            clickOffsetY = e.Y;
        }

        private void pToolbar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            if (e.Button == MouseButtons.Right)
                MainContextMenu.Show(pToolbar, new System.Drawing.Point(0, pToolbar.Height));
        }

        private void pToolbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging == true)
            {
                this.Left = e.X + this.Left - clickOffsetX;
                this.Top  = e.Y + this.Top - clickOffsetY;

                if (Settings.Default.playlistOpened && this.Playlist != null)
                {
                    Playlist.Top = this.Top;
                    Playlist.Left = this.Left + this.Width;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainContextMenu.Show(pToolbar, new System.Drawing.Point(0, pToolbar.Height));
        }
//END FAKE DRAG DROP

        private void cmsMediaBrowser_Click(object sender, EventArgs e)
        {
            this.bOpen_MouseDown(null, null);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void bNavigator_Click(object sender, EventArgs e)
        {

        }

        private void bPlay_Click(object sender, EventArgs e)
        {

        }
    }
}
