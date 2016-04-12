using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Model.EntitiesFromXML.Product
{
    public class UnitInXml
    {
        #region variables
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("shortcut")]
        public string ShortCut { get; set; }
        #endregion

        public static Unit TransformFromXmlToClass(UnitInXml a)
        {
            return new Unit()
            {
                Id = a.Id,
                Name = a.Name,
                ShortCut = a.ShortCut
            };
        }

        public static UnitInXml TransformFromClassToXml(Unit a)
        {
            return new UnitInXml()
            {
                Id = a.Id,
                Name = a.Name,
                ShortCut = a.ShortCut
            };
        }
    }
}
