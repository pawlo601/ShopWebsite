using System.Collections.Generic;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class ListOfConstatntDiscounts
    {
        [XmlElement("constant_discount")]
        public List<ConstantDiscount> ConstantDiscountList = new List<ConstantDiscount>();
    }
}
