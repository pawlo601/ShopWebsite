using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using ShopWebsite.Data.Common;
using ShopWebsite.Model.Entities.Audit;
using ShopWebsite.Model.Entities.Generators;
using Action = ShopWebsite.Model.Entities.Audit.Action;

namespace ShopWebsite.Data
{
    public class MyInitizlizer : DropCreateDatabaseIfModelChanges<ShopWebsiteContext>
    {
        protected override void Seed(ShopWebsiteContext context)
        {
            try
            {
                SqlConnection.ClearAllPools();
                UnitsInitialize(context);
                CurrienciesInitialize(context);
                PermissionsInitialize(context);
                RolesInitialize(context);
                DiscountsInitialize(context);
                StatusesInitialize(context);
                ProductsInitialize(context);
                EmployeesInitialize(context);
                IndividualClientsInitialize(context);
                CompaniesInitialize(context);
                AdminInitialize(context);
                ExceptionLogsInitialize(context);
                AuditsInitialize(context);
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                LoggingException.LogException("ShopWebsite.Data.MyInitizlizer", "Seed", e);
            }
            catch (Exception e)
            {
                LoggingException.LogException("ShopWebsite.Data.MyInitizlizer", "Seed", string.Empty, string.Empty, string.Empty, string.Empty, e);
            }
        }

        private void AuditsInitialize(ShopWebsiteContext context)
        {
            context.Audits.Add(new Audit()
            {
                Id = 1,
                SessionId = "0",
                Action = Action.Begin,
                AdditionalInformation = "Create database",
                AddressIP = "1",
                Data = string.Empty,
                PropertyName = string.Empty,
                TimeAccessed = DateTime.Now,
                URLAccessed = string.Empty,
                UserName = "Admin"
            });
        }

        private void ExceptionLogsInitialize(DbContext context)
        {
            context.Database.ExecuteSqlCommand(Configuration.Configuration.CreateLogsSchema);
            context.Database.ExecuteSqlCommand(Configuration.Configuration.CreateTableExceptionLogsCommand);
        }

        private void UnitsInitialize(ShopWebsiteContext context)
        {
            context.Units.AddRange(ProductGenerator.Instatnce.GetAllUnits());
        }

        private void AdminInitialize(ShopWebsiteContext context)
        {
            context.Users.Add(UserGenerator.Instatnce.GetAdmin());
        }

        private void CompaniesInitialize(ShopWebsiteContext context)
        {
            for (int i = 0; i < Configuration.Configuration.HowManyCompaniesCreateInInitialize; i++)
            {
                context.Users.Add(UserGenerator.Instatnce.GetNextCompany());
            }
        }

        private void IndividualClientsInitialize(ShopWebsiteContext context)
        {
            for (int i = 0; i < Configuration.Configuration.HowManyIndClientsCreateInInitialize; i++)
            {
                context.Users.Add(UserGenerator.Instatnce.GetNextIndividualClient());
            }
        }

        private static void EmployeesInitialize(ShopWebsiteContext context)
        {
            for (int i = 0; i < Configuration.Configuration.HowManyEmployeesCreateInInitialize; i++)
            {
                context.Users.Add(UserGenerator.Instatnce.GetNextEmployee());
            }
        }

        private void ProductsInitialize(ShopWebsiteContext context)
        {
            for (int i = 0; i < Configuration.Configuration.HowManyProductsCreateInInitialize; i++)
            {
                context.Products.Add(ProductGenerator.Instatnce.GetNextProduct());
            }
        }

        private void StatusesInitialize(ShopWebsiteContext context)
        {
            context.Statuses.AddRange(OrderGenerator.Instatnce.GetAllStatuses());
        }

        private void DiscountsInitialize(ShopWebsiteContext context)
        {
            context.Discounts.AddRange(DiscountGenerator.Intance.GetAllDiscounts());
        }

        private void RolesInitialize(ShopWebsiteContext context)
        {
            context.Roles.AddRange(UserGenerator.Instatnce.GetAllRoles());
        }

        private void PermissionsInitialize(ShopWebsiteContext context)
        {
            context.Permissions.AddRange(UserGenerator.Instatnce.GetAllPermissions());
        }

        private void CurrienciesInitialize(ShopWebsiteContext context)
        {
            context.Curriencies.AddRange(ProductGenerator.Instatnce.GetAllCurrencies());
        }
    }
}