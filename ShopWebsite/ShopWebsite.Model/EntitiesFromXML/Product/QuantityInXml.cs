using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Model.EntitiesFromXML.Product
{
    public class QuantityInXml
    {
        #region variables
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("value")]
        public decimal Value { get; set; }
        [XmlElement(ElementName = "unit")]
        public UnitInXml Unit { get; set; }
        #endregion

        public static Quantity TransformFromXmlToClass(QuantityInXml a)
        {
            return new Quantity()
            {
                Id = a.Id,
                Value = a.Value,
                Unit = UnitInXml.TransformFromXmlToClass(a.Unit)
            };
        }

        public static QuantityInXml TransformFromClassToXml(Quantity a)
        {
            return new QuantityInXml()
            {
                Id = a.Id,
                Value = a.Value,
                Unit = UnitInXml.TransformFromClassToXml(a.Unit)
            };
        }
    }
}
