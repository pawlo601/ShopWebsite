using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopWebsite.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Tests.ValidationTests
{
    [TestClass]
    public class CompanyValidationTests
    {
        [TestMethod]
        public void CompanyValidationIsOK()
        {
            Company company = new Company()
            {
                CompanyName = "name1",
                ContactAddress = new Address(true),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                REGON = "1234567890",
                ResidentialAddress = new Address(true),
                TaxID = "w3463456"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 0);
        }

        [TestMethod]
        public void CompanyValidationCompanyNameIsWrong1()
        {
            Company company = new Company()
            {
                CompanyName = "nam",
                ContactAddress = new Address(true),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                REGON = "1234567890",
                ResidentialAddress = new Address(true),
                TaxID = "w3463456"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Company name lenght should be greater than 4."));
        }

        [TestMethod]
        public void CompanyValidationCompanyNameIsWrong2()
        {
            Company company = new Company()
            {
                CompanyName = "namertgv45tgvertvg45vgertgv45gvertg45",
                ContactAddress = new Address(true),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                REGON = "1234567890",
                ResidentialAddress = new Address(true),
                TaxID = "w3463456"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Company name lenght should be less than 21."));
        }

        [TestMethod]
        public void CompanyValidationCompanyNameIsWrong3()
        {
            Company company = new Company()
            {
                CompanyName = "",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                REGON = "1234567890",
                ResidentialAddress = new Address(),
                TaxID = "w3463456"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("No empty company name."));
        }

        [TestMethod]
        public void CompanyValidationREGONIsWrong1()
        {
            Company company = new Company()
            {
                CompanyName = "company",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                REGON = "",
                ResidentialAddress = new Address(),
                TaxID = "w3463456"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("No empty REGON."));
        }

        [TestMethod]
        public void CompanyValidationREGONIsWrong2()
        {
            Company company = new Company()
            {
                CompanyName = "company",
                ContactAddress = new Address(true),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                REGON = "4152",
                ResidentialAddress = new Address(true),
                TaxID = "w3463456"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("REGON lenght should be greater than 7."));
        }

        [TestMethod]
        public void CompanyValidationREGONIsWrong3()
        {
            Company company = new Company()
            {
                CompanyName = "company",
                ContactAddress = new Address(true),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                REGON = "4565464564564564",
                ResidentialAddress = new Address(true),
                TaxID = "w3463456"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("REGON lenght should be less than 11."));
        }

        [TestMethod]
        public void CompanyValidationTaxIDIsWrong1()
        {
            Company company = new Company()
            {
                CompanyName = "company",
                ContactAddress = new Address(true),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                REGON = "258147369",
                ResidentialAddress = new Address(true),
                TaxID = "34563456345634563456"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("TaxID lenght should be less than 11."));
        }

        [TestMethod]
        public void CompanyValidationTaxIDIsWrong2()
        {
            Company company = new Company()
            {
                CompanyName = "company",
                ContactAddress = new Address(true),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                REGON = "258147369",
                ResidentialAddress = new Address(true),
                TaxID = "234"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("TaxID lenght should be greater than 7."));
        }

        [TestMethod]
        public void CompanyValidationTaxIDIsWrong3()
        {
            Company company = new Company()
            {
                CompanyName = "company",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                REGON = "258147369",
                ResidentialAddress = new Address(),
                TaxID = ""
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("No empty TaxID."));
        }
    }
}