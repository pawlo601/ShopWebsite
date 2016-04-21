//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using ShopWebsite.Model.Entities;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using ShopWebsite.Model.Entities.Customer;
//using ShopWebsite.Model.Entities.Order;

//namespace ShopWebsite.Tests.ValidationTests
//{
//    [TestClass]
//    public class CustomerValidationTests
//    {
//        [TestMethod]
//        public void CustomerValidationIsOk()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactAddress = new Address(true),
//                ContactTitle = "Title",
//                Mail1 = "asd@asdf.pl",
//                Mail2 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "852741963",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(true),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 0);
//        }

//        [TestMethod]
//        public void CustomerValidationContactTitleIsWrong1()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactAddress = new Address(true),
//                ContactTitle = "",
//                Mail1 = "asd@asdf.pl",
//                Mail2 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "852741963",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(true),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 1);
//            Assert.IsTrue(results[0].ErrorMessage.Equals("Contact title lenght should be greater than 0."));
//        }

//        [TestMethod]
//        public void CustomerValidationContactTitleIsWrong2()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactAddress = new Address(true),
//                ContactTitle = "234123412341234",
//                Mail1 = "asd@asdf.pl",
//                Mail2 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "852741963",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(true),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 1);
//            Assert.IsTrue(results[0].ErrorMessage.Equals("Contact title lenght should be less than 11."));
//        }

//        [TestMethod]
//        public void CustomerValidationContactAddressIsEmpty()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactTitle = "m myui",
//                Mail1 = "asd@asdf.pl",
//                Mail2 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "852741963",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(true),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 0);
//        }

//        [TestMethod]
//        public void CustomerValidationContactAddressIsNotEmptyIsOk()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactTitle = "m myui",
//                Mail1 = "asd@asdf.pl",
//                Mail2 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "852741963",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(true),
                
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 0);
//        }

//        [TestMethod]
//        public void CustomerValidationResidentialAddressIsWrong()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactTitle = "234123412341234",
//                Mail1 = "asd@asdf.pl",
//                Mail2 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "852741963",
//                Regon = "1234567890",
//                ContactAddress = new Address(),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 1);
//            Assert.IsTrue(results[0].ErrorMessage.Equals("Residential address shouldn't be empty."));
//        }

//        [TestMethod]
//        public void CustomerValidationMail1IsTheSameAsMail2()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactAddress = new Address(true),
//                ContactTitle = "Title",
//                Mail1 = "asd@asdf.pl",
//                Mail2 = "asd@asdf.pl",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "852741963",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(true),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 1);
//            Assert.IsTrue(results[0].ErrorMessage.Equals("Mail1 is the sama as mail2."));
//        }

//        [TestMethod]
//        public void CustomerValidationPhone1IsTheSameAsPhone2()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactAddress = new Address(true),
//                ContactTitle = "Title",
//                Mail1 = "asd@asdf.pl",
//                Mail2 = "8@asdf.pl",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "123456789",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(true),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 1);
//            Assert.IsTrue(results[0].ErrorMessage.Equals("Number of phone1 is the sama as number of phone2."));
//        }

//        [TestMethod]
//        public void CustomerValidationMail1IsWrong1()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactAddress = new Address(true),
//                ContactTitle = "Title",
//                Mail1 = "asdasdf.pl",
//                Mail2 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "852741963",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(true),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 1);
//            Assert.IsTrue(results[0].ErrorMessage.Equals("Wrong email"));
//        }

//        [TestMethod]
//        public void CustomerValidationMail1IsWrong2()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactAddress = new Address(),
//                ContactTitle = "Title",
//                Mail1 = "",
//                Mail2 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "852741963",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 1);
//            Assert.IsTrue(results[0].ErrorMessage.Equals("First email shouldn't be empty."));
//        }

//        [TestMethod]
//        public void CustomerValidationMail2IsWrong1()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactAddress = new Address(true),
//                ContactTitle = "Title",
//                Mail2 = "asdasdf.pl",
//                Mail1 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "852741963",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(true),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 1);
//            Assert.IsTrue(results[0].ErrorMessage.Equals("Wrong email"));
//        }

//        [TestMethod]
//        public void CustomerValidationMail2IsWrong2()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactAddress = new Address(),
//                ContactTitle = "Title",
//                Mail2 = "",
//                Mail1 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "852741963",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 1);
//            Assert.IsTrue(results[0].ErrorMessage.Equals("Second mail shouldn't be empty."));
//        }

//        [TestMethod]
//        public void CustomerValidationPhone1IsWrong1()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactAddress = new Address(true),
//                ContactTitle = "Title",
//                Mail1 = "asd@asdf.pl",
//                Mail2 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "sdf",
//                Phone2 = "852741963",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(true),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 1);
//            Assert.IsTrue(results[0].ErrorMessage.Equals("Wrong phone number"));
//        }

//        [TestMethod]
//        public void CustomerValidationPhone1IsWrong2()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactAddress = new Address(),
//                ContactTitle = "Title",
//                Mail1 = "asd@asdf.pl",
//                Mail2 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "",
//                Phone2 = "852741963",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 1);
//            Assert.IsTrue(results[0].ErrorMessage.Equals("First phone number shouldn't be empty."));
//        }

//        [TestMethod]
//        public void CustomerValidationPhone2IsWrong1()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactAddress = new Address(true),
//                ContactTitle = "Title",
//                Mail1 = "asd@asdf.pl",
//                Mail2 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "sdfs",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(true),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 1);
//            Assert.IsTrue(results[0].ErrorMessage.Equals("Wrong phone number"));
//        }

//        [TestMethod]
//        public void CustomerValidationPhone2IsWrong2()
//        {
//            Company company = new Company()
//            {
//                CompanyName = "name1",
//                ContactAddress = new Address(),
//                ContactTitle = "Title",
//                Mail1 = "asd@asdf.pl",
//                Mail2 = "sdfg@sdfg.com",
//                Orders = new List<Order>(),
//                Phone1 = "123456789",
//                Phone2 = "",
//                Regon = "1234567890",
//                ResidentialAddress = new Address(),
//                TaxId = "w3463456"
//            };
//            bool validateAllProperties = false;
//            var results = new List<ValidationResult>();
//            bool isValid = Validator.TryValidateObject(
//                company,
//                new ValidationContext(company, null, null),
//                results,
//                validateAllProperties);
//            Assert.AreEqual(results.Count, 1);
//            Assert.IsTrue(results[0].ErrorMessage.Equals("Second phone number shouldn't be empty."));
//        }
//    }
//}