using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    [Table("PRODUCTS")]
    public class Product : IValidatableObject
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Column("NAME_OF_PRODUCT")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty product name.")]
        [MinLength(5, ErrorMessage = "Product name lenght should be greater than 4.")]
        [MaxLength(30, ErrorMessage = "Product name lenght should be less than 31.")]
        public string ProductName { get; set; }

        [Column("DESCRIPTION_OF_PRODUCT")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty product description.")]
        [MinLength(5, ErrorMessage = "Product description lenght should be greater than 4.")]
        [MaxLength(100, ErrorMessage = "Product description lenght should be less than 101.")]
        public string ProductDescription { get; set; }

        [Column("QUANTITY_PER_UNIT")]
        [Required(ErrorMessage = "Empty quantity of product.")]
        public decimal QuantityPerUnit { get; set; }

        [Column("PRICE_PER_UNIT")]
        [Required(ErrorMessage = "Empty price of product.")]
        public decimal PricePerUnit { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(ProductName,
                new ValidationContext(this, null, null) { MemberName = "ProductName" },
                results);
            Validator.TryValidateProperty(ProductDescription,
                new ValidationContext(this, null, null) { MemberName = "ProductDescription" },
                results);
            Validator.TryValidateProperty(QuantityPerUnit,
                new ValidationContext(this, null, null) { MemberName = "QuantityPerUnit" },
                results);
            Validator.TryValidateProperty(PricePerUnit,
                new ValidationContext(this, null, null) { MemberName = "PricePerUnit" },
                results);
            if (QuantityPerUnit <= 0)
            {
                results.Add(new ValidationResult("Quantity of product should be greater than 0.0", new[] { "QuantityPerUnit" }));
            }
            if (PricePerUnit <= 0)
            {
                results.Add(new ValidationResult("Price of product should be greater than 0.0", new[] { "PricePerUnit" }));
            }
            return results;
        }

        public int GetMyId()
        {
            return ProductId;
        }
    }
}
