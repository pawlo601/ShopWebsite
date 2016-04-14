using System.Collections.Generic;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class ListOfUnits
    {
        [XmlElement("Product")]
        public List<Unit> UnitList = new List<Unit>();
    }
}
