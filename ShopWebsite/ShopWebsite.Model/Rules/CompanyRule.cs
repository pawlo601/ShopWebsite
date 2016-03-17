using FluentValidation;
using ShopWebsite.Model.Entities;

namespace ShopWebsite.Model.Rules
{
    public class CompanyRule : AbstractValidator<Company>
    {
        public CompanyRule()
        {
            RuleFor(p => p.CompanyName).NotEmpty().WithMessage("Company name is required.");
            RuleFor(p => p.ContactAddress).NotNull().WithMessage("Contact address is required.");
            RuleFor(p => p.ResresidentialAddress).NotNull().WithMessage("Resresidential address is required.");
            RuleFor(p => p.REGON).NotEmpty().WithMessage("REGON number is required.");
            RuleFor(p => p.TaxID).NotEmpty().WithMessage("TaxID is required.");
        }
    }
}
