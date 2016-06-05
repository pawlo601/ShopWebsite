using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Curriencies", Schema = "Product")]
    public class Currency : IValidatableObject, IIntroduceable
    {
        #region variables

        [Key]
        [Column("id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("currency_name")]
        [XmlAttribute("currency_name")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Currency name cannot be empty.")]
        [MinLength(3, ErrorMessage = "Length of currency name should be greater than or equal to 3.")]
        [MaxLength(10, ErrorMessage = "Length of currency name should be less than or equal to 10.")]
        public string Name { get; set; }

        [Column("currency_shortcut")]
        [XmlAttribute("currency_shortcut")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Shortcut cannot be empty.")]
        [MinLength(1, ErrorMessage = "Length of shortcut should be greater than or equal to 1.")]
        [MaxLength(5, ErrorMessage = "Length of shortcut should be less than or equal to 5.")]
        public string Shortcut { get; set; }

        [Column("exchange_to_dolar")]
        [XmlAttribute("exchange_to_dolar")] //for xml
        [Required(ErrorMessage = "Exchange is necessary.")]
        public decimal ExchangeToDolar { get; set; }

        #endregion

        #region methods
        public Currency()
        {
        }

        public Currency(int id, string name, string shortcut, decimal exchangeToDolar)
        {
            Id = id;
            Name = name;
            Shortcut = shortcut;
            ExchangeToDolar = exchangeToDolar;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Name,
                new ValidationContext(this, null, null) { MemberName = "Name" },
                results);
            Validator.TryValidateProperty(Shortcut,
                new ValidationContext(this, null, null) { MemberName = "Shortcut" },
                results);
            Validator.TryValidateProperty(ExchangeToDolar,
                new ValidationContext(this, null, null) { MemberName = "ExchangeToDolar" },
                results);
            if (ExchangeToDolar <= 0)
            {
                results.Add(new ValidationResult("Exchange should be greater than 0.", new[] { "ExchangeToDolar" }));
            }
            return results;
        }

        public int GetId()
        {
            return Id;
        }
        #endregion
    }
}
