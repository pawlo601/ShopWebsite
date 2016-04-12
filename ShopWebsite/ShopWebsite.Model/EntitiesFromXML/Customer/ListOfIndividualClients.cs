using System.Collections.Generic;
using System.Xml.Serialization;

namespace ShopWebsite.Model.EntitiesFromXML.Customer
{
    public class ListOfIndividualClients
    {
        [XmlElement("IndividualClient")]
        public List<IndividualClientInXml> IndividualClientList = new List<IndividualClientInXml>();
    }
}
