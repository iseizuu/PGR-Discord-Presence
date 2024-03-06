using System.Collections.Generic;
using System.IO;
using System.Xml;
namespace XMLReader
{
    public static class XMLParser
    {

        public static XmlDocument LoadDocument(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("XML Document wasn't found at path!");
            }
            XmlDocument d = new XmlDocument();
            d.Load(path);
            return d;
        }

        public static string[] FindByTag(string NodeName, XmlDocument document)
        {
            XmlNodeList tags = document.GetElementsByTagName(@NodeName);
            if (tags.Count < 1)
            {
                return null;
            }
            else
            {
                List<string> l = new List<string>();

                foreach (XmlNode n in tags)
                {
                    l.Add(n.InnerText);
                }

                string[] f = l.ToArray();
                l.Clear();
                return f;
            }
        }
    }

    public struct XmlSettings
    {
        public string appPath { get; set; }
        public string inLauncherMessage { get; set; }
        public string NoNameMessage { get; set; }
        public string inGameMessage { get; set; }
    }
}