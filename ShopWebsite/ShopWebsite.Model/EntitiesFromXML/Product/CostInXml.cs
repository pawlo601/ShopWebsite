using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Model.EntitiesFromXML.Product
{
    public class CostInXml
    {
        #region variables
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("productId")]
        public int ProductId { get; set; }
        [XmlAttribute("tax")]
        public decimal Tax { get; set; }
        [XmlArray(ElementName = "prices")]
        [XmlArrayItem("price", Type = typeof(PriceInXml))]
        public IList<PriceInXml> Prices { get; set; }
        #endregion

        public static Cost TransformFromXmlToClass(CostInXml a)
        {
            var d = a.Prices;
            List<Price> list = d.Select(priceInXml => PriceInXml.TransformFromXmlToClass(priceInXml)).ToList();
            return new Cost()
            {
                Id = a.Id,
                ProductId = a.ProductId,
                Tax = a.Tax,
                Prices = list
            };
        }
        public static CostInXml TransformFromClassToXml(Cost a)
        {
            var d = a.Prices;
            List<PriceInXml> list = d.Select(price => PriceInXml.TransformFromClassToXml(price)).ToList();
            return new CostInXml()
            {
                Id = a.Id,
                ProductId = a.ProductId,
                Tax = a.Tax,
                Prices = list
            };
        }
    }
}
