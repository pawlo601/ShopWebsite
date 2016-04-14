using System.Collections.Generic;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class ListOfCurrencies
    {
        [XmlElement("Product")]
        public List<Currency> CurrencyList = new List<Currency>();
    }
}
