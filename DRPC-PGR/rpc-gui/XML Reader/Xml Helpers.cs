using PGRRPC;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace XMLReader.Helpers
{
    public static class xml
    {
        public static string GetFileNameFromPath(string path)
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
                MessageBox.Show("settings.xml is not found, please reinstall");
                PGRRPC_MAIN.stop();

            }
            // Get all settings as strings
            System.Xml.XmlDocument value = XMLParser.LoadDocument(path);
            string NoNameMessage = XMLParser.FindByTag("NoNameMessage", value)[0];
            string appPath = XMLParser.FindByTag("ExePath", value)[0];

            // Convert, store and return
            XmlSettings setting = new XmlSettings();
            setting.NoNameMessage = NoNameMessage;
            setting.appPath = appPath;
            return setting;
        }
        public static void SaveToXml(string settings)
        {
            new XDocument(
                new XElement("config",
                    new XElement("AppConfig",
                        new XComment(" DO NOT CHANGE THESE SETTINGS UNLESS YOU KNOW WHAT YOU ARE DOING! "),
                        new XElement("ExePath", settings),
                        new XElement("NoNameMessage", "NEXT VERSION")
                        )
                    )
                ).Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.xml"));
        }
        public static void CreateShortcut(string targetPath, string shortcutLocation)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.TargetPath = targetPath;
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
            shortcut.Description = "Punishing: Discord Presence";
            shortcut.IconLocation = targetPath;
            shortcut.Save();

            Console.WriteLine("Shortcut created successfully.");
        }
    }
}
