using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Model.Entities.Discount
{
    public class OrderDiscount : SomeDiscount
    {
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            results.AddRange(base.Validate(validationContext));
            if (Discount != null)
            {
                if (Discount.IsForProduct)
                {
                    results.Add(new ValidationResult("This discount is not for order.", new[] { "Discount" }));
                }
            }
            return results;
        }
    }
}
