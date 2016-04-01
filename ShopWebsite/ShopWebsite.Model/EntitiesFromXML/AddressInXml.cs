using System.Xml.Serialization;
using ShopWebsite.Model.Entities;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class AddressInXml
    {
        [XmlAttribute("id")]
        public int AddressId { get; set; }
        [XmlAttribute("street")]
        public string Street { get; set; }
        [XmlAttribute("number_of_building")]
        public string NumberOfBuilding { get; set; }
        [XmlAttribute("city")]
        public string City { get; set; }
        [XmlAttribute("postal_code")]
        public string PostalCode { get; set; }
        [XmlAttribute("country")]
        public string Country { get; set; }

        public static Address TransformFromXmlToClass(AddressInXml a)
        {
            return new Address()
            {
                AddressId = a.AddressId,
                City = a.City,
                Country = a.Country,
                NumberOfBuilding = a.NumberOfBuilding,
                PostalCode = a.PostalCode,
                Street = a.Street
            };
        }
    }
}
