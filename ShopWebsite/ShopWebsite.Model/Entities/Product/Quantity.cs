using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Quantities", Schema = "Product")]
    public class Quantity : IValidatableObject, IIntroduceable
    {
        #region variables

        [Key]
        [Column("quantity_id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("quantity_value")]
        [XmlAttribute("quantity_value")] //for xml
        [Required(ErrorMessage = "Value of quantity has to be given.")]
        public decimal Value { get; set; }

        [XmlElement(ElementName = "unit")] //for xml
        [Required(ErrorMessage = "Unit has to be given.")]
        public Unit Unit { get; set; }

        #endregion

        #region methods
        public Quantity()
        {
        }

        public Quantity(int id, decimal value, Unit unit)
        {
            Id = id;
            Value = value;
            Unit = unit;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (Unit != null)
            {
                results.AddRange(Unit.Validate(validationContext));
            }
            if (Value <= 0.0M)
            {
                results.Add(new ValidationResult("Value of quantity has to be greater 0.", new[] { "Value" }));
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
