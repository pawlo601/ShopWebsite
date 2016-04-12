using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Model.Entities.Order
{
    [Table("ORDERS")]
    public class Order : IValidatableObject
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("VALUE_OF_ORDER")]
        [Required(ErrorMessage = "Empty value of order.")]
        public decimal Value { get; set; }

        public IList<ItemInOrder> Items { get; set; }
        public IList<OrderDiscount> OrderDiscounts { get; set; } 
        public IList<StatusOrder> ListOfStatusOrder { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Value,
                new ValidationContext(this, null, null) { MemberName = "Value" },
                results);
            if (Value < 0.0M)
            {
                results.Add(new ValidationResult("Value of order shouldn't be less than 0.0.", new[] { "Value" }));
            }
            return results;
        }
    }
}
