using System;
using System.IO;
using System.Reflection;
using System.Xml;
using static System.Int32;

namespace ShopWebsite.Configuration
{
    public static class Configuration
    {
        public static string DbProvider { get; set; }
        public static string ConnectionString { get; set; }
        public static int HowManyProductsCreateInInitialize { get; set; }
        public static int HowManyEmployeesCreateInInitialize { get; set; }
        public static int HowManyIndClientsCreateInInitialize { get; set; }
        public static int HowManyCompaniesCreateInInitialize { get; set; }
        public static string CreateTableExceptionLogsCommand { get; set; }
        public static string InsertToTableExceptionLogsCommand { get; set; }
        public static string CreateLogsSchema { get; set; }

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
                            reader.ReadToFollowing("dbProvider");
                            reader.MoveToAttribute("value");
                            string ab = reader.Value;
                            DbProvider = ab;

                            reader.ReadToFollowing("connectionString");
                            reader.MoveToAttribute("value");
                            string cs = reader.Value;
                            ConnectionString = cs;

                            reader.ReadToFollowing("initializeProduct");
                            reader.MoveToAttribute("value");
                            string a = reader.Value;

                            HowManyProductsCreateInInitialize = Parse(a);
                            reader.ReadToFollowing("initializeEmployees");
                            reader.MoveToAttribute("value");
                            string b = reader.Value;
                            HowManyEmployeesCreateInInitialize = Parse(b);

                            reader.ReadToFollowing("initializeCompany");
                            reader.MoveToAttribute("value");
                            string c = reader.Value;
                            HowManyCompaniesCreateInInitialize = Parse(c);

                            reader.ReadToFollowing("initializeIndClient");
                            reader.MoveToAttribute("value");
                            string d = reader.Value;
                            HowManyIndClientsCreateInInitialize = Parse(d);

                            reader.ReadToFollowing("createTable");
                            reader.MoveToAttribute("value");
                            string e = reader.Value;
                            CreateTableExceptionLogsCommand = e;

                            reader.ReadToFollowing("insertCommand");
                            reader.MoveToAttribute("value");
                            string f = reader.Value;
                            InsertToTableExceptionLogsCommand = f;

                            reader.ReadToFollowing("createLogsSchema");
                            reader.MoveToAttribute("value");
                            string g = reader.Value;
                            CreateLogsSchema = g;
                        }
                    }
                }
                else
                {
                    DbProvider = string.Empty;
                    ConnectionString = string.Empty;
                    HowManyProductsCreateInInitialize = 0;
                    HowManyEmployeesCreateInInitialize = 0;
                    HowManyIndClientsCreateInInitialize = 0;
                    HowManyCompaniesCreateInInitialize = 0;
                    CreateTableExceptionLogsCommand = string.Empty;
                    InsertToTableExceptionLogsCommand = string.Empty;
                    CreateLogsSchema = string.Empty;
                    throw new Exception("Something goes wrong with configuration.xml and with Configuration class.");
                }
        }
    }
}
