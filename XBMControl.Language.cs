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
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Resources;

namespace XBMControl.Language
{
    public class XBMCLanguage
    {
        //private string languageFilePath;
        private XmlDocument languageFile;
        private XmlNode languageNode;
        private DirectoryInfo languageDir;

        public XBMCLanguage()
        {
            languageFile   = new XmlDocument();
            languageDir    = new DirectoryInfo(Path.GetDirectoryName(Application.ExecutablePath).ToString() + "\\language\\");
        }

        public string[] GetAvailableLanguages()
        {
            string[] languages = new string[4];

            languages[0] = "english";
            languages[1] = "francais";
            languages[2] = "nederlands";
            languages[3] = "german";
            return languages;
        }

        public void SetLanguage(string language)
        {
            string tempString = null;

            if (language == "english")
                tempString = global::XBMControl.Properties.Resources.english;
            else if (language == "francais")
                tempString = global::XBMControl.Properties.Resources.francais;
            else if (language == "nederlands")
                tempString = global::XBMControl.Properties.Resources.nederlands;
            else if (language == "german")
                tempString = global::XBMControl.Properties.Resources.german;
            else
                tempString = global::XBMControl.Properties.Resources.english;

            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(tempString));
            languageFile.Load(stream);
        }

        public string GetString(string node)
        {
            languageNode = languageFile.DocumentElement.SelectSingleNode("/language/" + node);
            return languageNode.InnerText.Replace("\\n", "\n");
        }
    }
}
