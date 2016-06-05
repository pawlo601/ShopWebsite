using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Order
{
    [Table("Status", Schema = "Order")]
    public class Status : IValidatableObject, IIntroduceable
    {
        #region variables

        [Key]
        [Column("id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("status_name")]
        [XmlAttribute("status_name")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unit name cannot be empty.")]
        [MinLength(3, ErrorMessage = "Length of status name should be greater than or equal to 3.")]
        [MaxLength(10, ErrorMessage = "Length of status name should be less than or equal to 10.")]
        public string Name { get; set; }
        #endregion

        #region methods
        public Status()
        {
        }

        public Status(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
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
