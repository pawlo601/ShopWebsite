using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Audit
{
    public enum Action { Create, Edit, Remove, Get, Show, Begin }

    [Table("Audits", Schema = "Log")]
    public class Audit : IIntroduceable, IValidatableObject
    {
        [Key]
        [Column("product_id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("session_id")]
        [XmlAttribute("session_id")] //for xml
        public string SessionId { get; set; }

        [Column("ip_address")]
        [XmlAttribute("ip_address")] //for xml
        public string AddressIP { get; set; }

        [Column("user_name")]
        [XmlAttribute("user_name")] //for xml
        public string UserName { get; set; }

        [Column("url_accessed")]
        [XmlAttribute("url_accessed")] //for xml
        public string URLAccessed { get; set; }

        [Column("action")]
        [XmlAttribute("action")] //for xml
        public Action Action { get; set; }

        [Column("property_name")]
        [XmlAttribute("property_name")] //for xml
        public string PropertyName { get; set; }

        [Column("time_accessed")]
        [XmlAttribute("time_accessed")] //for xml
        public DateTime TimeAccessed { get; set; }

        [Column("data")]
        [XmlAttribute("data")] //for xml
        public string Data { get; set; }

        [Column("additional_information")]
        [XmlAttribute("additional_information")] //for xml
        public string AdditionalInformation { get; set; }

        public int GetId()
        {
            return Id;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}