using System.Collections.Generic;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class CompanyInXml:CustomerInXml
    {
        [XmlAttribute("company_name")]
        public string CompanyName { get; set; }
        [XmlAttribute("regon")]
        public string Regon { get; set; }
        [XmlAttribute("tax_id")]
        public string TaxId { get; set; }

        public static Company TransformFromXmlToClass(CompanyInXml a)
        {
            var list = a.Orders;
            List<Order> orders = new List<Order>();
            foreach (OrderInXml orderInXml in list)
            {
                orders.Add(OrderInXml.TransformFromXmlToClass(orderInXml));
            }
            return new Company()
            {
                ContactAddress = a.ContactAddress,
                CompanyName = a.CompanyName,
                ContactTitle = a.ContactTitle,
                CustomerId = a.CustomerId,
                Mail1 = a.Mail1,
                Mail2 = a.Mail2,
                Orders = orders,
                Phone1 = a.Phone1,
                Phone2 = a.Phon2,
                Regon = a.Regon,
                ResidentialAddress = a.ResidentialAddress,
                TaxId = a.TaxId
            };
        }
    }
}
