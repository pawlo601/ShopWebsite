using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Model.EntitiesFromXML.Product
{
    public class CurrencyInXml
    {
        #region variables
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("shortcut")]
        public string ShortCut { get; set; }
        [XmlAttribute("exchangeToDolar")]
        public decimal ExchangeToDolar { get; set; }
        #endregion

        public static Currency TransformFromXmlToClass(CurrencyInXml a)
        {
            return new Currency()
            {
                Id = a.Id,
                Name = a.Name,
                ShortCut = a.ShortCut,
                ExchangeToDolar = a.ExchangeToDolar
            };
        }

        public static CurrencyInXml TransformFromClassToXml(Currency a)
        {
            return new CurrencyInXml()
            {
                Id = a.Id,
                Name = a.Name,
                ShortCut = a.ShortCut,
                ExchangeToDolar = a.ExchangeToDolar
            };
        }
    }
}
