using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Discount
{
    public class CustomerDiscount : MainDiscount
    {
        #region variables
        [Column("customer_id")]
        [XmlAttribute("customer_id")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Customer id cannot be empty.")]
        public int CustomerId { get; set; }
        #endregion

        public CustomerDiscount(int id, int customerId, Discount discount)
        {
            Id = id;
            CustomerId = customerId;
            Discount = discount;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            results.AddRange(base.Validate(validationContext));
            Validator.TryValidateProperty(CustomerId,
                new ValidationContext(this, null, null) { MemberName = "CustomerId" },
                results);
            return results;
        }
    }
}
