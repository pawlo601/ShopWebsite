using System.Collections.Generic;
using System.Xml.Serialization;

namespace ShopWebsite.Model.EntitiesFromXML.Customer
{
    public class ListOfCompanies
    {
        [XmlElement("Company")]
        public List<CompanyInXml> CompanyList = new List<CompanyInXml>();
    }
}
