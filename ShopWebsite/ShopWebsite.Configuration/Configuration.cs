﻿using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace ShopWebsite.Configuration
{
    public static class Configuration
    {
        public static string ConnectionString { get; set; }
        public static bool ReloadDatabase { get; set; }

        static Configuration()
        {
            var _assembly = Assembly.GetExecutingAssembly();
            using (Stream stream =
                _assembly.GetManifestResourceStream(
                    "ShopWebsite.Configuration.configuration.xml"))
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
                    throw new Exception("Something is wrong with ConfigFile.xml and Configuration class.");
                }
        }
    }
}
