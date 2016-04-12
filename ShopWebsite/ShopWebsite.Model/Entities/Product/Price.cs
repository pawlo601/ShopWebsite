using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Prices", Schema = "Product")]
    public class Price : IValidatableObject
    {
        #region variables
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Value_of_price")]
        [Required(ErrorMessage = "Value should be given.")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Currency should be given.")]
        public Currency Currency { get; set; }
        #endregion

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (Currency != null)
            {
                results.AddRange(Currency.Validate(validationContext));
            }
            if (Value < 0.0M)
            {
                results.Add(new ValidationResult("Value of price should be greater than or equal to 0.", new[] { "Value" }));
            }
            return results;
        }
    }
}
