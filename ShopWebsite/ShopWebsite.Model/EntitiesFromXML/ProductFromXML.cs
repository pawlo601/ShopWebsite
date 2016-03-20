using ShopWebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class ProductFromXML
    {
        [XmlAttribute("id")]
        public int ID { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
        [XmlAttribute("quantity")]
        public decimal Quantity { get; set; }
        [XmlAttribute("price")]
        public decimal Price { get; set; }

        public static Product GetProductFromProductXML(ProductFromXML a)
        {
            return new Product()
            {
                ProductID = a.ID,
                PricePerUnit = a.Price,
                ProductDescription = a.Description,
                ProductName = a.Name,
                QuantityPerUnit = a.Quantity
            };
        }
    }
}
