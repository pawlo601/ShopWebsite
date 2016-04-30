using System.Collections.Generic;
using ShopWebsite.Model.Entities.Product;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Model.Entities
{
    public class SaveToXml
    {
        /*
             private const int _howManyProductsCreateNewAndSave = 5;
        private const int _howManyCompaniesCreateNewAndSave = 5;
        private const int _howManyIndividualClientsCreateNewAndSave = 5;
        private const int _howManyEmployeesCreateNewAndSave = 5;
        private const string _filePathToSaveProducts = @"D:\Products.xml";
        private const string _filePathToSaveUnits = @"D:\Units.xml";
        private const string _filePathToSaveCurriencies = @"D:\Curriencies.xml";
        private const string _filePathToSaveRoles = @"D:\Roles.xml";
        private const string _filePathToSaveCompanies = @"D:\Companies.xml";
        private const string _filePathToSaveIndividualClients = @"D:\IndividualClients.xml";
        private const string _filePathToSaveEmployees = @"D:\Employees.xml";

        [TestMethod]
        public void CreateNewAndSaveProductsToXml()
        {
            try
            {
                if (Configuration.Configuration.CreateNewObjects)
                {
                    List<Product> list = new List<Product>();
                    for (int i = 0; i < _howManyProductsCreateNewAndSave; i++)
                        list.Add(ProductGenerator.Instatnce.GetNextProduct());
                    XmlSerializer serialiser = new XmlSerializer(typeof(List<Product>));
                    TextWriter filestream = new StreamWriter(_filePathToSaveProducts);
                    serialiser.Serialize(filestream, list);
                    filestream.Close();
                }
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
             */
        public static void SaveToXmlProducts(string path, string fileName, List<Product.Product> products)
        {

        }

        public static void SaveToXmlUnits(string path, string fileName, List<Unit> units)
        {

        }

        public static void SaveToXmlCurriencies(string path, string fileName, List<Currency> curriencies)
        {

        }

        public static void SaveToXmlOrders(string path, string fileName, List<Order.Order> orders)
        {

        }

        public static void SaveToXmlCompanies(string path, string fileName, List<Company> companies)
        {

        }

        public static void SaveToXmlIndividualClients(string path, string fileName,
            List<IndividualClient> individualClients)
        {

        }

        public static void SaveToXmlRoles(string path, string fielName, List<Role> roles)
        {

        }

        public static void SaveToXmlEmployees(string path, string fileName, List<Employee> employees)
        {

        }
    }
}
