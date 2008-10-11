﻿// ------------------------------------------------------------------------
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
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using XBMControl.Properties;
using System.Windows.Forms;
using System.Drawing;

namespace XBMC.Communicator
{
    class XBMCcomm
    {
        private string configuredXbmcIp     = null;
        private string xbmcUsername         = null;
        private string xbmcPassword         = null;
        private string _ApiPath             = "/xbmcCmds/xbmcHttp";
        private string[,] maNowPlayingInfo  = new string[50, 2];
        private string logFile              = "log/xbmcontrol.log";

        //XBMC Properties
        private bool connected              = false;
        private bool isPlaying              = false;
        private bool isNotPlaying           = true;
        private bool isPlayingLastFm        = false;
        private bool isPaused               = false;
        private bool isMuted                = false;
        private int volume                  = 0;
        private int progress                = 0;
        private string mediaNowPlaying      = null;
        private bool newMediaPlaying        = true;
        private string nowPlayingMediaType  = null;

        public XBMCcomm()
        {
        }

//START REQUEST
        public string[] Request(string command, string parameter, string ip)
        {
            HttpWebRequest request      = null;
            HttpWebResponse response    = null;
            StreamReader reader         = null;
            string[] pageContent        = null;
            string ipAddress            = (ip == null) ? configuredXbmcIp : ip;
            parameter                   = (parameter == null)? "" : parameter;
            command                     = "?command=" + command;
            command                     += (parameter == null || parameter == "") ? "" : "&parameter=" + parameter;

            try
            {
                request             = (HttpWebRequest)HttpWebRequest.Create("http://" + ipAddress + this._ApiPath + command);
                request.Method      = "GET";
                request.Timeout     = XBMControl.Properties.Settings.Default.ConnectionTimeout;
                if (xbmcUsername != "" && xbmcPassword != "") request.Credentials = new NetworkCredential(xbmcUsername, xbmcPassword);
                response            = (HttpWebResponse)request.GetResponse();
                reader              = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                pageContent         = reader.ReadToEnd().Replace("<li>", "|").Replace("\n", "").Replace("<html>", "").Replace("</html>", "").Split('|');
                connected           = (pageContent == null) ? false : true;
            }
            catch (WebException e)
            {
                WriteToLog("ERROR - " + e.Message);
            }
            finally
            {
                if (response != null) response.Close();
                if (reader != null) reader.Close();
            }

            return pageContent;
        }

        public string[] Request(string command, string parameter)
        {
            return this.Request(command, parameter, null);
        }

        public string[] Request(string command)
        {
            return this.Request(command, null, null);
        }
//END REQUEST

//START CONNECTION TEST
        public bool IsConnected(string ip)
        {
            this.Request("SetResponseFormat", null, ip);
            return connected;
        }

        public bool IsConnected()
        {
            return IsConnected(null);
        }
//END CONNECTION TEST

//WHAT TO DO WITH THIS??
        public void GetXbmcProperties()
        {
            if (connected)
            {
                if (mediaNowPlaying != this.GetNowPlayingInfo("filename", true) || mediaNowPlaying == null)
                {
                    mediaNowPlaying = this.GetNowPlayingInfo("filename");
                    newMediaPlaying = true;
                }
                else
                    newMediaPlaying = false;

                string[] aFilename  = this.Request("filename");
                string filename     = (aFilename == null) ? "[Nothing Playing]" : aFilename[0]; 
                isPlaying           = (this.GetNowPlayingInfo("playstatus") == "Playing") ? true : false;
                isNotPlaying        = (filename == "[Nothing Playing]") ? true : false;
                isPlayingLastFm     = (this.GetNowPlayingInfo("filename").Substring(0, 6) == "lastfm") ? true : false;
                isPaused            = (this.GetNowPlayingInfo("playstatus") == "Paused") ? true : false;
                nowPlayingMediaType = this.GetNowPlayingInfo("type");

                string[] aVolume = this.Request("GetVolume");
                string[] aProgress = this.Request("GetPercentage");

                if (aVolume == null)
                    volume = 0;
                else
                    volume = (aVolume[1] == "Error") ? 0 : Convert.ToInt32(aVolume[1]);

                 if (aProgress == null)
                    progress = 1;
                else
                    progress = (aProgress[1] == "Error" || aProgress[1] == "0" || Convert.ToInt32(aProgress[1]) > 99) ? 1 : Convert.ToInt32(aProgress[1]);
 
                isMuted = (volume == 0) ? true : false;
            }
        }
//WHAT TO DO WITH THIS???

//START Player Control
        public void Play()
        {
            this.Request("ExecBuiltIn", "PlayerControl(Play)");
        }

