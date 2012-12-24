// ------------------------------------------------------------------------
//    XBMControl - A compact remote controller for XBMC (.NET 3.5)
//    Copyright (C) 2008  Bram van Oploo (bramvano@gmail.com)
//                        Mike Thiels (Mike.Thiels@gmail.com)
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
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Net;
using XBMControl.Properties;


namespace XBMC
{
    public class XBMC_Video
    {
        XBMC_Communicator parent = null;

        public XBMC_Video(XBMC_Communicator p)
        {
            parent = p;
        }


        public string Hash(string input)
        {
            byte[] bytes;
            uint m_crc = 0xffffffff;
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            bytes = encoding.GetBytes(input.ToLower());
            foreach (byte myByte in bytes)
            {
                m_crc ^= ((uint)(myByte) << 24);
                for (int i = 0; i < 8; i++)
                {
                    if ((System.Convert.ToUInt32(m_crc) & 0x80000000) == 0x80000000)
                    {
                        m_crc = (m_crc << 1) ^ 0x04C11DB7;
                    }
                    else
                    {
                        m_crc <<= 1;
                    }
                }
            }
            return String.Format("{0:x8}", m_crc);
        }

        public System.Drawing.Image getVideoThumb(string videoID)
        {
            string hashName;
            string[] strPath;
            string[] downloadData;
            string ipString;
            string[] fileExist;
            Image retThumbnail = Resources.video_32x32;

            string condition = (videoID == null) ? "" : " WHERE C09 LIKE '%%" + videoID + "%%'";
            strPath = parent.Request("QueryVideoDatabase", "SELECT strpath FROM movieview " + condition);
            hashName = Hash(strPath[0] + "VIDEO_TS.IFO");
            ipString = "P:\\Thumbnails\\Video\\" + hashName[0] + "\\" + hashName + ".tbn";
            fileExist = parent.Request("FileExists", ipString);

            if (fileExist[0] == "True")
            {
                try
                {
                    downloadData = parent.Request("FileDownload", ipString);

                    // Convert Base64 String to byte[]
                    byte[] imageBytes = Convert.FromBase64String(downloadData[0]);
                    MemoryStream ms = new MemoryStream(imageBytes, 0,
                      imageBytes.Length);

                    // Convert byte[] to Image
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    retThumbnail = Image.FromStream(ms, true);
                }
                catch { }
            }

            return retThumbnail;
        }

        public string GetVideoPath(string movieName)
        {
            string tempString;
            string[] tempStringList;

            string condition = (movieName == null) ? "" : " WHERE C00 LIKE '%%" + movieName + "%%'";
            tempStringList = parent.Request("QueryVideoDatabase", "SELECT strpath FROM movieview " + condition);
            tempString = tempStringList[0];
            tempString += "VIDEO_TS.IFO";
            return tempString;
        }

        public string[] GetVideoNames(string searchString)
        {
            string condition = (searchString == null) ? "" : " WHERE C00 LIKE '%%" + searchString + "%%'";
            return parent.Request("QueryVideoDatabase", "SELECT C00 FROM movie " + condition);
        }

        public string[] GetVideoNames()
        {
            return this.GetVideoNames(null);
        }

        public string[] GetVideoYears(string searchString)
        {
            string condition = (searchString == null) ? "" : " WHERE C00 LIKE '%%" + searchString + "%%'";
            return parent.Request("QueryVideoDatabase", "SELECT C07 FROM movie " + condition);
        }

        public string[] GetVideoYears()
        {
            return this.GetVideoYears(null);
        }

        public string[] GetVideoIMDB(string searchString)
        {
            string condition = (searchString == null) ? "" : " WHERE C00 LIKE '%%" + searchString + "%%'";
            return parent.Request("QueryVideoDatabase", "SELECT C09 FROM movie " + condition);
        }

        public string[] GetVideoIMDB()
        {
            return this.GetVideoIMDB(null);
        }

        public string[] GetVideoIds(string searchString)
        {
            string condition = (searchString == null) ? "" : " WHERE C00 LIKE '%%" + searchString + "%%'";
            return parent.Request("QueryVideoDatabase", "SELECT idMovie FROM movie" + condition + " ORDER BY idMovie");
        }

        public string[] GetVideoIds()
        {
            return this.GetVideoIds(null);
        }

        public string[] GetVideoLibraryInfo(string videoID)
        {
            string condition = (videoID == null) ? "" : " WHERE C09 LIKE '%%" + videoID + "%%'";
            return parent.Request("QueryVideoDatabase", "SELECT * FROM movie " + condition);
        }

        public void sendAction(string buttonAction)
        {
            parent.Request("action", buttonAction);
        }
    }
}
