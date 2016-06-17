using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Discount
{
    [Table("Discounts", Schema = "Discount")]
    public class Discount : IValidatableObject, IIntroduceable
    {
        #region variables

        [Key]
        [Column("discount_id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name_of_discount")]
        [XmlAttribute("name_of_discount")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Discount name cannot be empty.")]
        [MinLength(5, ErrorMessage = "Discount of product name should be greater than or equal to 5.")]
        [MaxLength(20, ErrorMessage = "Discount of product name should be less than or equal to 20.")]
        public string Name { get; set; }

        [Column("is_for_product")]
        [XmlAttribute("is_for_product")] //for xml
        [Required(ErrorMessage = "IsForProduct cannot be empty.")]
        public bool IsForProduct { get; set; }

        [Column("is_for_customer")]
        [XmlAttribute("is_for_customer")] //for xml
        [Required(ErrorMessage = "IsForCustomer cannot be empty.")]
        public bool IsForCustomer { get; set; }

        [Column("is_for_order")]
        [XmlAttribute("is_for_order")] //for xml
        [Required(ErrorMessage = "IsForOrder cannot be empty.")]
        public bool IsForOrder { get; set; }

        [Column("is_percentage")]
        [XmlAttribute("is_percentage")] //for xml
        [Required(ErrorMessage = "IsPercentage cannot be empty.")]
        public bool IsPercentage { get; set; }

        [Column("value_of_discount")]
        [XmlAttribute("value_of_discount")] //for xml
        [Required(ErrorMessage = "Value should be given.")]
        public double Value { get; set; }

        [Column("start_discount")]
        [XmlAttribute("start_discount")]
        [Required(ErrorMessage = "Time of start of discount cannot be empty.")]
        public DateTime StartDiscount { get; set; }

        [Column("end_discount")]
        [XmlAttribute("end_discount")]
        [Required(ErrorMessage = "Time of end of discount cannot be empty.")]
        public DateTime EndDiscount { get; set; }

        #endregion

        #region methods
        public Discount()
        {
        }

        public Discount(int id, string name, bool isForProduct, bool isForCustomer, bool isForOrder, bool isPercentage,
            double value, DateTime startDiscount, DateTime endDisscount)
        {
            Id = id;
            Name = name;
            IsForProduct = isForProduct;
            IsForCustomer = isForCustomer;
            IsForOrder = isForOrder;
            IsPercentage = isPercentage;
            Value = value;
            StartDiscount = startDiscount;
            EndDiscount = endDisscount;
        }

        public decimal CountDiscount(decimal value)
        {
            if (IsPercentage)
                return (decimal)((double)value * (1.0 - Value));
            return value - (decimal)Value;
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Name,
                new ValidationContext(this, null, null) { MemberName = "Name" },
                results);
            Validator.TryValidateProperty(IsForProduct,
                new ValidationContext(this, null, null) { MemberName = "IsForProduct" },
                results);
            Validator.TryValidateProperty(IsForCustomer,
                new ValidationContext(this, null, null) { MemberName = "IsForCustomer" },
                results);
            Validator.TryValidateProperty(IsForOrder,
                new ValidationContext(this, null, null) { MemberName = "IsForOrder" },
                results);
            Validator.TryValidateProperty(Value,
                new ValidationContext(this, null, null) { MemberName = "Value" },
                results);
            if (Value < 0.0)
            {
                results.Add(new ValidationResult("Value of discount should be greater than or equal to 0.",
                    new[] { "Value" }));
            }
            if (StartDiscount.CompareTo(EndDiscount) > 0)
            {
                results.Add(new ValidationResult("Time of start should be earlier than end.",
                    new[] { "StartDiscount", "EndDisscount" }));
            }
            if (IsForProduct && IsForCustomer && IsForOrder)
            {
                results.Add(new ValidationResult("Discount can't be for product, customer and order in the same time.",
                    new[] { "IsForProduct", "IsForCustomer", "IsForOrder" }));
            }
            if (!(IsForProduct || IsForCustomer || IsForOrder))
            {
                results.Add(new ValidationResult("Discount have to be for product or for customer or for order.",
                    new[] { "IsForProduct", "IsForCustomer", "IsForOrder" }));
            }
            if (IsForCustomer && IsForOrder)
            {
                results.Add(new ValidationResult("Discount can't be for customer and order in the same time.",
                    new[] { "IsForCustomer", "IsForOrder" }));
            }
            if (IsForProduct && IsForOrder)
            {
                results.Add(new ValidationResult("Discount can't be for product and order in the same time.",
                    new[] { "IsForProduct", "IsForOrder" }));
            }
            if (IsForProduct && IsForCustomer)
            {
                results.Add(new ValidationResult("Discount can't be for product and customer in the same time.",
                    new[] { "IsForProduct", "IsForCustomer" }));
            }
            return results;
        }

        public int GetId()
        {
            return Id;
        }
        #endregion
    }
}
