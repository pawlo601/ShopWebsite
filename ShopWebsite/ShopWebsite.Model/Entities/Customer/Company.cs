using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Customer
{
    public class Company : Customer
    {
        #region variables
        [XmlElement(ElementName = "company_information")]//for xml
        [Required(ErrorMessage = "Information has to be given.")]
        public CompanyInformation Information { get; set; }
        #endregion

        [Obsolete("This constructor is only for tests, please use constructor with all variables as parameters.")]
        public Company()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            Id = -1;
            Email = "Mail" + rand.Next(100);
            AccessFailedCount = 0;
            LockoutEndsDateTimeUTC = DateTime.Now.AddDays(-1);
            ContactAddress = new Address();
            ResidentialAddress = new Address();
            PhoneNumber = "PhoneNu" + rand.Next(100);
            Passwords = new List<Password>();
            int r = rand.Next(1,4);
            for (int i = 0; i < r; i++)
            {
                Passwords.Add(new Password(
                    userId: -1,
                    hashedPassword: "hp" + rand.Next(1000),
                    passwordSalt: "ps" + rand.Next(1000),
                    createTime: DateTime.Now.AddDays(-rand.Next(10)))
                    );
            }
            UserRoles = new List<UserHasRole>();
            int r1 = rand.Next(1,2);
            for (int i = 0; i < r1; i++)
            {
                var a = Role.GetOneRole();
                UserRoles.Add(new UserHasRole(-1, a.Id));
            }
            Information = new CompanyInformation();
            ContactTitle = "ContTit" + rand.Next(10);
            Orders = new List<Order.Order>();
            int r2 = rand.Next(1,5);
            for (int i = 0; i < r2; i++)
            {
                Orders.Add(new Order.Order());
            }
        }

        public Company(int id, string email, int accessFailedCount, DateTime lockoutEndsDateTimeUtc, Address contactAddress, Address residentialAddress, string phoneNumber, CompanyInformation information, string contactTitle, List<Password> passwords, List<UserHasRole> userRoles, List<Order.Order> orders)
        {
            Id = id;
            Email = email;
            AccessFailedCount = accessFailedCount;
            LockoutEndsDateTimeUTC = lockoutEndsDateTimeUtc;
            ContactAddress = contactAddress;
            ResidentialAddress = residentialAddress;
            PhoneNumber = phoneNumber;
            Passwords = passwords;
            UserRoles = userRoles;
            Information = information;
            ContactTitle = contactTitle;
            Orders = orders;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            results.AddRange(base.Validate(validationContext));
            if (Information != null)
            {
                results.AddRange(Information.Validate(validationContext));
            }
            return results;
        }
    }
}
