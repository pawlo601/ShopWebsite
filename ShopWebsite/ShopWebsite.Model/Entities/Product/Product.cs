using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Products", Schema = "Product")]
    public class Product : IValidatableObject
    {
        #region variables
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name_of_product")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty product name.")]
        [MinLength(5, ErrorMessage = "Product name lenght should be greater than 4.")]
        [MaxLength(30, ErrorMessage = "Product name lenght should be less than 31.")]
        public string Name { get; set; }

        [Column("Description_of_product")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty product description.")]
        [MinLength(5, ErrorMessage = "Product description lenght should be greater than 4.")]
        [MaxLength(100, ErrorMessage = "Product description lenght should be less than 101.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Cost of product has to be given.")]
        public Cost Cost { get; set; }

        [Column("Discount_on_product")]
        public decimal Discount { get; set; }

        [Required(ErrorMessage = "Quantity of product has to be given.")]
        public Quantity Quantity { get; set; }
        #endregion

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Name,
                new ValidationContext(this, null, null) { MemberName = "Name" },
                results);
            Validator.TryValidateProperty(Description,
                new ValidationContext(this, null, null) { MemberName = "Description" },
                results);
            Validator.TryValidateProperty(Discount,
                new ValidationContext(this, null, null) { MemberName = "Discount" },
                results);
            if (Discount < 0.0M)
            {
                results.Add(new ValidationResult("Discount of product should be greater than or equal to 0.", new[] { "Discount" }));    
            }
            if (Cost != null)
            {
                results.AddRange(Cost.Validate(validationContext));
            }
            if (Quantity != null)
            {
                results.AddRange(Quantity.Validate(validationContext));
            }
            return results;
        }
    }
}
