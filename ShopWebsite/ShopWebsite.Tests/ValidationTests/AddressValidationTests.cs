using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopWebsite.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ShopWebsite.Model.Entities.Customer;
using static System.ComponentModel.DataAnnotations.Validator;

namespace ShopWebsite.Tests.ValidationTests
{
    [TestClass]
    public class AddressValidationTests
    {
        [TestMethod]
        public void AddressValidationIsOk()
        {
            Address address = new Address()
            {
                Street = "street",
                NumberOfBuilding = "9",
                City = "city1",
                PostalCode = "23-456",
                Country = "Poland"
            };
            var results = new List<ValidationResult>();
            TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                true);
            Assert.AreEqual(results.Count, 0);
        }

        [TestMethod]
        public void AddressValidationStreetIsWrong1()
        {
            Address address = new Address()
            {
                Street = "st",
                NumberOfBuilding = "9",
                City = "citty1",
                PostalCode = "23-456",
                Country = "Poland"
            };
            var results = new List<ValidationResult>();
            TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                true);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Street name lenght should be greater than 4."));
        }

        [TestMethod]
        public void AddressValidationtStreetIsWrong2()
        {
            Address address = new Address()
            {
                Street = "st12345678901234567890124567890",
                NumberOfBuilding = "9",
                City = "citty1",
                PostalCode = "23-456",
                Country = "Poland"
            };
            var results = new List<ValidationResult>();
            TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                true);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Street name lenght should be less than 21."));
        }

        [TestMethod]
        public void AddressValidationtStreetIsWrong3()
        {
            Address address = new Address()
            {
                Street = "",
                NumberOfBuilding = "9",
                City = "citty1",
                PostalCode = "23-456",
                Country = "Poland"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("No empty street name."));
        }

        [TestMethod]
        public void AddressValidationNumberOfBuildingIsWrong1()
        {
            Address address = new Address()
            {
                Street = "street",
                NumberOfBuilding = "",
                City = "citty1",
                PostalCode = "23-456",
                Country = "Poland"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Number of building lenght should be greater than 0."));
        }

        [TestMethod]
        public void AddressValidationtNumberOfBuildingIsWrong2()
        {
            Address address = new Address()
            {
                Street = "street",
                NumberOfBuilding = "909876543212344",
                City = "citty1",
                PostalCode = "23-456",
                Country = "Poland"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Number of building  lenght should be less than 11."));
        }

        [TestMethod]
        public void AddressValidationCityIsWrong1()
        {
            Address address = new Address()
            {
                Street = "street",
                NumberOfBuilding = "9",
                City = "",
                PostalCode = "23-456",
                Country = "Poland"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("No empty city name."));
        }

        [TestMethod]
        public void AddressValidationtCityIsWrong2()
        {
            Address address = new Address()
            {
                Street = "street",
                NumberOfBuilding = "9",
                City = "cit",
                PostalCode = "23-456",
                Country = "Poland"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("City name lenght should be greater than 4."));
        }

        [TestMethod]
        public void AddressValidationtCityIsWrong3()
        {
            Address address = new Address()
            {
                Street = "street",
                NumberOfBuilding = "9",
                City = "citty1453rwthgf344thgerghdfhetyh",
                PostalCode = "23-456",
                Country = "Poland"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("City name lenght should be less than 21."));
        }

        [TestMethod]
        public void AddressValidationPostalCodeIsWrong1()
        {
            Address address = new Address()
            {
                Street = "street",
                NumberOfBuilding = "9",
                City = "citty1",
                PostalCode = "",
                Country = "Poland"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("No empty postalcode."));
        }

        [TestMethod]
        public void AddressValidationtPostalCodeIsWrong2()
        {
            Address address = new Address()
            {
                Street = "street",
                NumberOfBuilding = "9",
                City = "citty1",
                PostalCode = "23",
                Country = "Poland"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Postal code lenght should be greater than 4."));
        }

        [TestMethod]
        public void AddressValidationtPostalCodeIsWrong3()
        {
            Address address = new Address()
            {
                Street = "street",
                NumberOfBuilding = "9",
                City = "citty1",
                PostalCode = "23-45643534534563546",
                Country = "Poland"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Postal code lenght should be less than 11."));
        }

        [TestMethod]
        public void AddressValidationCountryIsWrong1()
        {
            Address address = new Address()
            {
                Street = "street",
                NumberOfBuilding = "9",
                City = "citty1",
                PostalCode = "23-456",
                Country = ""
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("No empty country name."));
        }

        [TestMethod]
        public void AddressValidationtCountryIsWrong2()
        {
            Address address = new Address()
            {
                Street = "street",
                NumberOfBuilding = "9",
                City = "citty1",
                PostalCode = "23-456",
                Country = "asd"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Country name lenght should be greater than 4."));
        }

        [TestMethod]
        public void AddressValidationtCountryIsWrong3()
        {
            Address address = new Address()
            {
                Street = "street",
                NumberOfBuilding = "9",
                City = "citty1",
                PostalCode = "23-456",
                Country = "Polan7iujthgbfvdculkymujtnhbrg5yhntgnrgnd"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = TryValidateObject(
                address,
                new ValidationContext(address, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Country name lenght should be less than 21."));
        }
    }
}
