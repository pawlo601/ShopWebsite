using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    [Table("CUSTOMERS")]
    public abstract class Customer : IValidatableObject
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Column("TITLE_CONACT")]
        [Required(AllowEmptyStrings = true)]
        [MinLength(1, ErrorMessage = "Contact title lenght should be greater than 0.")]
        [MaxLength(10, ErrorMessage = "Contact title lenght should be less than 11.")]
        public string ContactTitle { get; set; }

        public Address ContactAddress { get; set; }

        [Required(ErrorMessage = "Residential address shouldn't be empty.")]
        public Address ResidentialAddress { get; set; }

        [Column("MAIL_1")]
        [EmailAddress(ErrorMessage ="Wrong email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First email shouldn't be empty.")]
        public string Mail1 { get; set; }

        [Column("PHONE_1")]
        [Phone(ErrorMessage = "Wrong phone number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First phone number shouldn't be empty.")]
        public string Phone1 { get; set; }

        [Column("MAIL_2")]
        [EmailAddress(ErrorMessage = "Wrong email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Second mail shouldn't be empty.")]
        public string Mail2 { get; set; }

        [Column("PHONE_2")]
        [Phone(ErrorMessage = "Wrong phone number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Second phone number shouldn't be empty.")]
        public string Phone2 { get; set; }

        public IList<Order> Orders { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(ContactTitle,
                new ValidationContext(this, null, null) { MemberName = "ContactTitle" },
                results);
            Validator.TryValidateProperty(ContactAddress,
                new ValidationContext(this, null, null) { MemberName = "ContactAddress" },
                results);
            Validator.TryValidateProperty(ResidentialAddress,
                new ValidationContext(this, null, null) { MemberName = "ResidentialAddress" },
                results);
            Validator.TryValidateProperty(Mail1,
                new ValidationContext(this, null, null) { MemberName = "Mail1" },
                results);
            Validator.TryValidateProperty(Phone1,
                new ValidationContext(this, null, null) { MemberName = "Phone1" },
                results);
            Validator.TryValidateProperty(Mail2,
                new ValidationContext(this, null, null) { MemberName = "Mail2" },
                results);
            Validator.TryValidateProperty(Phone2,
                new ValidationContext(this, null, null) { MemberName = "Phone2" },
                results);
            if (ContactAddress == null)
            {
                results.Add(new ValidationResult("Contact address shouldn't be empty.", new string[] { "ContactAddress" }));
            }
            if (Phone1.Equals(Phone2))
            {
                results.Add(new ValidationResult("Number of phone1 is the sama as number of phone2.", new string[] { "Phone1", "Phone2" }));
            }
            if (Mail1.Equals(Mail2))
            {
                results.Add(new ValidationResult("Mail1 is the sama as mail2.", new string[] { "Mail1", "Mail2" }));
            }
            return results;
        }
    }
}
