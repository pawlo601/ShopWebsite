using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Customer;

namespace ShopWebsite.Model.Entities.User
{
    public class Company : Customer
    {
        #region variables
        [XmlElement(ElementName = "company_information")]//for xml
        [Required(ErrorMessage = "Information has to be given.")]
        public CompanyInformation Information { get; set; }
        #endregion

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
