using System;
using System.Collections.Generic;
using ShopWebsite.Model.Entities.Customer;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Model.Entities.Generators
{
    public class UserGenerator
    {
        private static int RoleId = 1;
        private static int AddressId = 1;
        private static int CompanyInformationId = 1;
        private static int PersonalInformationId = 1;
        private static int UserHasRoleId = 1;
        private static int PasswordId = 1;
        private static int EmployeeId = 1;
        private static int CompanyId = 1;
        private static int IndividualClientId = 1;
        private static UserGenerator _instance;
        private readonly Role[] _roles;

        public static int NumberOfRoles => 3;

        public static UserGenerator Instatnce => _instance ?? (_instance = new UserGenerator());

        private UserGenerator()
        {
            _roles = new Role[NumberOfRoles];
            List<string> names = new List<string>() { "ADMIN", "EMPLOYEE", "CUSTOMER" };
            foreach (string name in names)
            {
                _roles[RoleId - 1] = new Role(RoleId, name);
                RoleId++;
            }
        }

        public Address GetNextAddress()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = AddressId;
            AddressId++;
            string Street = "Street" + rand.Next(1000);
            string Number = "NB" + rand.Next(1000);
            string City = "City" + rand.Next(1000);
            string PostalCode = "PosCode" + rand.Next(100);
            string Country = "Country" + rand.Next(1000);
            return new Address(Id, Street, Number, City, PostalCode, Country);
        }

        public Role[] GetAllRoles()
        {
            return _roles;
        }

        public CompanyInformation GetNextCompanyInformation()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = CompanyInformationId;
            CompanyInformationId++;
            string CompanyName = "CName" + rand.Next(1000);
            string Regon = "Regon" + rand.Next(1000);
            string TaxId = "TaxId" + rand.Next(1000);
            return new CompanyInformation(Id, CompanyName, Regon, TaxId);
        }

        public PersonalInformation GetNextPersonalInformation()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = PersonalInformationId;
            PersonalInformationId++;
            string Name = "Name" + rand.Next(1000);
            string Surname = "Surname" + rand.Next(1000);
            DateTime Birthday = DateTime.Today.AddDays(-rand.Next(7300, 18250));
            return new PersonalInformation(Id, Name, Surname, Birthday);
        }

        public UserHasRole GetNextUserHasRole(int userId, List<int> notThisRoleId)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = UserHasRoleId;
            UserHasRoleId++;
            int i;
            var roles = GetAllRoles();
            while (true)
            {
                i = rand.Next() % roles.Length;
                if (!notThisRoleId.Contains(roles[i].Id))
                    break;
            }
            return new UserHasRole(Id, userId, roles[i]);
        }

        public Password GetNextPassword(int userId)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = PasswordId;
            PasswordId++;
            string HashedPassword = "HashedP" + rand.Next(1000);
            string PasswordSalt = "SaltP" + rand.Next(1000);
            DateTime CreateTime = DateTime.Now.AddDays(-rand.Next(3650));
            return new Password(Id, userId, HashedPassword, PasswordSalt, CreateTime);
        }

        public Employee GetNextEmployee()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = EmployeeId;
            EmployeeId++;
            string Email = "Mail" + rand.Next(1000);
            int AccessFailedCount = 0;
            DateTime LockoutEndsDateTimeUTC = DateTime.Now.AddDays(-1);
            Address ContactAddress = GetNextAddress();
            Address ResidentialAddress = GetNextAddress();
            string PhoneNumber = "PhoneNumber" + rand.Next(1000);
            List<Password> Passwords = new List<Password>();
            int r1 = rand.Next() % 5 + 1;
            for (int i = 0; i < r1; i++)
            {
                Passwords.Add(GetNextPassword(Id));
            }
            List<UserHasRole> UserRoles = new List<UserHasRole>();
            int r2 = rand.Next() % NumberOfRoles + 1;
            List<int> notThisRoleId = new List<int>();
            for (int i = 0; i < r2; i++)
            {
                UserHasRole a = GetNextUserHasRole(Id, notThisRoleId);
                notThisRoleId.Add(a.Role.Id);
                UserRoles.Add(a);
            }
            string Position = "Position" + rand.Next(1000);
            PersonalInformation Information = GetNextPersonalInformation();
            return new Employee(Id, Email, Position, Information, AccessFailedCount, LockoutEndsDateTimeUTC, ContactAddress, ResidentialAddress, PhoneNumber, Passwords, UserRoles);
        }

        public Company GetNextCompany()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = CompanyId;
            CompanyId++;
            string Email = "Mail" + rand.Next(1000);
            int AccessFailedCount = 0;
            DateTime LockoutEndsDateTimeUTC = DateTime.Now.AddDays(-1);
            Address ContactAddress = GetNextAddress();
            Address ResidentialAddress = GetNextAddress();
            string PhoneNumber = "PhoneNumber" + rand.Next(1000);
            List<Password> Passwords = new List<Password>();
            int r1 = rand.Next() % 5 + 1;
            for (int i = 0; i < r1; i++)
            {
                Passwords.Add(GetNextPassword(Id));
            }
            List<UserHasRole> UserRoles = new List<UserHasRole>();
            int r2 = rand.Next() % NumberOfRoles + 1;
            List<int> notThisRoleId = new List<int>();
            for (int i = 0; i < r2; i++)
            {
                UserHasRole a = GetNextUserHasRole(Id, notThisRoleId);
                notThisRoleId.Add(a.Role.Id);
                UserRoles.Add(a);
            }
            string ContactTitle = "CT" + rand.Next(1000);
            List<Order.Order> Orders = new List<Order.Order>();
            int r3 = rand.Next() % 5 + 1;
            for (int i = 0; i < r3; i++)
            {
                Orders.Add(OrderGenerator.Instatnce.GetNextOrder());
            }
            List<CustomerDiscount> discounts = new List<CustomerDiscount>();
            int r4 = rand.Next() % 5 + 1;
            for (int i = 0; i < r4; i++)
            {
                discounts.Add(DiscountGenerator.Intance.GetNextCustomerDiscount(Id));
            }
            CompanyInformation Information = GetNextCompanyInformation();
            return new Company(Id, Email, AccessFailedCount, LockoutEndsDateTimeUTC, ContactAddress, ResidentialAddress, PhoneNumber, Information, ContactTitle, Passwords, UserRoles, Orders, discounts);
        }

        public IndividualClient GetNextIndividualClient()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = IndividualClientId;
            IndividualClientId++;
            string Email = "Mail" + rand.Next(1000);
            int AccessFailedCount = 0;
            DateTime LockoutEndsDateTimeUTC = DateTime.Now.AddDays(-1);
            Address ContactAddress = GetNextAddress();
            Address ResidentialAddress = GetNextAddress();
            string PhoneNumber = "PhoneNumber" + rand.Next(1000);
            List<Password> Passwords = new List<Password>();
            int r1 = rand.Next() % 5 + 1;
            for (int i = 0; i < r1; i++)
            {
                Passwords.Add(GetNextPassword(Id));
            }
            List<UserHasRole> UserRoles = new List<UserHasRole>();
            int r2 = rand.Next() % NumberOfRoles + 1;
            List<int> notThisRoleId = new List<int>();
            for (int i = 0; i < r2; i++)
            {
                UserHasRole a = GetNextUserHasRole(Id, notThisRoleId);
                notThisRoleId.Add(a.Role.Id);
                UserRoles.Add(a);
            }
            string ContactTitle = "CT" + rand.Next(1000);
            List<Order.Order> Orders = new List<Order.Order>();
            int r3 = rand.Next() % 5 + 1;
            for (int i = 0; i < r3; i++)
            {
                Orders.Add(OrderGenerator.Instatnce.GetNextOrder());
            }
            List<CustomerDiscount> discounts = new List<CustomerDiscount>();
            int r4 = rand.Next() % 5 + 1;
            for (int i = 0; i < r4; i++)
            {
                discounts.Add(DiscountGenerator.Intance.GetNextCustomerDiscount(Id));
            }
            PersonalInformation Information = GetNextPersonalInformation();
            return new IndividualClient(Id, Email, AccessFailedCount, LockoutEndsDateTimeUTC, ContactAddress, ResidentialAddress, PhoneNumber, Information, ContactTitle, Passwords, UserRoles, Orders, discounts);
        }
    }
}
