using FluentValidation;
using ShopWebsite.Model.Entities;

namespace ShopWebsite.Model.Rules
{
    public class IndividualClientRule : AbstractValidator<IndividualClient>
    {
        public IndividualClientRule()
        {
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Surname is required.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(p => p.ContactAddress).NotNull().WithMessage("Contact address is required.");
            RuleFor(p => p.ResresidentialAddress).NotNull().WithMessage("Resresidential address is required.");
            RuleFor(p => p.PeselNumber).NotEmpty().WithMessage("PESEL number is required.");
        }
    }
}
