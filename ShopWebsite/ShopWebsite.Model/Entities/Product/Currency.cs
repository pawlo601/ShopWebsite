using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Curriencies", Schema = "Product")]
    public class Currency : IValidatableObject
    {
        #region variables
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name_of_currency")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty currency name.")]
        [MinLength(3, ErrorMessage = "Currency name lenght should be greater than 2.")]
        [MaxLength(10, ErrorMessage = "Currency name lenght should be less than 11.")]
        public string Name { get; set; }

        [Column("Shortcut_of_currency")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty shortcut.")]
        [MinLength(1, ErrorMessage = "Shortcut lenght should be greater than 0.")]
        [MaxLength(5, ErrorMessage = "Shortcut lenght should be less than 6.")]
        public string ShortCut { get; set; }

        [Column("Exchange_to_dolar")]
        [Required(ErrorMessage = "Exchange is necessary.")]
        public decimal ExchangeToDolar { get; set; }
        #endregion

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Name,
                new ValidationContext(this, null, null) { MemberName = "Name" },
                results);
            Validator.TryValidateProperty(ShortCut,
                new ValidationContext(this, null, null) { MemberName = "ShortCut" },
                results);
            if (ExchangeToDolar <= 0)
            {
                results.Add(new ValidationResult("Exchange should be greater than 0.", new[] { "ExchangeToDolar" }));
            }
            return results;
        }
    }
}
