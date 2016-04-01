﻿using System.Collections.Generic;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public abstract class CustomerInXml
    {
        [XmlAttribute("id")]
        public int CustomerId { get; set; }
        [XmlAttribute("contact_title")]
        public string ContactTitle { get; set; }
        [XmlElement(ElementName = "contact_address")]
        public Address ContactAddress { get; set; }
        [XmlElement(ElementName = "residential_address")]
        public Address ResidentialAddress { get; set; }
        [XmlAttribute("first_mail")]
        public string Mail1 { get; set; }
        [XmlAttribute("second_mail")]
        public string Mail2 { get; set; }
        [XmlAttribute("first_phone_number")]
        public string Phone1 { get; set; }
        [XmlAttribute("second_phone_number")]
        public string Phon2 { get; set; }
        [XmlArray(ElementName = "oreders")]
        [XmlArrayItem("order", Type = typeof(Order))]
        public List<OrderInXml> Orders { get; set; }
    }
}
    