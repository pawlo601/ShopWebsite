using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopWebsite.Data.Repositories.Implementations;
using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Model.Entities;

namespace ShopWebsite.Tests.RepositoryTests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        [TestMethod]
        public void Test1()
        {
            DbFactory dbf = new DbFactory();
            ProductRepository pr = new ProductRepository(dbf);
            Product product = new Product()
            {
                ProductName = "name123",
                ProductDescription = "234wertsd435",
                PricePerUnit = 123.45M,
                QuantityPerUnit = 12.45M
            };
            TransactionalInformation tr = new TransactionalInformation();
            pr.AddNewEntity(product, out tr);
            Assert.IsTrue(tr.ReturnStatus);
        }
    }
}
