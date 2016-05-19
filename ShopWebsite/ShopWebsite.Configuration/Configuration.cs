using System;
using System.IO;
using System.Reflection;
using System.Xml;
using static System.Int32;

namespace ShopWebsite.Configuration
{
    public static class Configuration
    {
        public static string ConnectionString { get; set; }
        public static bool ReloadDatabase { get; set; }
        public static int HowManyProductsCreateInInitialize { get; set; }
        public static int HowManyEmployeesCreateInInitialize { get; set; }

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
                            reader.ReadToFollowing("initializeProduct");
                            reader.MoveToAttribute("value");
                            string a = reader.Value;
                            HowManyProductsCreateInInitialize = Parse(a);
                            reader.ReadToFollowing("initializeEmployees");
                            reader.MoveToAttribute("value");
                            string b = reader.Value;
                            HowManyEmployeesCreateInInitialize = Parse(b);
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
