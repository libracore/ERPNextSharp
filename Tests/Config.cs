using System.Xml;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Config
    {
        #region variables
        private string server = "localhost";
        private string username = string.Empty;
        private string password = string.Empty;

        #endregion

        #region constructor
        public Config(string file)
        {
            load(file);
        }
        #endregion

        #region variable access
        public string Server
        {
            get { return server; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        #endregion

        #region loader
        private void load(string filename)
        {
            try
            {
                /* directly get data with the XML reader class */
                // define setting
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                settings.IgnoreWhitespace = true;
                settings.IgnoreComments = true;
                // load reader
                XmlReader reader = XmlReader.Create(filename, settings);

                #region define element controller
                string elementName = "";
                string elementValue = "";
                string endName = "";
                #endregion

                // read the file
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // node is an element.
                            elementName = reader.Name;
                            elementValue = "";
                            break;
                        case XmlNodeType.Text: //read the element value.
                            elementValue = reader.Value;
                            break;
                        case XmlNodeType.EndElement: //whole node has been loaded.
                            endName = reader.Name;
                            // check if this was a node of interest
                            #region value parser
                            if (endName.ToLower() == "server")
                            {
                                try { server = elementValue; }
                                catch { /* do nothing */ }
                            }
                            else if (endName.ToLower() == "username")
                            {
                                try { username = elementValue; }
                                catch { /* do nothing */ }
                            }
                            else if (endName.ToLower() == "password")
                            {
                                try { password = elementValue; }
                                catch { /* do nothing */ }
                            }

                            // *** extend here ****
                            #endregion

                            break;
                    }
                }
            }
            catch
            {

            }
        }
        #endregion
    }

}
