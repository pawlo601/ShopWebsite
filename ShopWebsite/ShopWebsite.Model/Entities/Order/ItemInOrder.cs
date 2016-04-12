using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities.Order
{
    [Table("POSITIONS_IN_THE_ORDERS")]
    public class ItemInOrder : IValidatableObject
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("PRODUCT_ID")]
        public int ProductId { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (Quantity <= 0)
            {
                results.Add(new ValidationResult("Quantity of product should be greater than 0.0", new[] { "Quantity" }));
            }
            return results;
        }
    }
}
