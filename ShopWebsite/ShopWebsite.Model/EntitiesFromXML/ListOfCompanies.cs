using System.Collections.Generic;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Customer;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class ListOfCompanies
    {
        [XmlElement("Company")]
        public List<Company> CompanyList = new List<Company>();
    }
}
