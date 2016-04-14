using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities.Customer
{
    [Table("CUSTOMERS")]
    public abstract class Customer : User, IValidatableObject
    {
        [Column("TITLE_CONACT")]
        [Required(AllowEmptyStrings = true)]
        [MinLength(1, ErrorMessage = "Contact title lenght should be greater than 0.")]
        [MaxLength(10, ErrorMessage = "Contact title lenght should be less than 11.")]
        public string ContactTitle { get; set; }

        public IList<Order.Order> Orders { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(ContactTitle,
                new ValidationContext(this, null, null) { MemberName = "ContactTitle" },
                results);
            Validator.TryValidateProperty(ResidentialAddress,
                new ValidationContext(this, null, null) { MemberName = "ResidentialAddress" },
                results);
            
            if (ContactAddress != null)
            {
                results.AddRange(ContactAddress.Validate(validationContext));
            }
            if (ResidentialAddress != null)
            {
                results.AddRange(ResidentialAddress.Validate(validationContext));
            }
            return results;
        }
    }
}
