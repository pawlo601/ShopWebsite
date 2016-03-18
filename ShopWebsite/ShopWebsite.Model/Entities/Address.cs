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
        [Required]
        public string Street { get; set; }
        [Column("NUMBER_OF_BUILDING")]
        public string NumberOfBuilding { get; set; }
        [Column("CITY")]
        public string City { get; set; }
        [Column("POSTAL_CODE")]
        public string PostalCode { get; set; }
        [Column("COUNTRY")]
        public string Country { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            throw new NotImplementedException();
        }
    }
}
