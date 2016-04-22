using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Customer;

namespace ShopWebsite.Model.Entities.User
{
    [Table("Users", Schema = "Customer")]
    public abstract class User : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("email")]
        [XmlAttribute("email")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email cannot be empty.")]
        [MinLength(5, ErrorMessage = "Length of email should be greater than or equal to 5.")]
        [MaxLength(25, ErrorMessage = "Length of email should be less than or equal to 25.")]
        public string Email { get; set; }

        [Column("access_failed_count")]
        [XmlAttribute("access_failed_count")]//for xml
        [Required(ErrorMessage = "Access failed count cannot be empty.")]
        public int AccessFailedCount { get; set; }

        [Column("lockout_ends_date_time_utc")]
        [XmlAttribute("lockout_ends_date_time_utc")]//for xml
        [Required(ErrorMessage = "Time of lockout cannot be empty.")]
        public DateTime LockoutEndsDateTimeUTC { get; set; }

        [Column("contact_address")]
        [XmlElement(ElementName = "contact_address")]//for xml
        [Required(ErrorMessage = "Contact address has to be given.")]
        public Address ContactAddress { get; set; }

        [Column("residential_address")]
        [XmlElement("residential_address")]//for xml
        [Required(ErrorMessage = "Residential address has to be given.")]
        public Address ResidentialAddress { get; set; }

        [Column("phone_number")]
        [XmlAttribute("phone_number")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number cannot be empty.")]
        [MinLength(9, ErrorMessage = "Length of phone number should be greater than or equal to 9.")]
        [MaxLength(15, ErrorMessage = "Length of phone number should be less than or equal to 15.")]
        public string PhoneNumber { get; set; }

        [XmlArray(ElementName = "passwords")]//for xml
        [XmlArrayItem("password", Type = typeof(Password))]//for xml
        public List<Password> Passwords { get; set; }

        [XmlArray(ElementName = "user_roles")]//for xml
        [XmlArrayItem("user_role", Type = typeof(UserHasRole))]//for xml
        public List<UserHasRole> UserRoles { get; set; }
        #endregion

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Email,
                new ValidationContext(this, null, null) {MemberName = "Email"},
                results);
            Validator.TryValidateProperty(AccessFailedCount,
                new ValidationContext(this, null, null) {MemberName = "AccessFailedCount"},
                results);
            Validator.TryValidateProperty(LockoutEndsDateTimeUTC,
                new ValidationContext(this, null, null) {MemberName = "LockoutEndsDateTimeUTC"},
                results);
            Validator.TryValidateProperty(PhoneNumber,
                new ValidationContext(this, null, null) {MemberName = "PhoneNumber"},
                results);
            if (ContactAddress != null)
            {
                results.AddRange(ContactAddress.Validate(validationContext));
            }
            if (ResidentialAddress != null)
            {
                results.AddRange(ResidentialAddress.Validate(validationContext));
            }
            if (Passwords != null)
            {
                foreach (Password password in Passwords)
                {
                    results.AddRange(password.Validate(validationContext));
                }
            }
            if (UserRoles != null)
            {
                foreach (UserHasRole userHasRole in UserRoles)
                {
                    results.AddRange(userHasRole.Validate(validationContext));
                }
            }
            return results;
        }
    }
}
