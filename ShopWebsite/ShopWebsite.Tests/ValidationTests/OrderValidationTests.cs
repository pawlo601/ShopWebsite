using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopWebsite.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Tests.ValidationTests
{
    [TestClass]
    public class OrderValidationTests
    {
        [TestMethod]
        public void OrderValidationIsOK()
        {
            Order order = new Order()
            {
                Value = 12.09M,
                DateOfSubmission = DateTime.Now,
                OrderedItems = new List<PositionInTheOrder>(),
                StatusOfOrder = "status"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                order,
                new ValidationContext(order, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 0);
        }

        [TestMethod]
        public void OrderValidationDateOfSubmissionIsWrong1()
        {
            Order order = new Order()
            {
                Value = 12.09M,
                DateOfSubmission = new DateTime(1700,12,12),
                OrderedItems = new List<PositionInTheOrder>(),
                StatusOfOrder = "status"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                order,
                new ValidationContext(order, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Date of submission should be later than 1.1.1990"));
        }

        [TestMethod]
        public void OrderValidationDateOfSubmissionIsWrong2()
        {
            Order order = new Order()
            {
                Value = 12.09M,
                DateOfSubmission = new DateTime(2700, 12, 12),
                OrderedItems = new List<PositionInTheOrder>(),
                StatusOfOrder = "status"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                order,
                new ValidationContext(order, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Date of submission should be ealier than 31.12.2017"));
        }

        [TestMethod]
        public void OrderValidationStatusOfOrderIsWrong1()
        {
            Order order = new Order()
            {
                Value = 12.09M,
                DateOfSubmission = DateTime.Now,
                OrderedItems = new List<PositionInTheOrder>(),
                StatusOfOrder = ""
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                order,
                new ValidationContext(order, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("No empty status of order."));
        }

        [TestMethod]
        public void OrderValidationStatusOfOrderIsWrong2()
        {
            Order order = new Order()
            {
                Value = 12.09M,
                DateOfSubmission = DateTime.Now,
                OrderedItems = new List<PositionInTheOrder>(),
                StatusOfOrder = "q"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                order,
                new ValidationContext(order, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Status of order lenght should be greater than 1."));
        }

        [TestMethod]
        public void OrderValidationStatusOfOrderIsWrong3()
        {
            Order order = new Order()
            {
                Value = 12.09M,
                DateOfSubmission = DateTime.Now,
                OrderedItems = new List<PositionInTheOrder>(),
                StatusOfOrder = "qsdfgsdfgsdfgsdfgsdfgsdfgsdfg"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                order,
                new ValidationContext(order, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Status of order lenght should be less than 11."));
        }

        [TestMethod]
        public void OrderValidationValueIsWrong1()
        {
            Order order = new Order()
            {
                Value = -12.09M,
                DateOfSubmission = DateTime.Now,
                OrderedItems = new List<PositionInTheOrder>(),
                StatusOfOrder = "status"
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                order,
                new ValidationContext(order, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Value of order shouldn't be less than 0.0."));
        }
    }
}