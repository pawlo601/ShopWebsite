using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Log
{
    [Table("OperationLogs", Schema = "Log")]
    public class OperationLog
    {
        [Key]
        [Column("id")]
        [XmlAttribute("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [XmlAttribute("operation_name")]
        [Column("operation_name")]
        [MaxLength(4000)]
        public string OperationName { get; set; }

        [XmlAttribute("date")]
        [Column("date")]
        public DateTime Date { get; set; }

        [XmlAttribute("user_id")]
        [Column("user_id")]
        public int UserId { get; set; }

        [XmlAttribute("conforming_employee_id")]
        [Column("conforming_employee_id")]
        public int? ConformingEmployeeId { get; set; }

        [XmlAttribute("method_name")]
        [Column("method_name")]
        [MaxLength(4000)]
        public string MethodName { get; set; }

        [XmlAttribute("method_params")]
        [Column("method_params")]
        [MaxLength(4000)]
        public string MethodParams { get; set; }
    }
}