using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopWebsite.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ShopWebsite.Tests.ValidationTests
{
    [TestClass]
    public class ProductValidationTests
    {
        [TestMethod]
        public void ProductValidationIsOK()
        {
            Product product = new Product()
            {
                ProductName = "name123",
                ProductDescription = "234wertsd435",
                PricePerUnit = 123.45M,
                QuantityPerUnit = 12.45M
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                product,
                new ValidationContext(product, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 0);
        } 

        [TestMethod]
        public void ProductValidationProductNameIsWrong1()
        {
            Product product = new Product()
            {
                ProductName = "",
                ProductDescription = "234wertsd435",
                PricePerUnit = 123.45M,
                QuantityPerUnit = 12.45M
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                product,
                new ValidationContext(product, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("No empty product name."));
        }

        [TestMethod]
        public void ProductValidationProductNameIsWrong2()
        {
            Product product = new Product()
            {
                ProductName = "123",
                ProductDescription = "234wertsd435",
                PricePerUnit = 123.45M,
                QuantityPerUnit = 12.45M
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                product,
                new ValidationContext(product, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Product name lenght should be greater than 4."));
        }

        [TestMethod]
        public void ProductValidationProductNameIsWrong3()
        {
            Product product = new Product()
            {
                ProductName = "sodfhgfigutgyenrt gir gbuergtvnertigvenrtgiuetrnrtugytrbgie",
                ProductDescription = "234wertsd435",
                PricePerUnit = 123.45M,
                QuantityPerUnit = 12.45M
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                product,
                new ValidationContext(product, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Product name lenght should be less than 31."));
        }

        [TestMethod]
        public void ProductValidationProductDescriptionIsWrong1()
        {
            Product product = new Product()
            {
                ProductName = "name123",
                ProductDescription = "",
                PricePerUnit = 123.45M,
                QuantityPerUnit = 12.45M
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                product,
                new ValidationContext(product, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("No empty product description."));
        }

        [TestMethod]
        public void ProductValidationProductDescriptionIsWrong2()
        {
            Product product = new Product()
            {
                ProductName = "name123",
                ProductDescription = "23",
                PricePerUnit = 123.45M,
                QuantityPerUnit = 12.45M
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                product,
                new ValidationContext(product, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Product description lenght should be greater than 4."));
        }

        [TestMethod]
        public void ProductValidationProductDescriptionIsWrong3()
        {
            Product product = new Product()
            {
                ProductName = "name123",
                ProductDescription = "012301234567894567012345678989010123456789234567890123012345678945670123456789890101234567892345678954664654",
                PricePerUnit = 123.45M,
                QuantityPerUnit = 12.45M
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                product,
                new ValidationContext(product, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Product description lenght should be less than 101."));
        }


        [TestMethod]
        public void ProductValidationPricePerUnitIsWrong1()
        {
            Product product = new Product()
            {
                ProductName = "name123",
                ProductDescription = "sdfgsdfg",
                PricePerUnit = -123.45M,
                QuantityPerUnit = 12.45M
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                product,
                new ValidationContext(product, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Price of product should be greater than 0.0"));
        }

        [TestMethod]
        public void ProductValidationQuantityPerUnitIsWrong1()
        {
            Product product = new Product()
            {
                ProductName = "name123",
                ProductDescription = "2sdfg3",
                PricePerUnit = 123.45M,
                QuantityPerUnit = -12.45M
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                product,
                new ValidationContext(product, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Quantity of product should be greater than 0.0"));
        }
    }
}