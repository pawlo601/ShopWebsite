using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Order
{
    [Table("StatusOrder", Schema = "Order")]
    public class StatusOrder : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [XmlElement(ElementName = "status")]//for xml
        [Required(ErrorMessage = "Status has to be given.")]
        public Status Status { get; set; }

        [Column("time_of_change")]
        [XmlAttribute("time_of_change")]
        [Required(ErrorMessage = "Time of change of status cannot be empty.")]
        public DateTime TimeOfChange { get; set; }
        #endregion

        public StatusOrder() { }

        public StatusOrder(int id, Status status, DateTime timeOfChange)
        {
            Id = id;
            Status = status;
            TimeOfChange = timeOfChange;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(TimeOfChange,
                new ValidationContext(this, null, null) { MemberName = "TimeOfChange" },
                results);
            if (Status != null)
            {
                results.AddRange(Status.Validate(validationContext));
            }
            return results;
        }
    }
}
