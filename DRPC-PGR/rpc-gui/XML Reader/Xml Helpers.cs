using PGRRPC;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XMLReader.Helpers
{
    public static class xml
    {

        public static string regexExe(string path)
        {
            // Pattern regex
            string pattern = @"\\([^\\]+)$";

            Match match = Regex.Match(path, pattern);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return string.Empty;
        }

        public static XmlSettings ReadSettings()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.xml");
            if (!File.Exists(path))
            {
                // atleast this is working!!
                MessageBox.Show("Missing xml file, please restart..");
                new XDocument(
                    new XElement("config",
                        new XElement("AppConfig",
                            new XComment(" DO NOT CHANGE THESE SETTINGS UNLESS YOU KNOW WHAT YOU ARE DOING! "),
                            new XElement("ExePath"),
                            new XElement("NoNameMessage", "NEXT VERSION"),
                            new XElement("inLauncherMessage"),
                            new XElement("inGameMessage")
                    ))).Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.xml"));
                Environment.Exit(0);

            }
            // Get all settings as strings
            XmlDocument value = XMLParser.LoadDocument(path);
            string NoNameMessage = XMLParser.FindByTag("NoNameMessage", value)[0];
            string appPath = XMLParser.FindByTag("ExePath", value)[0];
            string inGameMessage = XMLParser.FindByTag("inGameMessage", value)[0];
            string inLauncherMessage = XMLParser.FindByTag("inLauncherMessage", value)[0];

            // Convert, store and return
            XmlSettings setting = new XmlSettings();
            setting.appPath = appPath;
            setting.NoNameMessage = NoNameMessage;
            setting.inGameMessage = inGameMessage;
            setting.inLauncherMessage = inLauncherMessage;
            return setting;
        }

        public static void SaveToXml(XmlSettings settings)
        {
            new XDocument(
                new XElement("config",
                    new XElement("AppConfig",
                        new XComment(" DO NOT CHANGE THESE SETTINGS UNLESS YOU KNOW WHAT YOU ARE DOING! "),
                        new XElement("ExePath", settings.appPath),
                        new XElement("NoNameMessage", "NEXT VERSION"),
                        new XElement("inLauncherMessage", settings.inLauncherMessage),
                        new XElement("inGameMessage", settings.inGameMessage)
                        )
                    )
                ).Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.xml"));
        }
    }
}
