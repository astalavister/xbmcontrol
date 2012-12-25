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
using System.Net;
using System.Security.Permissions;
using Microsoft.Win32;
using XBMControl.Properties;

[assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum, ViewAndModify = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run")]

namespace XBMControl
{
    public partial class ConfigurationF1 : Form
    {
        MainForm parent;
        RegistryKey regRunAtStartup;

        public ConfigurationF1(MainForm parentForm)
        {
            parent = parentForm;
            parent.configFormOpened = true;
            
            InitializeComponent();
            LoadConfiguration();
            parent.Language.SetLanguage(Settings.Default.Language);
            SetLanguageStrings();
            cbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbConnectionTimeout.DropDownStyle = ComboBoxStyle.DropDownList; ;
        }

        private void SetLanguageStrings()
        {
            this.Text                               = parent.Language.GetString("global/appName") + " " + parent.Language.GetString("configuration/title");
            lConnectionTimeout.Text                 = parent.Language.GetString("configuration/label/connectionTimeout");
            lLanguageTitle.Text                     = parent.Language.GetString("configuration/label/language");
            lIpTitle.Text                           = parent.Language.GetString("configuration/label/ip");
            lUsernameTitle.Text                     = parent.Language.GetString("configuration/label/username");
            lPasswordTitle.Text                     = parent.Language.GetString("configuration/label/password");
            cbShowInTray.Text                       = parent.Language.GetString("configuration/label/showInTray");
            cbShowInTaskbar.Text                    = parent.Language.GetString("configuration/label/showInTaskbar");
            cbShowNowPlayingBalloonTip.Text         = parent.Language.GetString("configuration/label/showNowPlayingBalloonTip");
            cbShowPlayStatusBalloonTip.Text         = parent.Language.GetString("configuration/label/showPlayStatusBalloonTip");
            cbShowConnectionStatusBalloonTip.Text   = parent.Language.GetString("configuration/label/showConnectionStatusBalloonTip");
            cbRunAtStartup.Text                     = parent.Language.GetString("configuration/label/runAtStartup");
            cbStartMinimized.Text                   = parent.Language.GetString("configuration/label/startMinimized");
            cbShowConfigurationAtStart.Text         = parent.Language.GetString("configuration/label/showConfigurationAtStart");
            bConfirm.Text                           = parent.Language.GetString("global/button/confirm");
            bCancel.Text                            = parent.Language.GetString("global/button/cancel");
        }

        private void SaveConfiguration()
        {
            Settings.Default.Language                       = cbLanguage.Text;
            Settings.Default.Ip                             = tbIp.Text;
            Settings.Default.Username                       = tbUsername.Text;
            Settings.Default.Password                       = tbPassword.Text;
            Settings.Default.ConnectionTimeout              = Convert.ToInt32(cbConnectionTimeout.Text); 
            Settings.Default.ShowInSystemTray               = cbShowInTray.Checked;
            Settings.Default.ShowNowPlayingBalloonTips      = cbShowNowPlayingBalloonTip.Checked;
            Settings.Default.ShowPlayStatusBalloonTips      = cbShowPlayStatusBalloonTip.Checked;
            Settings.Default.ShowInTaskbar                  = cbShowInTaskbar.Checked;
            Settings.Default.StartMinimized                 = cbStartMinimized.Checked;
            Settings.Default.ShowConnectionInfo             = cbShowConnectionStatusBalloonTip.Checked;
            Settings.Default.ShowConfigurationAtStart       = cbShowConfigurationAtStart.Checked;

            regRunAtStartup                                 = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            if (cbRunAtStartup.Checked)
                regRunAtStartup.SetValue(parent.Language.GetString("global/appName"), "\"" + Application.ExecutablePath + "\"");
            else if (regRunAtStartup.GetValue(parent.Language.GetString("global/appName")) != null)
                regRunAtStartup.DeleteValue(parent.Language.GetString("global/appName"));

            regRunAtStartup.Close();
            
            if (!Settings.Default.ShowInSystemTray) Settings.Default.ShowInTaskbar = true;

            Settings.Default.Save();
        }

        private void LoadConfiguration()
        {
            ShowAvailableLanguages();
            SetSystrayCheckboxesEnabled(Settings.Default.ShowInSystemTray);
            cbLanguage.Text                          = Settings.Default.Language;
            tbIp.Text                                = Settings.Default.Ip;
            tbUsername.Text                          = Settings.Default.Username;
            tbPassword.Text                          = Settings.Default.Password;
            cbConnectionTimeout.Text                 = Settings.Default.ConnectionTimeout.ToString();

            cbShowInTray.Checked                     = Settings.Default.ShowInSystemTray;
            cbShowNowPlayingBalloonTip.Checked       = Settings.Default.ShowNowPlayingBalloonTips;
            cbShowPlayStatusBalloonTip.Checked       = Settings.Default.ShowPlayStatusBalloonTips;
            cbShowInTaskbar.Checked                  = Settings.Default.ShowInTaskbar;
            cbStartMinimized.Checked                 = Settings.Default.StartMinimized;
            cbShowConnectionStatusBalloonTip.Checked = Settings.Default.ShowConnectionInfo;
            cbShowConfigurationAtStart.Checked       = Settings.Default.ShowConfigurationAtStart;
            regRunAtStartup                          = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            cbRunAtStartup.Checked                   = (regRunAtStartup.GetValue(parent.Language.GetString("global/appName")) == null) ? false : true;
            regRunAtStartup.Close();
        
        }

        private void SetSystrayCheckboxesEnabled(bool enabled)
        {
            cbShowNowPlayingBalloonTip.Enabled       = enabled;
            cbShowPlayStatusBalloonTip.Enabled       = enabled;
            cbShowInTaskbar.Enabled                  = enabled;
            cbShowConnectionStatusBalloonTip.Enabled = enabled;
        }

        private bool IsValidIp()
        {
            parent.XBMC.SetIp(tbIp.Text);

            if (tbIp.Text == "")
            {
                MessageBox.Show(parent.Language.GetString("mainform/dialog/ipNotConfigured"), parent.Language.GetString("mainform/dialog/ipNotConfiguredTitle"));
                return false;
            }
            else if (!parent.XBMC.Status.IsConnected())
            {
                if (MessageBox.Show(parent.Language.GetString("mainform/dialog/unableToConnect") + "\n\n" + parent.Language.GetString("mainform/dialog/proceedMessage"), parent.Language.GetString("mainform/dialog/unableToConnectTitle"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        private void ShowAvailableLanguages()
        {
            string[] languages = parent.Language.GetAvailableLanguages();

            if (languages.Length > 0)
            {
                cbLanguage.Items.Clear();
                foreach(string lang in languages)
                    cbLanguage.Items.Add(lang);
            }
            else
                MessageBox.Show(parent.Language.GetString("configuration/language/noLanguages"));
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if( tbIp.Text == "" )
                MessageBox.Show(parent.Language.GetString("configuration/ipAddress/required"));
            else
                Close();
            this.Cursor = Cursors.Default;
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (IsValidIp())
            {
                this.SaveConfiguration();
                this.Close();
            }
            this.Cursor = Cursors.Default;
        }

        private void cbShowInTray_Click(object sender, EventArgs e)
        {
            SetSystrayCheckboxesEnabled(cbShowInTray.Checked);
            if (!cbShowInTray.Checked) cbShowInTaskbar.Checked = true;
        }

        private void cbLanguage_TextChanged(object sender, EventArgs e)
        {
            parent.Language.SetLanguage(cbLanguage.Text);
            SetLanguageStrings();
        }

        private void cbConnectionTimeout_SelectedValueChanged(object sender, EventArgs e)
        {
            Settings.Default.ConnectionTimeout = Convert.ToInt32(cbConnectionTimeout.Text); 
        }

        private void cbShowPlayStatusWindow_Click(object sender, EventArgs e)
        {
            if (cbShowPlayStatusBalloonTip.Checked)
                cbShowPlayStatusBalloonTip.Checked = false;
        }

        private void ConfigurationF1_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.ApplySettings();
            parent.UpdateData();
            parent.configFormOpened = false;
        }
    }
}
