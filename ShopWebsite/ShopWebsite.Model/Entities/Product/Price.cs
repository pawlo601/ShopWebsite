using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Prices", Schema = "Product")]
    public class Price : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("value_of_price")]
        [XmlAttribute("value_of_price")]//for xml
        [Required(ErrorMessage = "Value should be given.")]
        public decimal Value { get; set; }

        [XmlElement(ElementName = "currency")]//for xml
        [Required(ErrorMessage = "Currency should be given.")]
        public Currency Currency { get; set; }
        #endregion

        public Price() { }

        public Price(int id, decimal value, Currency currency)
        {
            Id = id;
            Value = value;
            Currency = currency;
        }

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
