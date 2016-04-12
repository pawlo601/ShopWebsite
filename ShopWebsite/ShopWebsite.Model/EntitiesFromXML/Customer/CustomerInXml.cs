using System.Collections.Generic;
using System.Xml.Serialization;
using ShopWebsite.Model.EntitiesFromXML.Order;

namespace ShopWebsite.Model.EntitiesFromXML.Customer
{
    public abstract class CustomerInXml
    {
        [XmlAttribute("id")]
        public int CustomerId { get; set; }
        [XmlAttribute("contact_title")]
        public string ContactTitle { get; set; }
        [XmlElement(ElementName = "contact_address")]
        public AddressInXml ContactAddress { get; set; }
        [XmlElement(ElementName = "residential_address")]
        public AddressInXml ResidentialAddress { get; set; }
        [XmlAttribute("first_mail")]
        public string Mail1 { get; set; }
        [XmlAttribute("second_mail")]
        public string Mail2 { get; set; }
        [XmlAttribute("first_phone_number")]
        public string Phone1 { get; set; }
        [XmlAttribute("second_phone_number")]
        public string Phon2 { get; set; }
        [XmlArray(ElementName = "oreders")]
        [XmlArrayItem("order", Type = typeof(OrderInXml))]
        public List<OrderInXml> Orders { get; set; }
    }
}
    