using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShopWebsite.Model.EntitiesFromXML
{
    [Serializable]
    public class ListOfOrders
    {
        [XmlElement("Order")]
        public List<OrderFromXML> orderList = new List<OrderFromXML>();
        public ListOfOrders() { }
    }
}
