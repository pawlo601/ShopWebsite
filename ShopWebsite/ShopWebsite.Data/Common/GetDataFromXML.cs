using ShopWebsite.Model.Entities;
using ShopWebsite.Model.EntitiesFromXML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShopWebsite.Data.Common
{
    public static class GetDataFromXML
    {
        public static List<Product> GetProducts()
        {
            string result = string.Empty;
            var aasd = typeof(GetDataFromXML).Assembly.GetManifestResourceNames();
            using (Stream stream = typeof(GetDataFromXML).Assembly.GetManifestResourceStream("ShopWebsite.Data.DataFromXML.Products.xml"))
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

                ListOfProducts XmlData = (ListOfProducts)obj;
                List<Product> pr = new List<Product>();
                foreach (var a in XmlData.productList)
                {
                    pr.Add(ProductFromXML.GetProductFromProductXML(a));
                }
                return pr;
            }
        }

        public static List<Order> GetOrders()
        {
            string result = string.Empty;
            var aasd = typeof(GetDataFromXML).Assembly.GetManifestResourceNames();
            using (Stream stream = typeof(GetDataFromXML).Assembly.GetManifestResourceStream("ShopWebsite.Data.DataFromXML.Orders.xml"))
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

                ListOfOrders XmlData = (ListOfOrders)obj;
                List<Order> pr = new List<Order>();
                foreach (var a in XmlData.orderList)
                {
                    pr.Add(OrderFromXML.GetOrderFromOrderXML(a));
                }
                return pr;
            }
        }
    }
}
