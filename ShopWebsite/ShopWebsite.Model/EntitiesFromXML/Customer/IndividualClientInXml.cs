using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Customer;
using ShopWebsite.Model.EntitiesFromXML.Order;

namespace ShopWebsite.Model.EntitiesFromXML.Customer
{
    public class IndividualClientInXml:CustomerInXml
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("surname")]
        public string Surname { get; set; }
        [XmlAttribute("birthday")]
        public DateTime Birthday { get; set; }
        [XmlAttribute("pesel_number")]
        public string PeselNumber { get; set; }

        public static IndividualClient TransformFromXmlToClass(IndividualClientInXml a)
        {
            var list = a.Orders;
            List<Entities.Order.Order> orders = list.Select(orderInXml => OrderInXml.TransformFromXmlToClass(orderInXml)).ToList();
            return new IndividualClient()
            {
                ContactAddress = AddressInXml.TransformFromXmlToClass(a.ContactAddress),
                ContactTitle = a.ContactTitle,
                CustomerId = a.CustomerId,
                Mail1 = a.Mail1,
                Mail2 = a.Mail2,
                Orders = orders,
                Phone1 = a.Phone1,
                Phone2 = a.Phon2,
                ResidentialAddress = AddressInXml.TransformFromXmlToClass(a.ResidentialAddress),
                Birthday = a.Birthday,
                Name = a.Name,
                PeselNumber = a.PeselNumber,
                Surname = a.Surname
            };
        }
    }
}
