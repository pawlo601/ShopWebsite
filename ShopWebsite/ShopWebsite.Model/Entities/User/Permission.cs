﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.User
{
    [Table("Permissions", Schema = "User")]
    public sealed class Permission : IValidatableObject, IIntroduceable
    {
        #region variables
        [Key]
        [Column("permission_id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("description")]
        [XmlAttribute("description")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description cannot be empty.")]
        [MinLength(3, ErrorMessage = "Length of description should be greater than or equal to 3.")]
        [MaxLength(25, ErrorMessage = "Length of description should be less than or equal to 25.")]
        public string Description { get; set; }

        [XmlArray(ElementName = "roles")] //for xml
        [XmlArrayItem("role", Type = typeof(Role))] //for xml
        public ICollection<Role> Roles { get; set; }
        #endregion

        #region methods

        public Permission()
        {
        }

        public Permission(int id, string description)
        {
            Id = id;
            Description = description;
            Roles = new List<Role>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Description,
                new ValidationContext(this, null, null) { MemberName = "Description" },
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