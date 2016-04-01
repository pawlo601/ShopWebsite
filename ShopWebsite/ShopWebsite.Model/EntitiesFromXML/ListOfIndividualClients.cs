using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShopWebsite.Model.EntitiesFromXML
{
    public class ListOfIndividualClients
    {
        [XmlElement("IndividualClient")]
        public List<IndividualClientInXml> IndividualClientList = new List<IndividualClientInXml>();
    }
}
