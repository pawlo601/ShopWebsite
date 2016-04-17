using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Order
{
    [Table("Status", Schema = "Order")]
    public class Status : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("status_name")]
        [XmlAttribute("status_name")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unit name cannot be empty.")]
        [MinLength(3, ErrorMessage = "Length of status name should be greater than or equal to 3.")]
        [MaxLength(10, ErrorMessage = "Length of status name should be less than or equal to 10.")]
        public string Name { get; set; }
        #endregion

        private static Status[] _tableStatus { get; set; }

        private Status() { }

        public static Status GetOneStatus()
        {
            Random rand = new Random();
            if (_tableStatus != null)
            {
                int rr = rand.Next()%_tableStatus.Length;
                return _tableStatus[rr];
            }
            int r = rand.Next()%4;
            _tableStatus=new Status[4];
            _tableStatus[0] = new Status() {Id = -1, Name = "Ok"};
            _tableStatus[1] = new Status() { Id = -1, Name = "Nie Ok" };
            _tableStatus[2] = new Status() { Id = -1, Name = "Prawie Ok" };
            _tableStatus[3] = new Status() { Id = -1, Name = "Zle" };
            return _tableStatus[r];
        }

        public static Status GetOneStatus(int id)
        {
            if (_tableStatus == null)
                return GetOneStatus();
            foreach (Status status in _tableStatus.Where(status => status.Id == id))
                return status;
            return GetOneStatus();
        }

        public static void SetTable(Status[] table)
        {
            _tableStatus = table;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            Validator.TryValidateProperty(Name,
                new ValidationContext(this, null, null) { MemberName = "Name" },
                results);
            return results;
        }
    }
}
