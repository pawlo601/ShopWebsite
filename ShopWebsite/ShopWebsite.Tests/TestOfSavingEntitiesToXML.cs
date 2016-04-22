using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopWebsite.Model.Entities.Generators;
using ShopWebsite.Model.Entities.Product;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Tests
{
    [TestClass]
    public class TestOfSavingEntitiesToXML
    {
        private const int _howManyProductsSave = 5;
        private const int _howManyCompaniesSave = 5;
        private const int _howManyIndividualClientsSave = 5;
        private const int _howManyEmployeesSave = 5;
        private const string _filePathToSaveProducts = @"D:\Products.xml";
        private const string _filePathToSaveUnits = @"D:\Units.xml";
        private const string _filePathToSaveCurriencies = @"D:\Curriencies.xml";
        private const string _filePathToSaveRoles = @"D:\Roles.xml";
        private const string _filePathToSaveCompanies = @"D:\Companies.xml";
        private const string _filePathToSaveIndividualClients = @"D:\IndividualClients.xml";
        private const string _filePathToSaveEmployees = @"D:\Employees.xml";

        [TestMethod]
        public void SaveProductsToXml()
        {
            List<Product> list = new List<Product>();
            for (int i = 0; i < _howManyProductsSave; i++)
                list.Add(ProductGenerator.Instatnce.GetNextProduct());
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Product>));
            TextWriter filestream = new StreamWriter(_filePathToSaveProducts);
            serialiser.Serialize(filestream, list);
            filestream.Close();
        }

        [TestMethod]
        public void SaveAllUnitsToXml()
        {
            Unit[] tab = ProductGenerator.Instatnce.GetAllUnits();
            XmlSerializer serialiser = new XmlSerializer(typeof(Unit[]));
            TextWriter filestream = new StreamWriter(_filePathToSaveUnits);
            serialiser.Serialize(filestream, tab);
            filestream.Close();
        }

        [TestMethod]
        public void SaveAllCurrienciesToXml()
        {
            Currency[] tab = ProductGenerator.Instatnce.GetAllCurrencies();
            XmlSerializer serialiser = new XmlSerializer(typeof(Currency[]));
            TextWriter filestream = new StreamWriter(_filePathToSaveCurriencies);
            serialiser.Serialize(filestream, tab);
            filestream.Close();
        }

        [TestMethod]
        public void SaveAllRolesToXml()
        {
            Role[] tab = UserGenerator.Instatnce.GetAllRoles();
            XmlSerializer serialiser = new XmlSerializer(typeof(Role[]));
            TextWriter filestream = new StreamWriter(_filePathToSaveRoles);
            serialiser.Serialize(filestream, tab);
            filestream.Close();
        }

        [TestMethod]
        public void SaveAllCompaniesToXml()
        {
            List<Company> list = new List<Company>();
            for (int i = 0; i < _howManyCompaniesSave; i++)
                list.Add(UserGenerator.Instatnce.GetNextCompany());
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Company>));
            TextWriter filestream = new StreamWriter(_filePathToSaveCompanies);
            serialiser.Serialize(filestream, list);
            filestream.Close();
        }

        [TestMethod]
        public void SaveAllIndividualClientsToXml()
        {
            List<IndividualClient> list = new List<IndividualClient>();
            for (int i = 0; i < _howManyIndividualClientsSave; i++)
                list.Add(UserGenerator.Instatnce.GetNextIndividualClient());
            XmlSerializer serialiser = new XmlSerializer(typeof(List<IndividualClient>));
            TextWriter filestream = new StreamWriter(_filePathToSaveIndividualClients);
            serialiser.Serialize(filestream, list);
            filestream.Close();
        }

        [TestMethod]
        public void SaveAllEmployeesToXml()
        {
            List<Employee> list = new List<Employee>();
            for (int i = 0; i < _howManyEmployeesSave; i++)
                list.Add(UserGenerator.Instatnce.GetNextEmployee());
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Employee>));
            TextWriter filestream = new StreamWriter(_filePathToSaveEmployees);
            serialiser.Serialize(filestream, list);
            filestream.Close();
        }
    }
}
