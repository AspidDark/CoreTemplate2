using NetCoreConfiguringTemplate2.Commands;
using FluentValidation;

namespace NetCoreConfiguringTemplate2.Validation
{
    public class CreateCustomerOrderCommandValidator : AbstractValidator<CreateCustomerOrderCommand>
    {
        public CreateCustomerOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty();

            RuleFor(x => x.ProductId)
                .NotEmpty();
        }
    }
}
