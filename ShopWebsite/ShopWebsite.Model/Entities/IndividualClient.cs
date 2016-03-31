using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    public class IndividualClient : Customer
    {
        [Column("NAME")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty client name.")]
        [MinLength(5, ErrorMessage = "Client name lenght should be greater than 4.")]
        [MaxLength(20, ErrorMessage = "Client name lenght should be less than 21.")]
        public string Name { get; set; }

        [Column("SURNAME")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty client surname.")]
        [MinLength(5, ErrorMessage = "Client surname lenght should be greater than 4.")]
        [MaxLength(20, ErrorMessage = "Client surname lenght should be less than 21.")]
        public string Surname { get; set; }

        [Column("BIRTHDAY")]
        [DataType(DataType.Date, ErrorMessage = "Birthday should be a date.")]
        [Required(ErrorMessage ="Birthday shouldn't be empty.")]
        public DateTime Birthday { get; set; }

        [Column("PESEL_NUMBER")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No empty pesel number.")]
        [MinLength(9, ErrorMessage = "Client pesel lenght should be greater than 8.")]
        [MaxLength(10, ErrorMessage = "Client pesel lenght should be less than 11.")]
        public string PeselNumber { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            results.AddRange(base.Validate(validationContext));
            Validator.TryValidateProperty(Name,
                new ValidationContext(this, null, null) { MemberName = "Name" },
                results);
            Validator.TryValidateProperty(Surname,
                new ValidationContext(this, null, null) { MemberName = "Surname" },
                results);
            Validator.TryValidateProperty(Birthday,
                new ValidationContext(this, null, null) { MemberName = "Birthday" },
                results);
            Validator.TryValidateProperty(PeselNumber,
                new ValidationContext(this, null, null) { MemberName = "PeselNumber" },
                results);
            if (Birthday <= new DateTime(1900,1,1))
            {
                results.Add(new ValidationResult("Birthday should be later than 1.1.1990", new[] { "Birthday" }));
            }
            if (Birthday >= new DateTime(2017,12,31))
            {
                results.Add(new ValidationResult("Birthday should be ealier than 31.12.2017", new[] { "Birthday" }));
            }
            return results;
        }
    }
}
