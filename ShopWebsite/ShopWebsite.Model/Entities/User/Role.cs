using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.User
{
    [Table("Roles", Schema = "User")]
    public class Role : IValidatableObject, IIntroduceable
    {//todo implemnts
        #region variables

        [Key]
        [Column("id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [XmlAttribute("name")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name of role cannot be empty.")]
        [MinLength(3, ErrorMessage = "Length of name of role should be greater than or equal to 3.")]
        [MaxLength(15, ErrorMessage = "Length of name of role should be less than or equal to 15.")]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsSysAdmin { get; set; }

        public ICollection<Permission> Permissions { get; set; }

        public ICollection<User> Users { get; set; }

        #endregion

        #region methods
        public Role()
        {
        }

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

        public int GetId()
        {
            return Id;
        }
        #endregion
    }
}
