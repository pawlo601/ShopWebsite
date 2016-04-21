using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Customer
{
    [Table("Company_Information", Schema = "Customer")]
    public class CompanyInformation : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("company_name")]
        [XmlAttribute("company_name")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Company name cannot be empty.")]
        [MinLength(5, ErrorMessage = "Length of company name should be greater than or equal to 5.")]
        [MaxLength(30, ErrorMessage = "Length of company name should be less than or equal to 30.")]
        public string CompanyName { get; set; }

        [Column("regon")]
        [XmlAttribute("regon")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Regon cannot be empty.")]
        [MinLength(5, ErrorMessage = "Length of regon should be greater than or equal to 5.")]
        [MaxLength(15, ErrorMessage = "Length of regon should be less than or equal to 15.")]
        public string Regon { get; set; }

        [Column("tax_id")]
        [XmlAttribute("tax_id")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "TaxId cannot be empty.")]
        [MinLength(5, ErrorMessage = "Length of tax id should be greater than or equal to 5.")]
        [MaxLength(15, ErrorMessage = "Length of tax id should be less than or equal to 15.")]
        public string TaxId { get; set; }
        #endregion

        [Obsolete("This constructor is only for tests, please use constructor with all variables as parameters.")]
        public CompanyInformation()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            Id = -1;
            CompanyName = "CompanyName" + rand.Next(1000);
            Regon = "Regon" + rand.Next(1000);
            TaxId = "TaxId" + rand.Next(1000);
        }

        public CompanyInformation(int id, string companyName, string regon, string taxId)
        {
            Id = id;
            CompanyName = companyName;
            Regon = regon;
            TaxId = taxId;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(CompanyName,
                new ValidationContext(this, null, null) { MemberName = "CompanyName" },
                results);
            Validator.TryValidateProperty(Regon,
                new ValidationContext(this, null, null) { MemberName = "Regon" },
                results);
            Validator.TryValidateProperty(TaxId,
                new ValidationContext(this, null, null) { MemberName = "TaxId" },
                results);
            return results;
        }
    }
}
