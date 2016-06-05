using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.User
{
    [Table("Addresses", Schema = "User")]
    public class Address : IValidatableObject
    {
        #region variables

        [Key]
        [Column("id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("street")]
        [XmlAttribute("street")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty street name.")]
        [MinLength(5, ErrorMessage = "Street name lenght should be greater than 4.")]
        [MaxLength(20, ErrorMessage = "Street name lenght should be less than 21.")]
        public string Street { get; set; }

        [Column("number_of_building")]
        [XmlAttribute("number_of_building")] //for xml
        [Required(AllowEmptyStrings = true)]
        [MinLength(1, ErrorMessage = "Number of building lenght should be greater than 0.")]
        [MaxLength(10, ErrorMessage = "Number of building  lenght should be less than 11.")]
        public string NumberOfBuilding { get; set; }

        [Column("city")]
        [XmlAttribute("city")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty city name.")]
        [MinLength(5, ErrorMessage = "City name lenght should be greater than 4.")]
        [MaxLength(20, ErrorMessage = "City name lenght should be less than 21.")]
        public string City { get; set; }

        [Column("postal_code")]
        [XmlAttribute("postal_code")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty postalcode.")]
        [MinLength(5, ErrorMessage = "Postal code lenght should be greater than 4.")]
        [MaxLength(10, ErrorMessage = "Postal code lenght should be less than 11.")]
        public string PostalCode { get; set; }

        [Column("country")]
        [XmlAttribute("country")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty country name.")]
        [MinLength(5, ErrorMessage = "Country name lenght should be greater than 4.")]
        [MaxLength(20, ErrorMessage = "Country name lenght should be less than 21.")]
        public string Country { get; set; }

        #endregion

        #region methods
        public Address()
        {
        }

        public Address(int id, string street, string numberOfBuilding, string city, string postalCode, string country)
        {
            Id = id;
            Street = street;
            NumberOfBuilding = numberOfBuilding;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Street,
                new ValidationContext(this, null, null) { MemberName = "Street" },
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Address p = (Address)obj;
            return p.City.Equals(City) &&
                   p.Country.Equals(Country) &&
                   p.NumberOfBuilding.Equals(NumberOfBuilding) &&
                   p.PostalCode.Equals(PostalCode) &&
                   p.Street.Equals(Street);
        }

        public override int GetHashCode()
        {
            return Id;
        }
        #endregion
    }
}