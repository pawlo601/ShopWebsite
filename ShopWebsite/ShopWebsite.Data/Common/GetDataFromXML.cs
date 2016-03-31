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
                List<Product> pr = new List<Product>();
                foreach (var a in xmlData.ProductList)
                {
                    pr.Add(ProductInXml.TransformFromXmlToClass(a));
                }
                return pr;
            }
        }

        public static List<Order> GetOrders()
        {
            string result;
            var aasd = typeof(GetDataFromXml).Assembly.GetManifestResourceNames();
            using (Stream stream = typeof(GetDataFromXml).Assembly.GetManifestResourceStream("ShopWebsite.Data.DataFromXML.Orders.xml"))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            using (TextReader sr = new StringReader(result))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(ListOfOrders));
                object obj = deserializer.Deserialize(sr);

                ListOfOrders xmlData = (ListOfOrders)obj;
                List<Order> pr = new List<Order>();
                foreach (var a in xmlData.OrderList)
                {
                    pr.Add(OrderInXml.TransformFromXmlToClass(a));
                }
                return pr;
            }
        }
    }
}
