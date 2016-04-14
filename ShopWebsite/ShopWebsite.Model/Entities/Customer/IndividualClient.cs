using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities.Customer
{
    public class IndividualClient : Customer
    {
        public PersonalInformation Information { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            results.AddRange(base.Validate(validationContext));
            return results;
        }
    }
}
