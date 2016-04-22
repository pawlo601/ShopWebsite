using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.User
{
    [Table("Personal_Information", Schema = "Customer")]
    public class PersonalInformation : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [XmlAttribute("name")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be empty.")]
        [MinLength(5, ErrorMessage = "Length of name should be greater than or equal to 5.")]
        [MaxLength(15, ErrorMessage = "Length of name should be less than or equal to 15.")]
        public string Name { get; set; }

        [Column("surname")]
        [XmlAttribute("surname")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname cannot be empty.")]
        [MinLength(5, ErrorMessage = "Length of surname should be greater than or equal to 5.")]
        [MaxLength(30, ErrorMessage = "Length of surname should be less than or equal to 30.")]
        public string Surname { get; set; }

        [Column("birthday")]
        [XmlAttribute("birthday")]//for xml
        [Required(ErrorMessage = "Birthday cannot be empty.")]
        public DateTime Birthday { get; set; }
        #endregion

        public PersonalInformation() { }

        public PersonalInformation(int id, string name, string surname, DateTime birthday)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Name,
                new ValidationContext(this, null, null) { MemberName = "Name" },
                results);
            Validator.TryValidateProperty(Surname,
                new ValidationContext(this, null, null) { MemberName = "Surname" },
                results);
            Validator.TryValidateProperty(Birthday,
                new ValidationContext(this, null, null) { MemberName = "Birthday" },
                results);
            return results;
        }
    }
}
