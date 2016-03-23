using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopWebsite.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Tests.ValidationTests
{
    [TestClass]
    public class PositionInTheOrderValidationTests
    {
        [TestMethod]
        public void PositionInTheOrderValidationIsOK()
        {
            PositionInTheOrderFromXML pito = new PositionInTheOrderFromXML(1, 1, 12);
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                pito,
                new ValidationContext(pito, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 0);
        }

        [TestMethod]
        public void PositionInTheOrderValidationQuantityIsWrong()
        {
            PositionInTheOrderFromXML pito = new PositionInTheOrderFromXML(1, 1, -89);
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                pito,
                new ValidationContext(pito, null, null),
                results,
                validateAllProperties);
            Assert.AreEqual(results.Count, 1);
            Assert.IsTrue(results[0].ErrorMessage.Equals("Quantity of product should be greater than 0.0"));
        }
    }
}
