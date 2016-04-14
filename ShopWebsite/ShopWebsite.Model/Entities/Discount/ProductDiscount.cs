using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Model.Entities.Discount
{
    public class ProductDiscount : IValidatableObject
    {
        public int Id { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
