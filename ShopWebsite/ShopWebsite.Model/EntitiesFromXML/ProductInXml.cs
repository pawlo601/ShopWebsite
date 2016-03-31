using ShopWebsite.Model.Entities;
using System.Xml.Serialization;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class ProductInXml
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
        [XmlAttribute("quantity")]
        public decimal Quantity { get; set; }
        [XmlAttribute("price")]
        public decimal Price { get; set; }

        public static Product TransformFromXmlToClass(ProductInXml a)
        {
            return new Product()
            {
                ProductId = a.Id,
                PricePerUnit = a.Price,
                ProductDescription = a.Description,
                ProductName = a.Name,
                QuantityPerUnit = a.Quantity
            };
        }
    }
}
