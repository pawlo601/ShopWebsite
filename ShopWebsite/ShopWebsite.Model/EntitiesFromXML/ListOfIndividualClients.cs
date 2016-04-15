using System.Collections.Generic;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Customer;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class ListOfIndividualClients
    {
        [XmlElement("IndividualClient")]
        public List<IndividualClient> IndividualClientList = new List<IndividualClient>();
    }
}
