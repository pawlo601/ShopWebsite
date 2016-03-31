using ShopWebsite.Model.Entities;
using System.Xml.Serialization;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class PositionInTheOrderInXml
    {
        [XmlAttribute("id")]
        public int PositionInTheOrderId { get; set; }
        [XmlAttribute("product_id")]
        public int ProductId { get; set; }
        [XmlAttribute("customerid")]
        public int CustomerId { get; set; }
        [XmlAttribute("quantity")]
        public int Quantity { get; set; }
        public static PositionInTheOrder TransformFromXmlToClass(PositionInTheOrderInXml a)
        {
            return new PositionInTheOrder(a.PositionInTheOrderId, a.ProductId, a.CustomerId, a.Quantity);
        }
    }
}
