using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Discount
{
    [Table("ToDiscount", Schema = "Discount")]
    public abstract class SomeDiscount : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [XmlElement(ElementName = "discount")]//for xml
        [Required(ErrorMessage = "Discount has to be given.")]
        public Discount Discount { get; set; }
        #endregion

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (Discount != null)
            {
                results.AddRange(Discount.Validate(validationContext));
            }
            return results;
        }
    }
}
