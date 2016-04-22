using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Customer
{
    [Table("user_has_roles", Schema = "Customer")]
    public class UserHasRole : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("user_id")]
        [XmlAttribute("user_id")]//for xml
        [Required(ErrorMessage = "User id cannot be empty.")]
        public int UserId { get; set; }

        [Column("role_id")]
        [XmlAttribute("role_id")]//for xml
        [Required(ErrorMessage = "Role id cannot be empty.")]
        public int RoleId { get; set; }
        #endregion

        public UserHasRole(int id, int userId, int roleId)
        {
            Id = id;
            UserId = userId;
            RoleId = roleId;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(UserId,
                new ValidationContext(this, null, null) { MemberName = "UserId" },
                results);
            if (UserId < 1)
            {
                results.Add(new ValidationResult("UserId should be given.", new[] { "UserId" }));
            }
            Validator.TryValidateProperty(RoleId,
                new ValidationContext(this, null, null) { MemberName = "RoleId" },
                results);
            if (RoleId < 1)
            {
                results.Add(new ValidationResult("RoleId should be given.", new[] { "RoleId" }));
            }
            return results;
        }
    }
}
