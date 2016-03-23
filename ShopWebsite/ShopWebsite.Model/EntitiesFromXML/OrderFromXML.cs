using ShopWebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class OrderFromXML
    {
        [XmlAttribute("id")]
        public int ID { get; set; }
        [XmlAttribute("dateofsubmission")]
        public DateTime DateOfSubmission { get; set; }
        [XmlAttribute("status")]
        public string StatusOfOrder { get; set; }
        [XmlAttribute("value")]
        public decimal Value { get; set; }
        [XmlArray(ElementName = "items")]
        [XmlArrayItem("item", Type = typeof(PositionInTheOrderFromXML))]
        public List<PositionInTheOrderFromXML> OrderedItems { get; set; }
        public static Order GetOrderFromOrderXML(OrderFromXML a)
        {
            List<PositionInTheOrder> b = new List<PositionInTheOrder>();
            foreach (var f in a.OrderedItems)
            {
                b.Add(PositionInTheOrderFromXML.GetPositionInTheOrderFromPositionInTheOrderXML(f));
            }
            return new Order()
            {
                OrderID = a.ID,
                DateOfSubmission = a.DateOfSubmission,
                OrderedItems = b,
                StatusOfOrder = a.StatusOfOrder,
                Value = a.Value
            };
        }
    }
}
