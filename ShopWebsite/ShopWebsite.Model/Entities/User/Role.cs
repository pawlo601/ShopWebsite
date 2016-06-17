using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.User
{
    [Table("Roles", Schema = "User")]
    public sealed class Role : IValidatableObject, IIntroduceable
    {
        #region variables
        [Key]
        [Column("role_id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [XmlAttribute("name")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name of role cannot be empty.")]
        [MinLength(3, ErrorMessage = "Length of name of role should be greater than or equal to 3.")]
        [MaxLength(15, ErrorMessage = "Length of name of role should be less than or equal to 15.")]
        public string Name { get; set; }

        [Column("description")]
        [XmlAttribute("description")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description cannot be empty.")]
        [MinLength(5, ErrorMessage = "Length of description should be greater than or equal to 5.")]
        [MaxLength(25, ErrorMessage = "Length of description should be less than or equal to 25.")]
        public string Description { get; set; }

        [Column("isSysAdmin")]
        [XmlAttribute("isSysAdmin")] //for xml
        [Required(ErrorMessage = "IsSysAdmin cannot be empty.")]
        public bool IsSysAdmin { get; set; }

        [XmlArray(ElementName = "permissions")] //for xml
        [XmlArrayItem("permission", Type = typeof(Permission))] //for xml
        public ICollection<Permission> Permissions { get; set; }

        public ICollection<User> Users { get; set; }
        #endregion

        #region methods
        public Role()
        {
        }

        public Role(int id, string name, string description, bool isSysAdmin, ICollection<Permission> permissions)
        {
            Id = id;
            Name = name;
            Description = description;
            IsSysAdmin = isSysAdmin;
            Permissions = permissions;
            Users = new List<User>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Name,
                new ValidationContext(this, null, null) { MemberName = "Name" },
                results);
            Validator.TryValidateProperty(Description,
                new ValidationContext(this, null, null) { MemberName = "Description" },
                results);
            Validator.TryValidateProperty(IsSysAdmin,
                new ValidationContext(this, null, null) { MemberName = "IsSysAdmin" },
                results);
            if (Permissions != null)
            {
                foreach (Permission permission in Permissions)
                {
                    results.AddRange(permission.Validate(validationContext));
                }
            }
            return results;
        }

        public int GetId()
        {
            return Id;
        }

        public void AddPermission(Permission permission)
        {
            Permissions.Add(permission);
            permission.Roles.Add(this);
        }

        public void AddPermissions(ICollection<Permission> permissions)
        {
            foreach (Permission permission in permissions)
            {
                AddPermission(permission);
            }
        }
        #endregion
    }
}
