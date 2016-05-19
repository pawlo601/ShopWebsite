using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.User
{
    [Table("IndividualClient", Schema = "User")]
    public class IndividualClient : Customer
    {
        #region variables

        [XmlElement(ElementName = "personal_information")] //for xml
        [Required(ErrorMessage = "Information has to be given.")]
        public PersonalInformation Information { get; set; }

        #endregion

        public IndividualClient()
        {
        }

        public IndividualClient(int id, string email, int accessFailedCount, DateTime lockoutEndsDateTimeUtc,
            Address contactAddress, Address residentialAddress, string phoneNumber, PersonalInformation information,
            string contactTitle, List<Password> passwords, List<UserHasRole> userRoles, List<Order.Order> orders,
            List<Discount.CustomerDiscount> discounts)
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
            Discounts = discounts;
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
