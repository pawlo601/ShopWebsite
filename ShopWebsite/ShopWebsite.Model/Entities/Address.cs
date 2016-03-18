using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    [Table("ADDRESSES")]
    public class Address: IValidatableObject
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }

        [Column("STREET")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="No empty street name.")]
        [MinLength(5,ErrorMessage = "Street name lenght should be greater than 4.")]
        [MaxLength(20,ErrorMessage = "Street name lenght should be less than 21.")]
        public string Street { get; set; }

        [Column("NUMBER_OF_BUILDING")]
        [Required(AllowEmptyStrings = true)]
        [MinLength(1, ErrorMessage = "Number of building lenght should be greater than 0.")]
        [MaxLength(10, ErrorMessage = "Number of building  lenght should be less than 11.")]
        public string NumberOfBuilding { get; set; }

        [Column("CITY")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty city name.")]
        [MinLength(5, ErrorMessage = "City name lenght should be greater than 4.")]
        [MaxLength(20, ErrorMessage = "City name lenght should be less than 21.")]
        public string City { get; set; }

        [Column("POSTAL_CODE")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty postalcode.")]
        [MinLength(5, ErrorMessage = "Postal code lenght should be greater than 4.")]
        [MaxLength(10, ErrorMessage = "Postal code lenght should be less than 11.")]
        public string PostalCode { get; set; }

        [Column("COUNTRY")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty country name.")]
        [MinLength(5, ErrorMessage = "Country name lenght should be greater than 4.")]
        [MaxLength(20, ErrorMessage = "Country name lenght should be less than 21.")]
        public string Country { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Street,
                new ValidationContext(this,null,null) { MemberName = "Street" },
                results);
            Validator.TryValidateProperty(NumberOfBuilding,
                new ValidationContext(this, null, null) { MemberName = "NumberOfBuilding" },
                results);
            Validator.TryValidateProperty(City,
                new ValidationContext(this, null, null) { MemberName = "City" },
                results);
            Validator.TryValidateProperty(PostalCode,
                new ValidationContext(this, null, null) { MemberName = "PostalCode" },
                results);
            Validator.TryValidateProperty(Country,
                new ValidationContext(this, null, null) { MemberName = "Country" },
                results);
            return results;
        }
    }
}
