using ShopWebsite.Data.Common;
using ShopWebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;

namespace ShopWebsite.Data
{
    public class MyInitizlizer : DropCreateDatabaseIfModelChanges<ShopWebsiteContext>
    {
        protected override void Seed(ShopWebsiteContext context)
        {
            try
            {
                SqlConnection.ClearAllPools();
                GetDataFromXml.GetProducts().ForEach(a => context.Products.Add(a));
                GetDataFromXml.GetOrders().ForEach(a => context.Orders.Add(a));
                ////////////
                Address ad = new Address()
                {
                    City = "Wrocfh",
                    Country = "Polfgh",
                    NumberOfBuilding = "12",
                    PostalCode = "12-345",
                    Street = "Nowow"
                };
                Address ad2 = new Address()
                {
                    City = "Wrocfgh",
                    Country = "Polfghj",
                    NumberOfBuilding = "122",
                    PostalCode = "12-3425",
                    Street = "Nowow2"
                };
                Company company = new Company()
                {
                    CompanyName = "name1",
                    ContactAddress = ad,
                    ContactTitle = "Title",
                    Mail1 = "asd@asdf.pl",
                    Mail2 = "sdfg@sdfg.com",
                    Orders = new List<Order>(),
                    Phone1 = "123456789",
                    Phone2 = "852741963",
                    Regon = "1234567890",
                    ResidentialAddress = ad2,
                    TaxId = "w3463456"
                };
                context.Customers.Add(company);
                ////////////
                context.SaveChanges();
            }catch(DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }catch(DbUpdateException)
            {
            }
        }
    }
}