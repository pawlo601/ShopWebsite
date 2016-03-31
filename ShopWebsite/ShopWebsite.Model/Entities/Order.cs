using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    [Table("ORDERS")]
    public class Order : IValidatableObject
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Column("DATE_OF_SUBMISSION")]
        [DataType(DataType.Date, ErrorMessage = "Date of submission should be a date.")]
        [Required(ErrorMessage = "Date of submission shouldn't be empty.")]
        public DateTime DateOfSubmission { get; set; }

        [Column("STATUS_OF_ORDER")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty status of order.")]
        [MinLength(2, ErrorMessage = "Status of order lenght should be greater than 1.")]
        [MaxLength(10, ErrorMessage = "Status of order lenght should be less than 11.")]
        public string StatusOfOrder { get; set; }

        [Column("VALUE_OF_ORDER")]
        [Required(ErrorMessage = "Empty value of order.")]
        public decimal Value { get; set; }

        public List<PositionInTheOrder> OrderedItems { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(DateOfSubmission,
                new ValidationContext(this, null, null) { MemberName = "DateOfSubmission" },
                results);
            Validator.TryValidateProperty(StatusOfOrder,
                new ValidationContext(this, null, null) { MemberName = "StatusOfOrder" },
                results);
            Validator.TryValidateProperty(Value,
                new ValidationContext(this, null, null) { MemberName = "Value" },
                results);
            if (DateOfSubmission < new DateTime(1900, 1, 1))
            {
                results.Add(new ValidationResult("Date of submission should be later than 1.1.1990", new[] { "DateOfSubmission" }));
            }
            if (DateOfSubmission > new DateTime(2017, 12, 31))
            {
                results.Add(new ValidationResult("Date of submission should be ealier than 31.12.2017", new[] { "DateOfSubmission" }));
            }
            if (Value < 0.0M)
            {
                results.Add(new ValidationResult("Value of order shouldn't be less than 0.0.", new[] { "Value" }));
            }
            return results;
        }
    }
}
