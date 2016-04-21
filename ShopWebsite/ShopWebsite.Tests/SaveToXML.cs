using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopWebsite.Model.Entities.Customer;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Tests
{
#pragma warning disable 612, 618
    [TestClass]
    public class SaveToXML
    {
        [TestMethod]
        public void SaveListOfProductsToXML()
        {
            var a = new Product();
            List<Product> list = new List<Product> { a };
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Product>));
            TextWriter Filestream = new StreamWriter(@"D:\SaveListOfProductsToXML.xml");
            serialiser.Serialize(Filestream, list);
            Filestream.Close();
        }

        [TestMethod]
        public void ReadListOfProductsFromXml()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Product>));
            TextReader reader = new StreamReader(@"D:\SaveListOfProductsToXML.xml");
            object obj = deserializer.Deserialize(reader);
            List<Product> XmlData = (List<Product>)obj;
            reader.Close();
        }

        [TestMethod]
        public void SaveListOfCustomersToXML()
        {
            var a = new IndividualClient();
            List<IndividualClient> list = new List<IndividualClient> { a };
            XmlSerializer serialiser = new XmlSerializer(typeof(List<IndividualClient>));
            TextWriter Filestream = new StreamWriter(@"D:\SaveListOfIndividualClientsToXML.xml");
            serialiser.Serialize(Filestream, list);
            Filestream.Close();
        }

        [TestMethod]
        public void ReadListOfCustomersFromXml()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<IndividualClient>));
            TextReader reader = new StreamReader(@"D:\SaveListOfIndividualClientsToXML.xml");
            object obj = deserializer.Deserialize(reader);
            List<IndividualClient> XmlData = (List<IndividualClient>)obj;
            reader.Close();
        }

        //[TestMethod]
        //public void SaveListOfCompaniesToXML()
        //{
        //    var a = new Company();
        //    List<Company> list = new List<Company> { a };
        //    XmlSerializer serialiser = new XmlSerializer(typeof(List<Company>));
        //    TextWriter Filestream = new StreamWriter(@"D:\SaveListOfCompaniesToXML.xml");
        //    serialiser.Serialize(Filestream, list);
        //    Filestream.Close();
        //}

        //[TestMethod]
        //public void ReadListOfCompaniesFromXml()
        //{
        //    XmlSerializer deserializer = new XmlSerializer(typeof(List<Company>));
        //    TextReader reader = new StreamReader(@"D:\SaveListOfCompaniesToXML.xml");
        //    object obj = deserializer.Deserialize(reader);
        //    List<Company> XmlData = (List<Company>)obj;
        //    reader.Close();
        //}
    }
#pragma warning restore 612, 618 
}
