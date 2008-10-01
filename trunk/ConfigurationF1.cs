﻿// ------------------------------------------------------------------------
//    XBMControl - A compact remote controller for XBMC (.NET 2.0)
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Security.Permissions;
using Microsoft.Win32;
using XBMControl.Properties;
using XBMC.Communicator;
using XBMControl.Language;

[assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum, ViewAndModify = "HKEY_CURRENT_USER")]

namespace XBMControl
{
    public partial class ConfigurationF1 : Form
    {
        XBMCcomm XBMC;
        XBMCLanguage Language;
        RegistryKey regRunAtStartup;

        public ConfigurationF1()
        {
            XBMC            = new XBMCcomm();
            Language        = new XBMCLanguage();
            regRunAtStartup = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            InitializeComponent();
            LoadConfiguration();
            Language.SetLanguage(XBMControl.Properties.Settings.Default.Language);
            SetLanguageStrings();
        }

        private void SetLanguageStrings()
        {
            this.Text                               = Language.GetString("global/appName") + " " + Language.GetString("configuration/title");
            lLanguageTitle.Text                     = Language.GetString("configuration/label/language");
            lIpTitle.Text                           = Language.GetString("configuration/label/ip");
            lUsernameTitle.Text                     = Language.GetString("configuration/label/username");
            lPasswordTitle.Text                     = Language.GetString("configuration/label/password");
            cbShowInTray.Text                       = Language.GetString("configuration/label/showInTray");
            cbShowInTaskbar.Text                    = Language.GetString("configuration/label/showInTaskbar");
            cbShowNowPlayingBalloonTip.Text         = Language.GetString("configuration/label/showNowPlayingBalloonTip");
            cbShowPlayStatusBalloonTip.Text         = Language.GetString("configuration/label/showPlayStatusBalloonTip");
            cbShowConnectionStatusBalloonTip.Text   = Language.GetString("configuration/label/showConnectionStatusBalloonTip");
            cbRunAtStartup.Text                     = Language.GetString("configuration/label/runAtStartup");
            bConfirm.Text                           = Language.GetString("global/button/confirm");
            bCancel.Text                            = Language.GetString("global/button/cancel");
        }

        private void SaveConfiguration()
        {
            XBMControl.Properties.Settings.Default.Ip                             = tbIp.Text;
            XBMControl.Properties.Settings.Default.Username                       = tbUsername.Text;
            XBMControl.Properties.Settings.Default.Password                       = tbPassword.Text;
            XBMControl.Properties.Settings.Default.ShowInSystemTray               = cbShowInTray.Checked;
            XBMControl.Properties.Settings.Default.ShowNowPlayingBalloonTips      = cbShowNowPlayingBalloonTip.Checked;
            XBMControl.Properties.Settings.Default.ShowPlayStausBalloonTips       = cbShowPlayStatusBalloonTip.Checked;
            XBMControl.Properties.Settings.Default.ShowInTaskbar                  = cbShowInTaskbar.Checked;
            XBMControl.Properties.Settings.Default.ShowConnectionStatusBalloonTip = cbShowConnectionStatusBalloonTip.Checked;
            XBMControl.Properties.Settings.Default.Language                       = cbLanguage.Text;
            if (!XBMControl.Properties.Settings.Default.ShowInSystemTray) XBMControl.Properties.Settings.Default.ShowInTaskbar = true;

            if( cbRunAtStartup.Checked )
                regRunAtStartup.SetValue(Language.GetString("global/appName"), Application.ExecutablePath.ToString());
            else
                regRunAtStartup.DeleteValue(Language.GetString("global/appName"), false);

            XBMControl.Properties.Settings.Default.Save();
        }

        private void LoadConfiguration()
        {
            ShowAvailableLanguages();
            SetSystrayChackboxesEnabled(XBMControl.Properties.Settings.Default.ShowInSystemTray);
            tbIp.Text                                = XBMControl.Properties.Settings.Default.Ip;
            tbUsername.Text                          = XBMControl.Properties.Settings.Default.Username;
            tbPassword.Text                          = XBMControl.Properties.Settings.Default.Password;
            cbShowInTray.Checked                     = XBMControl.Properties.Settings.Default.ShowInSystemTray;
            cbShowNowPlayingBalloonTip.Checked       = XBMControl.Properties.Settings.Default.ShowNowPlayingBalloonTips;
            cbShowPlayStatusBalloonTip.Checked       = XBMControl.Properties.Settings.Default.ShowPlayStausBalloonTips;
            cbShowInTaskbar.Checked                  = XBMControl.Properties.Settings.Default.ShowInTaskbar;
            cbShowConnectionStatusBalloonTip.Checked = XBMControl.Properties.Settings.Default.ShowConnectionStatusBalloonTip;
            cbLanguage.Text                          = XBMControl.Properties.Settings.Default.Language;
            cbRunAtStartup.Checked                   = (regRunAtStartup.GetValue(Language.GetString("global/appName")) == null) ? false : true;
        }

        private void SetSystrayChackboxesEnabled(bool enabled)
        {
            cbShowNowPlayingBalloonTip.Enabled       = enabled;
            cbShowPlayStatusBalloonTip.Enabled       = enabled;
            cbShowInTaskbar.Enabled                  = enabled;
            cbShowConnectionStatusBalloonTip.Enabled = enabled;
        }

        private bool IsValidIp()
        {
            if (tbIp.Text == "")
            {
                MessageBox.Show(Language.GetString("configuration/ipAddress/required"));
                return false;
            }
            else if (!XBMC.IsConnected(tbIp.Text))
            {
                if (MessageBox.Show(Language.GetString("configuration/ipAddress/proceedMessage"), Language.GetString("global/appName"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        private void ShowAvailableLanguages()
        {
            string[] languages = Language.GetAvailableLanguages();

            if (languages.Length > 0)
            {
                cbLanguage.Items.Clear();
                foreach(string lang in languages)
                    cbLanguage.Items.Add(lang);
            }
            else
                MessageBox.Show(Language.GetString("configuration/language/noLanguages"));
        }

        private void ConfigurationF1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            if( tbIp.Text == "" )
                MessageBox.Show(Language.GetString("configuration/ipAddress/required"));
            else
                Close();
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            if (IsValidIp())
            {
                SaveConfiguration();
                Close();
            }
        }

        private void cbShowInTray_Click(object sender, EventArgs e)
        {
            SetSystrayChackboxesEnabled(cbShowInTray.Checked);
            if (!cbShowInTray.Checked) cbShowInTaskbar.Checked = true;
        }

        private void cbLanguage_TextChanged(object sender, EventArgs e)
        {
            Language.SetLanguage(cbLanguage.Text);
            SetLanguageStrings();
        }
    }
}