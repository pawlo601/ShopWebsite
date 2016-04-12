using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Order;

namespace ShopWebsite.Model.EntitiesFromXML.Order
{
    public class OrderInXml
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("dateofsubmission")]
        public DateTime DateOfSubmission { get; set; }
        [XmlAttribute("status")]
        public string StatusOfOrder { get; set; }
        [XmlAttribute("value")]
        public decimal Value { get; set; }
        [XmlArray(ElementName = "items")]
        [XmlArrayItem("item", Type = typeof(PositionInTheOrderInXml))]
        public List<PositionInTheOrderInXml> OrderedItems { get; set; }
        public static Entities.Order.Order TransformFromXmlToClass(OrderInXml a)
        {
            List<PositionInTheOrder> b = a.OrderedItems.Select(f => PositionInTheOrderInXml.TransformFromXmlToClass(f)).ToList();
            return new Entities.Order.Order()
            {
                OrderId = a.Id,
                DateOfSubmission = a.DateOfSubmission,
                OrderedItems = b,
                StatusOfOrder = a.StatusOfOrder,
                Value = a.Value
            };
        }
    }
}
