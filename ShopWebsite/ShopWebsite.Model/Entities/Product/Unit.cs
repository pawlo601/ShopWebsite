using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Units", Schema = "Product")]
    public class Unit : IValidatableObject
    {
        #region variables
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name_of_unit")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty unit name.")]
        [MinLength(3, ErrorMessage = "Unit name lenght should be greater than 2.")]
        [MaxLength(10, ErrorMessage = "Unit name lenght should be less than 11.")]
        public string Name { get; set; }

        [Column("Shortcut_of_unit")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No unit shortcut.")]
        [MinLength(1, ErrorMessage = "Unit lenght should be greater than 0.")]
        [MaxLength(5, ErrorMessage = "Unit lenght should be less than 6.")]
        public string ShortCut { get; set; }
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
            return results;
        }
    }
}
