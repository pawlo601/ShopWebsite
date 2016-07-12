using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Product;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Model.Entities
{
    public class SaveToXml
    {
        private static void SaveToXML(string path, string fileName, Type type, object list)
        {
            TextWriter filestream = null;
            try
            {
                XmlSerializer serialiser = new XmlSerializer(type);
                filestream = new StreamWriter(path + "/" + fileName);
                serialiser.Serialize(filestream, list);
                filestream.Close();

            }
            catch (Exception)
            {
                filestream?.Close();
                throw;
            }
        }
        public static void SaveToXmlProducts(string path, string fileName, List<Product.Product> products)
        {
            SaveToXML(path, fileName, typeof(List<Product.Product>), products);
        }

        public static void SaveToXmlUnits(string path, string fileName, List<Unit> units)
        {
            SaveToXML(path, fileName, typeof(List<Unit>), units);
        }

        public static void SaveToXmlCurriencies(string path, string fileName, List<Currency> curriencies)
        {
            SaveToXML(path, fileName, typeof(List<Currency>), curriencies);
        }

        public static void SaveToXmlOrders(string path, string fileName, List<Order.Order> orders)
        {
            SaveToXML(path, fileName, typeof(List<Order.Order>), orders);
        }

        public static void SaveToXmlCompanies(string path, string fileName, List<Company> companies)
        {
            SaveToXML(path, fileName, typeof(List<Company>), companies);
        }

        public static void SaveToXmlIndividualClients(string path, string fileName,
            List<IndividualClient> individualClients)
        {
            SaveToXML(path, fileName, typeof(List<IndividualClient>), individualClients);
        }

        public static void SaveToXmlRoles(string path, string fileName, List<Role> roles)
        {
            SaveToXML(path, fileName, typeof(List<Role>), roles);
        }

        public static void SaveToXmlEmployees(string path, string fileName, List<Employee> employees)
        {
            SaveToXML(path, fileName, typeof(List<Employee>), employees);
        }
    }
}
