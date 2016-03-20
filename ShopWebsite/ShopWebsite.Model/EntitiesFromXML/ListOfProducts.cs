using ShopWebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class ListOfProducts
    {
        [XmlElement("Product")]
        public List<ProductFromXML> productList = new List<ProductFromXML>();
    }
}
