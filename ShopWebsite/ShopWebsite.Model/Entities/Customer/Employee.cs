using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Customer
{
    public class Employee : User
    {
        #region variables
        [Column("position")]
        [XmlAttribute("position")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Position cannot be empty.")]
        [MinLength(5, ErrorMessage = "Length of position should be greater than or equal to 5.")]
        [MaxLength(15, ErrorMessage = "Length of position should be less than or equal to 15.")]
        public string Position { get; set; }

        [XmlElement(ElementName = "personal_information")]//for xml
        [Required(ErrorMessage = "Information has to be given.")]
        public PersonalInformation Information { get; set; }
        #endregion

        [Obsolete("This constructor is only for tests, please use constructor with all variables as parameters.")]
        public Employee()
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
                UserRoles.Add(new UserHasRole(-1,Role.GetOneRole().Id));
            }
            Position = "Position" + rand.Next(5);
            Information = new PersonalInformation();
        }

        public Employee(int id, string email, string position, PersonalInformation information, int accessFailedCount, DateTime lockoutEndsDateTimeUtc, Address contactAddress, Address residentialAddress, string phoneNumber, List<Password> passwords, List<UserHasRole> userRoles)
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
                new ValidationContext(this, null, null) { MemberName = "Position" },
                results);
            if (Information != null)
            {
                results.AddRange(Information.Validate(validationContext));
            }
            return results;
        }
    }
}
