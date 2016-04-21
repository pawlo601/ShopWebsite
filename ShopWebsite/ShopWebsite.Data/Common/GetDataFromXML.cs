using System;
using System.IO;
using System.Xml;

namespace ShopWebsite.Data.Common
{
    public static class GetDataFromXml
    {
        public static string ConnectionString { get; set; }
        public static bool ReloadDatabase { get; set; }
        static GetDataFromXml()
        {
            using (Stream stream =
                typeof(GetDataFromXml).Assembly.GetManifestResourceStream(
                    "ShopWebsite.Data.ConfigFile.xml"))
                if (stream != null)
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        var xmlString = sr.ReadToEnd();
                        using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                        {
                            reader.ReadToFollowing("connectionString");
                            reader.MoveToAttribute("value");
                            string cs = reader.Value;
                            ConnectionString = cs;
                            reader.ReadToFollowing("reloadDatabase");
                            reader.MoveToAttribute("value");
                            cs = reader.Value;
                            switch (cs)
                            {
                                case "true":
                                    ReloadDatabase = true;
                                    break;
                                default:
                                    ReloadDatabase = false;
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Something is wrong with ConfigFile.xml and GetDataFromXml class.");
                }
        }
    }
}
