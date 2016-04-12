using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Costs", Schema = "Product")]
    public class Cost : IValidatableObject
    {
        #region variables
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Id_of_product")]
        [Required(ErrorMessage = "Id of product can't be empty.")]
        public int ProductId { get; set; }

        [Column("Tax")]
        [Required(ErrorMessage = "Tax can't be empty.")]
        public decimal Tax { get; set; }

        public IList<Price> Prices { get; set; }
        #endregion

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(ProductId,
                new ValidationContext(this, null, null) {MemberName = "ProductId"},
                results);
            if (ProductId >= 0.0M)
            {
                results.Add(new ValidationResult("Id of product must be greater than 0.", new[] {"ProductId"}));
            }
            Validator.TryValidateProperty(Tax,
                new ValidationContext(this, null, null) {MemberName = "Tax"},
                results);
            if (Tax >= 0.0M)
            {
                results.Add(new ValidationResult("Tax must be greater than 0.", new[] {"Tax"}));
            }
            if (Prices != null)
            {
                foreach (Price price in Prices)
                {
                    results.AddRange(price.Validate(validationContext));
                }
            }
            return results;
        }
    }
}
