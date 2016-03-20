using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopWebsite.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Tests.ValidationTests
{
    [TestClass]
    public class IndividualClientValidationTests
    {
        [TestMethod]
        public void IndividualClientValidationIsOK()
        {
            IndividualClient company = new IndividualClient()
            {
                Name="Nameaa",
                Surname="Surname123",
                Birthday=DateTime.Now,
                PeselNumber="123456798",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                ResidentialAddress = new Address(),
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
        public void IndividualClientValidationNameIsWrong1()
        {
            IndividualClient company = new IndividualClient()
            {
                Name = "",
                Surname = "Surname123",
                Birthday = DateTime.Now,
                PeselNumber = "123456798",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                ResidentialAddress = new Address(),
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("No empty client name."));
        }

        [TestMethod]
        public void IndividualClientValidationNameIsWrong2()
        {
            IndividualClient company = new IndividualClient()
            {
                Name = "454",
                Surname = "Surname123",
                Birthday = DateTime.Now,
                PeselNumber = "123456798",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                ResidentialAddress = new Address(),
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Client name lenght should be greater than 4."));
        }

        [TestMethod]
        public void IndividualClientValidationNameIsWrong3()
        {
            IndividualClient company = new IndividualClient()
            {
                Name = "454e56yughghtdhgtycgjhnufcgh",
                Surname = "Surname123",
                Birthday = DateTime.Now,
                PeselNumber = "123456798",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                ResidentialAddress = new Address(),
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Client name lenght should be less than 21."));
        }

        [TestMethod]
        public void IndividualClientValidationSurnameIsWrong1()
        {
            IndividualClient company = new IndividualClient()
            {
                Name = "Nameaa",
                Surname = "",
                Birthday = DateTime.Now,
                PeselNumber = "123456798",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                ResidentialAddress = new Address(),
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("No empty client surname."));
        }

        [TestMethod]
        public void IndividualClientValidationSurnameIsWrong2()
        {
            IndividualClient company = new IndividualClient()
            {
                Name = "Nameaa",
                Surname = "123",
                Birthday = DateTime.Now,
                PeselNumber = "123456798",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                ResidentialAddress = new Address(),
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Client surname lenght should be greater than 4."));
        }

        [TestMethod]
        public void IndividualClientValidationSurnameIsWrong3()
        {
            IndividualClient company = new IndividualClient()
            {
                Name = "Nameaa",
                Surname = "5sd1f8sdf1g9sdf1g6sdf45g61sdf54g1",
                Birthday = DateTime.Now,
                PeselNumber = "123456798",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                ResidentialAddress = new Address(),
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Client surname lenght should be less than 21."));
        }

        [TestMethod]
        public void IndividualClientValidationPeselNumberIsWrong1()
        {
            IndividualClient company = new IndividualClient()
            {
                Name = "Nameaa",
                Surname = "Surname123",
                Birthday = DateTime.Now,
                PeselNumber = "",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                ResidentialAddress = new Address(),
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("No empty pesel number."));
        }

        [TestMethod]
        public void IndividualClientValidationPeselNumberIsWrong2()
        {
            IndividualClient company = new IndividualClient()
            {
                Name = "Nameaa",
                Surname = "Surname123",
                Birthday = DateTime.Now,
                PeselNumber = "456",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                ResidentialAddress = new Address(),
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Client pesel lenght should be greater than 8."));
        }

        [TestMethod]
        public void IndividualClientValidationPeselNumberIsWrong3()
        {
            IndividualClient company = new IndividualClient()
            {
                Name = "Nameaa",
                Surname = "Surname123",
                Birthday = DateTime.Now,
                PeselNumber = "123456798123456789",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                ResidentialAddress = new Address(),
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Client pesel lenght should be less than 11."));
        }

        [TestMethod]
        public void IndividualClientValidationBirthdayIsWrong1()
        {
            IndividualClient company = new IndividualClient()
            {
                Name = "Nameaa",
                Surname = "Surname123",
                Birthday = new DateTime(2100,12,12),
                PeselNumber = "123456798",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                ResidentialAddress = new Address(),
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Birthday should be ealier than 31.12.2017"));
        }

        [TestMethod]
        public void IndividualClientValidationBirthdayIsWrong2()
        {
            IndividualClient company = new IndividualClient()
            {
                Name = "Nameaa",
                Surname = "Surname123",
                Birthday = new DateTime(1200,12,12),
                PeselNumber = "123456798",
                ContactAddress = new Address(),
                ContactTitle = "Title",
                Mail1 = "asd@asdf.pl",
                Mail2 = "sdfg@sdfg.com",
                Orders = new List<Order>(),
                Phone1 = "123456789",
                Phone2 = "852741963",
                ResidentialAddress = new Address(),
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                company,
                new ValidationContext(company, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Birthday should be later than 1.1.1990"));
        }
    }
}