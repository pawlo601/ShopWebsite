using System;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.EntitiesFromXML;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Product;
using ShopWebsite.Model.EntitiesFromXML.Product;

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
                    throw new Exception("Something is wrong with ConfigFile.xml and GetDataFromXml.");
                }
        }
        public static List<Product> GetProducts()
        {
            using (Stream stream =
                typeof(GetDataFromXml).Assembly.GetManifestResourceStream(
                    "ShopWebsite.Data.DataFromXML.Products.xml"))
                if (stream != null)
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string result = sr.ReadToEnd();
                        using (TextReader tr = new StringReader(result))
                        {
                            XmlSerializer deserializer = new XmlSerializer(typeof (ListOfProducts));
                            var obj = deserializer.Deserialize(tr);
                            ListOfProducts xmlData = (ListOfProducts) obj;
                            return xmlData.ProductList.Select(ProductInXml.TransformFromXmlToClass).ToList();
                        }
                    }
                }
                else
                {
                    return new List<Product>();
                }
        }
        public static List<Company> GetCompanies()
        {
            using (Stream stream =
                typeof(GetDataFromXml).Assembly.GetManifestResourceStream(
                    "ShopWebsite.Data.DataFromXML.Companies.xml"))
                if (stream != null)
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string result = sr.ReadToEnd();
                        using (TextReader tr = new StringReader(result))
                        {
                            XmlSerializer deserializer = new XmlSerializer(typeof (ListOfCompanies));
                            var obj = deserializer.Deserialize(tr);
                            ListOfCompanies xmlData = (ListOfCompanies) obj;
                            return xmlData.CompanyList.Select(CompanyInXml.TransformFromXmlToClass).ToList();
                        }
                    }
                }
                else
                {
                    return new List<Company>();
                }
        }
        public static List<IndividualClient> GetIndividualsClients()
        {
            using (Stream stream =
                typeof(GetDataFromXml).Assembly.GetManifestResourceStream(
                    "ShopWebsite.Data.DataFromXML.IndividualClients.xml"))
                if (stream != null)
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string result = sr.ReadToEnd();
                        using (TextReader tr = new StringReader(result))
                        {
                            XmlSerializer deserializer = new XmlSerializer(typeof(ListOfIndividualClients));
                            var obj = deserializer.Deserialize(tr);
                            ListOfIndividualClients xmlData = (ListOfIndividualClients)obj;
                            return
                                xmlData.IndividualClientList.Select(IndividualClientInXml.TransformFromXmlToClass)
                                    .ToList();
                        }
                    }
                }
                else
                {
                    return new List<IndividualClient>();
                }
        }      
    }
}
