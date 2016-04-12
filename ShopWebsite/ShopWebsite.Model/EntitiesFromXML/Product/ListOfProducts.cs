using System.Collections.Generic;
using System.Xml.Serialization;

namespace ShopWebsite.Model.EntitiesFromXML.Product
{
    public class ListOfProducts
    {
        [XmlElement("Product")]
        public List<ProductInXml> ProductList = new List<ProductInXml>();
    }
}
