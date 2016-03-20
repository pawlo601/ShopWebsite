using ShopWebsite.Data.Common;
using ShopWebsite.Model.Entities;
using System;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ShopWebsite.Data
{
    public class MyInitizlizer : DropCreateDatabaseAlways<ShopWebsiteContext>
    {
        protected override void Seed(ShopWebsiteContext context)
        {
            SqlConnection.ClearAllPools();            
            GetDataFromXML.GetProducts().ForEach(a => context.Products.Add(a));
            context.SaveChanges();
        }
    }
}