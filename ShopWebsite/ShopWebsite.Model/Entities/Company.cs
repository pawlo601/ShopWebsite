using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    public class Company : Customer, IValidatableObject
    {
        [Column("NAME_OF_COMPANY")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty company name.")]
        [MinLength(5, ErrorMessage = "Company name lenght should be greater than 4.")]
        [MaxLength(20, ErrorMessage = "Company name lenght should be less than 21.")]
        public string CompanyName { get; set; }

        [Column("REGON")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty REGON.")]
        [MinLength(8, ErrorMessage = "REGON lenght should be greater than 7.")]
        [MaxLength(10, ErrorMessage = "REGON lenght should be less than 11.")]
        public string REGON { get; set; }

        [Column("TAX_ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty TaxID.")]
        [MinLength(8, ErrorMessage = "TaxID lenght should be greater than 7.")]
        [MaxLength(10, ErrorMessage = "TaxID lenght should be less than 11.")]
        public string TaxID { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            results.AddRange(base.Validate(validationContext));
            Validator.TryValidateProperty(CompanyName,
                new ValidationContext(this, null, null) { MemberName = "CompanyName" },
                results);
            Validator.TryValidateProperty(REGON,
                new ValidationContext(this, null, null) { MemberName = "REGON" },
                results);
            Validator.TryValidateProperty(TaxID,
                new ValidationContext(this, null, null) { MemberName = "TaxID" },
                results);
            return results;
        }
    }
}
