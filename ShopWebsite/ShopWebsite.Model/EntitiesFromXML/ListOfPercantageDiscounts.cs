using System.Collections.Generic;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class ListOfPercantageDiscounts
    {
        [XmlElement("percantage_discount")]
        public List<PercantageDiscount> PercantageDiscountList = new List<PercantageDiscount>();
    }
}
