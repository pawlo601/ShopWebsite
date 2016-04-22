using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.User
{
    [Table("Roles", Schema = "Customer")]
    public class Role : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [XmlAttribute("name")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name of role cannot be empty.")]
        [MinLength(3, ErrorMessage = "Length of name of role should be greater than or equal to 3.")]
        [MaxLength(15, ErrorMessage = "Length of name of role should be less than or equal to 15.")]
        public string Name { get; set; }
        #endregion

        public Role() { }

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Name,
                new ValidationContext(this, null, null) { MemberName = "Name" },
                results);
            return results;
        }
    }
}
