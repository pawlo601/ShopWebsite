using ShopWebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ShopWebsite.Model.EntitiesFromXML
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
        public static Order TransformFromXmlToClass(OrderInXml a)
        {
            List<PositionInTheOrder> b = new List<PositionInTheOrder>();
            foreach (var f in a.OrderedItems)
            {
                b.Add(PositionInTheOrderInXml.TransformFromXmlToClass(f));
            }
            return new Order()
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
