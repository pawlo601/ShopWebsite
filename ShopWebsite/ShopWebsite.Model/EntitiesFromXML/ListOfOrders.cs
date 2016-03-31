using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ShopWebsite.Model.EntitiesFromXML
{
    [Serializable]
    public class ListOfOrders
    {
        [XmlElement("Order")]
        public List<OrderInXml> OrderList = new List<OrderInXml>();
    }
}
