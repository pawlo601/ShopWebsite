using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Discount
{
    [Table("Main_discounts", Schema = "Discount")]
    public abstract class MainDiscount : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [XmlElement(ElementName = "discount")]//for xml
        [Required(ErrorMessage = "Discount for customer has to be given.")]
        public Discount Discount { get; set; }
        #endregion

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Discount,
                new ValidationContext(this, null, null) { MemberName = "Discount" },
                results);
            if (Discount != null)
            {
                results.AddRange(Discount.Validate(validationContext));
            }
            return results;
        }
    }
}