        public void PlayMedia(string media)
        {
            this.Request("ExecBuiltIn", "PlayerControl(Play)");
        }

        public void Stop()
        {
            this.Request("ExecBuiltIn", "PlayerControl(Stop)");
        }

        public void Next()
        {
            this.Request("ExecBuiltIn", "PlayerControl(Next)");
        }

        public void Previous()
        {
            this.Request("ExecBuiltIn", "PlayerControl(Previous)");
        }

        public void ToggleShuffle()
        {
            this.Request("ExecBuiltIn", "PlayerControl(Random)");
        }

        public void TogglePartymode()
        {
            this.Request("takescreenshot", "Partymode()");
        }

        public void Repeat(bool enable)
        {
            string mode = (enable) ? "RepeatAll" : "RepeatOff";
            this.Request("ExecBuiltIn", "PlayerControl(" +mode+ ")");
        }

        public void LastFmLove()
        {
            this.Request("ExecBuiltIn", "LastFM.Love(false)");
        }

        public void LastFmHate()
        {
            this.Request("ExecBuiltIn", "LastFM.Ban(false)");
        }

        public void ToggleMute()
        {
            this.Request("ExecBuiltIn", "Mute");
        }

        public void SetVolume(int percentage)
        {
            this.Request("ExecBuiltIn", "SetVolume(" +Convert.ToString(percentage)+ ")");
        }

        public void SeekPercentage(int percentage)
        {
            this.Request("SeekPercentage", Convert.ToString(percentage));
        }

        public string GetScreenshotBase64()
        {
            string[] base64screenshot = this.Request("takescreenshot", "screenshot.jpg;false;0;" + this.GetGuiDescription("width") + ";" + this.GetGuiDescription("height") + ";75;true;");
            return (base64screenshot == null)? null : base64screenshot[0];
        }
//END Player Control

//START Machine and XBMC control
        public void Reboot()
        {
            this.Request("ExecBuiltIn", "Reboot");
        }

        public void Shutdown()
        {
            this.Request("ExecBuiltIn", "Shutdown");
        }

        public void Restart()
        {
            this.Request("ExecBuiltIn", "RestartApp");
        }

        public string GetGuiDescription(string field)
        {
            string returnValue = null;
            string[] aGuiDescription = this.Request("GetGUIDescription");

            for (int x = 0; x < aGuiDescription.Length; x++)
            {
                int splitIndex = aGuiDescription[x].IndexOf(':') + 1;
                if (splitIndex > 1)
                {
                    string resultField = aGuiDescription[x].Substring(0, splitIndex - 1).Replace(" ", "").ToLower();
                    if (resultField == field) returnValue = aGuiDescription[x].Substring(splitIndex, aGuiDescription[x].Length - splitIndex);
                }
            }

            return returnValue;
        }

        public Image GetScreenshot()
        {
            Image screenshot         = null;
            string base64ImageString = this.GetScreenshotBase64();

            if( base64ImageString != null)
                screenshot = this.Base64StringToImage(base64ImageString);

            return screenshot;
        }
//END Machine and XBMC control

//START Status Information
        public bool IsNewMediaPlaying()
        {
            return newMediaPlaying;
        }

        public bool IsPlaying(string lastfm)
        {
            return (lastfm != null )? isPlayingLastFm : isPlaying ;
        }

        public bool IsPlaying()
        {
            return this.IsPlaying(null);
        }

