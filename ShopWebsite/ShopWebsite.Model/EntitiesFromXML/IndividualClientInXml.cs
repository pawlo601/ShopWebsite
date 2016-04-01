using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities;

namespace ShopWebsite.Model.EntitiesFromXML
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
            List<Order> orders = new List<Order>();
            foreach (OrderInXml orderInXml in list)
            {
                orders.Add(OrderInXml.TransformFromXmlToClass(orderInXml));
            }
            return new IndividualClient()
            {
                ContactAddress = a.ContactAddress,
                ContactTitle = a.ContactTitle,
                CustomerId = a.CustomerId,
                Mail1 = a.Mail1,
                Mail2 = a.Mail2,
                Orders = orders,
                Phone1 = a.Phone1,
                Phone2 = a.Phon2,
                ResidentialAddress = a.ResidentialAddress,
                Birthday = a.Birthday,
                Name = a.Name,
                PeselNumber = a.PeselNumber,
                Surname = a.Surname
            };
        }
    }
}
