using ShopWebsite.Model.Entities;
using System.Xml.Serialization;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class PositionInTheOrderFromXML
    {
        [XmlAttribute("id")]
        public int PositionInTheOrderID { get; set; }
        [XmlAttribute("product_id")]
        public int ProductID { get; set; }
        [XmlAttribute("customerid")]
        public int CustomerID { get; set; }
        [XmlAttribute("quantity")]
        public int Quantity { get; set; }
        public static PositionInTheOrder GetPositionInTheOrderFromPositionInTheOrderXML(PositionInTheOrderFromXML a)
        {
            return new PositionInTheOrder(a.PositionInTheOrderID, a.ProductID, a.CustomerID, a.Quantity);
        }
    }
}
