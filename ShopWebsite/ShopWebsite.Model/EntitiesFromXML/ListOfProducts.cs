using System.Collections.Generic;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class ListOfProducts
    {
        [XmlElement("product")]
        public List<Product> ProductList = new List<Product>();
    }
}
