using FluentValidation;
using Server.Models;

namespace Server.Validators
{
    public class ProductRequestValidator : AbstractValidator<ProductRequest>
    {
        public ProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
            RuleFor(x => x.Code)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);
        }
    }
}
