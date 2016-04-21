using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Customer
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

        private static Role[] _roles { get; set; }

        private Role() { }

        public static Role GetOneRole()
        {
            Random rand = new Random();
            if (_roles != null)
            {
                int r1 = rand.Next()%_roles.Length;
                return _roles[r1];
            }
            int r = rand.Next()%3;
            _roles = new Role[3];
            _roles[0] = new Role() {Id = -1, Name = "ADMIN"};
            _roles[1] = new Role() {Id = -1, Name = "USER"};
            _roles[2] = new Role() {Id = -1, Name = "EMPLOEE"}; 
            return _roles[r];
        }

        public static Role GetOneRole(int id)
        {
            if (_roles == null)
                GetOneRole();
            foreach (Role role in _roles.Where(role => role.Id == id))
                return role;
            return GetOneRole();
        }

        public static void SetTableUnits(Role[] table)
        {
            _roles = table;
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
