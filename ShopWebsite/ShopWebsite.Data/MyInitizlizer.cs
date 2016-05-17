using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using ShopWebsite.Model.Entities.Generators;

namespace ShopWebsite.Data
{
    public class MyInitizlizer : DropCreateDatabaseIfModelChanges<ShopWebsiteContext>
    {
        protected override void Seed(ShopWebsiteContext context)
        {
            try
            {
                SqlConnection.ClearAllPools();
                context.Units.AddRange(ProductGenerator.Instatnce.GetAllUnits());
                context.Curriencies.AddRange(ProductGenerator.Instatnce.GetAllCurrencies());
                for (int i = 0; i < Configuration.Configuration.HowManyProductsCreateInInitialize; i++)
                {
                    context.Products.Add(ProductGenerator.Instatnce.GetNextProduct());
                }
                for (int i = 0; i < Configuration.Configuration.HowManyEmployeesCreateInInitialize; i++)
                {
                    context.Users.Add(UserGenerator.Instatnce.GetNextEmployee());
                }
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