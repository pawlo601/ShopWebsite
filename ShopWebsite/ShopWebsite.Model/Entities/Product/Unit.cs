using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Units", Schema = "Product")]
    public class Unit : IValidatableObject, IIntroduceable
    {
        #region variables

        [Key]
        [Column("id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("unit_name1")]
        [XmlAttribute("unit_name1")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unit name cannot be empty.")]
        [MinLength(3, ErrorMessage = "Length of unit name should be greater than or equal to 3.")]
        [MaxLength(10, ErrorMessage = "Length of unit name should be less than or equal to 10.")]
        public string Name { get; set; }

        [Column("unit_shortcut")]
        [XmlAttribute("unit_name")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unit shortcut cannot be empty.")]
        [MinLength(1, ErrorMessage = "Length of unit shortcut should be greater than or equal to 1.")]
        [MaxLength(5, ErrorMessage = "Length of unit shortcut should be less than or equal to 5.")]
        public string Shortcut { get; set; }

        #endregion

        #region methods
        public Unit()
        {
        }

        public Unit(int id, string name, string shortcut)
        {
            Id = id;
            Name = name;
            Shortcut = shortcut;
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
            return results;
        }

        public int GetId()
        {
            return Id;
        }
        #endregion
    }
}
