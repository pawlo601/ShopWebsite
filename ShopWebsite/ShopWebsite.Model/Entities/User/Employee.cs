using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.User
{
    [Table("Employee", Schema = "User")]
    public class Employee : User
    {
        #region variables

        [Column("position")]
        [XmlAttribute("position")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Position cannot be empty.")]
        [MinLength(5, ErrorMessage = "Length of position should be greater than or equal to 5.")]
        [MaxLength(15, ErrorMessage = "Length of position should be less than or equal to 15.")]
        public string Position { get; set; }

        [XmlElement(ElementName = "personal_information")] //for xml
        [Required(ErrorMessage = "Information has to be given.")]
        public PersonalInformation Information { get; set; }

        #endregion

        public Employee()
        {
        }

        public Employee(int id, string email, string position, PersonalInformation information, int accessFailedCount,
            DateTime lockoutEndsDateTimeUtc, Address contactAddress, Address residentialAddress, string phoneNumber,
            List<Password> passwords, List<UserHasRole> userRoles)
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
            Position = position;
            Information = information;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            results.AddRange(base.Validate(validationContext));
            Validator.TryValidateProperty(Position,
                new ValidationContext(this, null, null) {MemberName = "Position"},
                results);
            if (Information != null)
            {
                results.AddRange(Information.Validate(validationContext));
            }
            return results;
        }
    }
}
