using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopWebsite.Model.Entities.Generators;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Tests
{
    [TestClass]
    public class TestOfSavingEntitiesToXML
    {
        private static readonly int _howManyProductsSave = 5;
        private static readonly string _filePathToSaveProducts = @"D:\Products.xml";
        private static readonly string _filePathToSaveUnits = @"D:\Units.xml";
        private static readonly string _filePathToSaveCurriencies = @"D:\Curriencies.xml";

        [TestMethod]
        public void SaveProductsToXml()
        {
            List<Product> list = new List<Product>();
            for(int i=0;i<_howManyProductsSave;i++)
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
    }
}