        public bool IsNotPlaying()
        {
            return isNotPlaying;
        }

        public bool IsPaused()
        {
            return isPaused;
        }

        public bool IsMuted()
        {
            return isMuted;
        }

        public int GetVolume()
        {
            return volume;
        }

        public int GetProgress()
        {
            return progress;
        }

        public string GetNowPlayingMediaType()
        {
            return nowPlayingMediaType;
        }
//END Status Information

//START Now Playing Information
        public string GetNowPlayingInfo(string field, bool refresh)
        {
            string returnValue = null;
            if (refresh)
            {
                string[] aNowPlayingTemp = this.Request("GetCurrentlyPlaying");

                if (aNowPlayingTemp == null)
                    returnValue = null;
                else
                {
                    for (int x = 0; x < aNowPlayingTemp.Length; x++)
                    {
                        int splitIndex = aNowPlayingTemp[x].IndexOf(':') + 1;
                        if (splitIndex > 1)
                        {
                            this.maNowPlayingInfo[x, 0] = aNowPlayingTemp[x].Substring(0, splitIndex - 1).Replace(" ", "").ToLower();
                            this.maNowPlayingInfo[x, 1] = aNowPlayingTemp[x].Substring(splitIndex, aNowPlayingTemp[x].Length - splitIndex);
                            if (this.maNowPlayingInfo[x, 0] == field) 
                                returnValue = this.maNowPlayingInfo[x, 1];
                        }
                    }
                }
            }
            else
            {
                for (int x = 0; x < this.maNowPlayingInfo.GetLength(0); x++)
                {
                    if (this.maNowPlayingInfo[x, 0] == field) 
                        returnValue = this.maNowPlayingInfo[x, 1];
                }
            }

            return returnValue;
        }

        public string GetNowPlayingInfo(string field)
        {
            return this.GetNowPlayingInfo(field, false);
        }

        public Image GetNowPlayingCoverArt()
        {
            MemoryStream stream = null;
            Image thumbnail = null;
            WebClient client = new WebClient();
            Uri xbmcThumbUri = new Uri("http://" + Settings.Default.Ip + "/thumb.jpg");
            this.Request("GetCurrentlyPlaying", "q:\\web\\thumb.jpg");

            try
            {
                stream = new MemoryStream(client.DownloadData(xbmcThumbUri));
                thumbnail = new Bitmap(Image.FromStream(stream));
            }
            catch (Exception e)
            {
                WriteToLog("ERROR - " + e.Message);
            }
            finally
            {
                client.Dispose();
            }

            return thumbnail;
        }
//END Now Playing Information getters

//START Helper functions
        public Image Base64StringToImage(string base64String)
        {
            Bitmap file         = null;
            byte[] bytes        = Convert.FromBase64String(base64String);
            MemoryStream stream = new MemoryStream(bytes);

            if (base64String != null && base64String != "")
                file = new Bitmap(Image.FromStream(stream));
                
            return file;
        }

        private void WriteToLog(string message)
        {
            StreamWriter sw = new StreamWriter(logFile, true);
            sw.WriteLine(DateTime.Now + " : " + message);
            sw.Flush();
            sw.Close();

        }

        public void SetXbmcIp(string ip)
        {
            configuredXbmcIp = ip;
        }

        public string GetXbmcIp()
        {
            return configuredXbmcIp;
        }

        public void SetCredentials(string username, string password)
        {
            xbmcUsername = username;
            xbmcPassword = password;
        }
    }
//END Helper functions




    /*
 public MemoryStream GetImageFromXbmc(string xbmcFilePath)
 {
     //Image imageFile       = null;
     MemoryStream stream   = null;
     WebClient client      = new WebClient();
     Uri xbmcUri           = new Uri("http://" + Settings.Default.Ip + "/xbmcCmds/xbmcHttp?command=FileDownload&parameter=" + xbmcFilePath);

     try
     {
         stream = new MemoryStream(client.DownloadData(xbmcUri));
     }
     catch (Exception e)
     { 
     }
     finally
     {
         client.Dispose();
     }

     return stream;
 }
 */
}