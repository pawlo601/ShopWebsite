using FluentValidation;
using ShopWebsite.Model.Entities;

namespace ShopWebsite.Model.Rules
{
    public class ProductRules : AbstractValidator<Product>
    {
        public ProductRules()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Product name is required.");
            RuleFor(p => p.PricePerUnit).GreaterThanOrEqualTo(0).WithMessage("Price has to be greater or equal 0.");
            RuleFor(p => p.QuantityPerUnit).GreaterThanOrEqualTo(0).WithMessage("Quantity has to be greater or equal 0.");
        }
    }
}
