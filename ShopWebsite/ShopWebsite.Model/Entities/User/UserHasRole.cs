using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.User
{
    [Table("user_has_roles", Schema = "User")]
    public class UserHasRole : IValidatableObject
    {
        #region variables

        [Key]
        [Column("id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("user_id")]
        [XmlAttribute("user_id")] //for xml
        [Required(ErrorMessage = "User id cannot be empty.")]
        public int UserId { get; set; }

        [XmlElement(ElementName = "role")] //for xml
        [Required(ErrorMessage = "Role has to be given.")]
        public Role Role { get; set; }

        #endregion

        public UserHasRole()
        {
        }

        public UserHasRole(int id, int userId, Role role)
        {
            Id = id;
            UserId = userId;
            Role = role;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(UserId,
                new ValidationContext(this, null, null) {MemberName = "UserId"},
                results);
            if (UserId < 1)
            {
                results.Add(new ValidationResult("UserId should be given.", new[] {"UserId"}));
            }
            if (Role != null)
            {
                results.AddRange(Role.Validate(validationContext));
            }
            return results;
        }
    }
}
