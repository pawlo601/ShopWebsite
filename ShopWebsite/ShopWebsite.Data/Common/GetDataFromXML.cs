using ShopWebsite.Model.Entities;
using ShopWebsite.Model.EntitiesFromXML;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ShopWebsite.Data.Common
{
    public static class GetDataFromXml
    {
        public static List<Product> GetProducts()
        {
            string result;
            //var aasd = typeof(GetDataFromXml).Assembly.GetManifestResourceNames();
            using (Stream stream = typeof(GetDataFromXml).Assembly.GetManifestResourceStream("ShopWebsite.Data.DataFromXML.Products.xml"))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            using (TextReader sr = new StringReader(result))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(ListOfProducts));
                object obj = deserializer.Deserialize(sr);

                ListOfProducts xmlData = (ListOfProducts)obj;
                List<Product> list = new List<Product>();
                foreach (var a in xmlData.ProductList)
                {
                    list.Add(ProductInXml.TransformFromXmlToClass(a));
                }
                return list;
            }
        }

        public static List<Company> GetCompanies()
        {
            string result;
            using (Stream stream = typeof(GetDataFromXml).Assembly.GetManifestResourceStream("ShopWebsite.Data.DataFromXML.Companies.xml"))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            using (TextReader sr = new StringReader(result))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(ListOfProducts));
                object obj = deserializer.Deserialize(sr);

                ListOfCompanies xmlData = (ListOfCompanies)obj;
                List<Company> list = new List<Company>();
                foreach (var a in xmlData.CompanyList)
                {
                    list.Add(CompanyInXml.TransformFromXmlToClass(a));
                }
                return list;
            }
        }

        public static List<IndividualClient> GetIndividualsClients()
        {
            string result;
            using (Stream stream = typeof(GetDataFromXml).Assembly.GetManifestResourceStream("ShopWebsite.Data.DataFromXML.IndividualClients.xml"))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            using (TextReader sr = new StringReader(result))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof (ListOfProducts));
                object obj = deserializer.Deserialize(sr);

                ListOfIndividualClients xmlData = (ListOfIndividualClients) obj;
                List<IndividualClient> list = new List<IndividualClient>();
                foreach (var a in xmlData.IndividualClientList)
                {
                    list.Add(IndividualClientInXml.TransformFromXmlToClass(a));
                }
                return list;
            }
        } 
    }
}
