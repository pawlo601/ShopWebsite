using System;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.EntitiesFromXML;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace ShopWebsite.Data.Common
{
    public static class GetDataFromXml
    {
        public static List<Product> GetProducts()
        {
            using (Stream stream =
                typeof(GetDataFromXml).Assembly.GetManifestResourceStream(
                    "ShopWebsite.Data.DataFromXML.Products.xml"))
            using (StreamReader sr = new StreamReader(stream))
            {
                string result = sr.ReadToEnd();
                using (TextReader tr = new StringReader(result))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(ListOfProducts));
                    var obj = deserializer.Deserialize(tr);
                    ListOfProducts xmlData = (ListOfProducts)obj;
                    return xmlData.ProductList.Select(ProductInXml.TransformFromXmlToClass).ToList();
                }
            }
        }
        public static List<Company> GetCompanies()
        {
            using (Stream stream =
                typeof(GetDataFromXml).Assembly.GetManifestResourceStream(
                    "ShopWebsite.Data.DataFromXML.Companies.xml"))
            using (StreamReader sr = new StreamReader(stream))
            {
                string result = sr.ReadToEnd();
                using (TextReader tr = new StringReader(result))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(ListOfCompanies));
                    var obj = deserializer.Deserialize(tr);
                    ListOfCompanies xmlData = (ListOfCompanies)obj;
                    return xmlData.CompanyList.Select(CompanyInXml.TransformFromXmlToClass).ToList();
                }
            }

        }
        public static List<IndividualClient> GetIndividualsClients()
        {
            using (Stream stream =
                typeof(GetDataFromXml).Assembly.GetManifestResourceStream(
                    "ShopWebsite.Data.DataFromXML.IndividualClients.xml"))
            using (StreamReader sr = new StreamReader(stream))
            {
                string result = sr.ReadToEnd();
                using (TextReader tr = new StringReader(result))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(ListOfIndividualClients));
                    var obj = deserializer.Deserialize(tr);
                    ListOfIndividualClients xmlData = (ListOfIndividualClients)obj;
                    return xmlData.IndividualClientList.Select(IndividualClientInXml.TransformFromXmlToClass).ToList();
                }
            }
        }

        public static string GetConnectionString()
        {

            using (Stream stream =
                typeof(GetDataFromXml).Assembly.GetManifestResourceStream(
                    "ShopWebsite.Data.ConfigFile.xml"))
            using (StreamReader sr = new StreamReader(stream))
            {
                var xmlString = sr.ReadToEnd();
                using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                {
                    reader.ReadToFollowing("connectionString");
                    reader.MoveToAttribute("value");
                    string cs = reader.Value;
                    return cs;
                }
            }

        }
        public static bool GetReloadDatabase()
        {
            using (Stream stream =
                typeof(GetDataFromXml).Assembly.GetManifestResourceStream(name: "ShopWebsite.Data.ConfigFile.xml"))
            using (StreamReader sr = new StreamReader(stream))
            {
                var xmlString = sr.ReadToEnd();
                using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                {
                    reader.ReadToFollowing("reloadDatabase");
                    reader.MoveToAttribute("value");
                    string cs = reader.Value;
                    switch (cs)
                    {
                        case "true":
                            return true;
                        default:
                            return false;
                    }
                }
            }
        }
    }
}
