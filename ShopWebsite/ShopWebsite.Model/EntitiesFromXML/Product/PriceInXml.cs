using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Model.EntitiesFromXML.Product
{
    public class PriceInXml
    {
        #region variables
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("value")]
        public decimal Value { get; set; }
        [XmlElement(ElementName = "currency")]
        public CurrencyInXml Currency { get; set; }
        #endregion

        public static Price TransformFromXmlToClass(PriceInXml a)
        {
            return new Price()
            {
                Id = a.Id,
                Value = a.Value,
                Currency = CurrencyInXml.TransformFromXmlToClass(a.Currency)
            };
        }

        public static PriceInXml TransformFromClassToXml(Price a)
        {
            return new PriceInXml()
            {
                Id = a.Id,
                Value = a.Value,
                Currency = CurrencyInXml.TransformFromClassToXml(a.Currency)
            };
        }
    }
}
