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
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(ListOfProducts));
                TextReader reader = new StreamReader(@"DataInXML/Products.xml");
                object obj = deserializer.Deserialize(reader);
                ListOfProducts XmlData = (ListOfProducts)obj;
                reader.Close();
                List<Product> pr = new List<Product>();
                foreach(var a in XmlData.productList)
                {
                    pr.Add(ProductFromXML.GetProductFromProductXML(a));
                }
                return pr;
            }
            catch (Exception)
            {
                return new List<Product>();
            }          
        }
    }
}
