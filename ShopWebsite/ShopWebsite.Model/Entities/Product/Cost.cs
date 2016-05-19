using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Costs", Schema = "Product")]
    public class Cost : IValidatableObject, IIntroduceable
    {
        #region variables

        [Key]
        [Column("id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("tax")]
        [XmlAttribute("tax")] //for xml
        [Required(ErrorMessage = "Tax cannot be empty.")]
        public decimal Tax { get; set; }

        [XmlArray(ElementName = "prices")] //for xml
        [XmlArrayItem("price", Type = typeof (Price))] //for xml
        public List<Price> Prices { get; set; }

        #endregion

        public Cost()
        {
        }

        public Cost(int id, decimal tax, List<Price> prices)
        {
            Id = id;
            Tax = tax;
            Prices = prices;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Tax,
                new ValidationContext(this, null, null) {MemberName = "Tax"},
                results);
            if (Tax < 0.0M)
            {
                results.Add(new ValidationResult("Tax must be greater than or equal 0%.", new[] {"Tax"}));
            }
            if (Tax > 1.0M)
            {
                results.Add(new ValidationResult("Tax must be smaller than or equal 100%.", new[] {"Tax"}));
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

        public int GetId()
        {
            return Id;
        }
    }
}
