using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Customer;
using ShopWebsite.Model.EntitiesFromXML.Order;

namespace ShopWebsite.Model.EntitiesFromXML.Customer
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
            List<Entities.Order.Order> orders = list.Select(orderInXml => OrderInXml.TransformFromXmlToClass(orderInXml)).ToList();
            return new Company()
            {
                ContactAddress = AddressInXml.TransformFromXmlToClass(a.ContactAddress),
                CompanyName = a.CompanyName,
                ContactTitle = a.ContactTitle,
                CustomerId = a.CustomerId,
                Mail1 = a.Mail1,
                Mail2 = a.Mail2,
                Orders = orders,
                Phone1 = a.Phone1,
                Phone2 = a.Phon2,
                Regon = a.Regon,
                ResidentialAddress = AddressInXml.TransformFromXmlToClass(a.ResidentialAddress),
                TaxId = a.TaxId
            };
        }
    }
}
