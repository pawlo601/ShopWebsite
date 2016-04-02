using ShopWebsite.Data.Common;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;

namespace ShopWebsite.Data
{
    public class MyInitizlizer : DropCreateDatabaseAlways<ShopWebsiteContext>
    {
        protected override void Seed(ShopWebsiteContext context)
        {
            try
            {
                SqlConnection.ClearAllPools();
                GetDataFromXml.GetProducts().ForEach(a => context.Products.Add(a));
                GetDataFromXml.GetCompanies().ForEach(a=>context.Customers.Add((a)));
                GetDataFromXml.GetIndividualsClients().ForEach(a => context.Customers.Add((a)));
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