using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Quantities", Schema = "Product")]
    public class Quantity : IValidatableObject
    {
        #region variables
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Value_of_quantity")]
        [Required(ErrorMessage = "Value of quantity has to be given.")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Unit has to be given.")]
        public Unit Unit { get; set; }
        #endregion

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (Unit != null)
            {
                results.AddRange(Unit.Validate(validationContext));
            }
            if (Value <= 0.0M)
            {
                results.Add(new ValidationResult("Value of quantity has to be greater 0.", new[] { "Value" }));
            }
            return results;
        }
    }
}
