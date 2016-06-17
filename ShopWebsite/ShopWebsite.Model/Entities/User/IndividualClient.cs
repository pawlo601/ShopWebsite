using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.User
{
    [Table("Individual_Client", Schema = "User")]
    public sealed class IndividualClient : Customer
    {
        #region variables

        [XmlElement(ElementName = "personal_information")] //for xml
        [Required(ErrorMessage = "Information has to be given.")]
        public PersonalInformation Information { get; set; }

        #endregion

        #region methods
        public IndividualClient()
        {
        }

        public IndividualClient(int id, string email, int accessFailedCount, DateTime lockoutEndsDateTimeUtc,
            Address contactAddress, Address residentialAddress, string phoneNumber, PersonalInformation information,
            string contactTitle, ICollection<Password> passwords, ICollection<Role> roles, ICollection<Order.Order> orders,
            ICollection<Discount.CustomerDiscount> discounts)
        {
            Id = id;
            Email = email;
            AccessFailedCount = accessFailedCount;
            LockoutEndsDateTimeUTC = lockoutEndsDateTimeUtc;
            ContactAddress = contactAddress;
            ResidentialAddress = residentialAddress;
            PhoneNumber = phoneNumber;
            Passwords = passwords;
            Roles = roles;
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
        #endregion
    }
}
