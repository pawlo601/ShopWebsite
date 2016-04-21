using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Discount
{
    [Table("Discounts",Schema = "Discount")]
    [XmlInclude(typeof(PercantageDiscount))]
    [XmlInclude(typeof(ConstantDiscount))]
    public abstract class Discount : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name_of_discount")]
        [XmlAttribute("name_of_discount")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Discount name cannot be empty.")]
        [MinLength(5, ErrorMessage = "Discount of product name should be greater than or equal to 5.")]
        [MaxLength(20, ErrorMessage = "Discount of product name should be less than or equal to 20.")]
        public string Name { get; set; }

        [Column("is_for_product")]
        [XmlAttribute("is_for_product")]//for xml
        [Required(ErrorMessage = "IsForProduct cannot be empty.")]
        public bool IsForProduct { get; set; }
        
        [Column("start_discount")]
        [XmlAttribute("start_discount")]
        [Required(ErrorMessage = "Time of start of discount cannot be empty.")]
        public DateTime StartDiscount { get; set; }

        [Column("end_discount")]
        [XmlAttribute("end_discount")]
        [Required(ErrorMessage = "Time of end of discount cannot be empty.")]
        public DateTime EndDisscount { get; set; }
        #endregion

        public abstract decimal CountDiscount(decimal value);

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Name,
                new ValidationContext(this, null, null) { MemberName = "Name" },
                results);
            Validator.TryValidateProperty(IsForProduct,
                new ValidationContext(this, null, null) { MemberName = "IsForProduct" },
                results);
            if (StartDiscount.CompareTo(EndDisscount) > 0)
            {
                results.Add(new ValidationResult("Time of start should be earlier than end.", new[] { "StartDiscount", "EndDisscount" }));
            }
            return results;
        }
    }
}
