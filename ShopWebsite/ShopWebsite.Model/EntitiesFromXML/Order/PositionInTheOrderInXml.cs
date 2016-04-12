using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Order;

namespace ShopWebsite.Model.EntitiesFromXML.Order
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
