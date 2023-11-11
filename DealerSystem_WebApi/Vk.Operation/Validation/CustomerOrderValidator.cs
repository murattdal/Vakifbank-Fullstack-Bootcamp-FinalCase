using FluentValidation;
using SchemaLayer;

namespace OperationLayer.Validation;

public class CreateCustomerOrderValidator : AbstractValidator<CustomerOrderRequest>
{
    public CreateCustomerOrderValidator()
    {

        RuleFor(x => x.OrderStatus)
            .NotEmpty().WithMessage("OrderStatus is required.")
            .Must(x => x == "Waiting" || x == "Processing" || x == "Completed")
            .WithMessage("OrderStatus must be 'Waiting', 'Processing', or 'Completed'.")
            .MinimumLength(1).WithMessage("OrderStatus length min value is 1.");

        RuleFor(x => x.OrderPaymentMethod)
            .NotEmpty().WithMessage("OrderPaymentMethod is required.")
            .MinimumLength(1).WithMessage("OrderPaymentMethod length min value is 1.");

        RuleFor(x => x.OrderAmount)
            .NotEmpty().WithMessage("OrderAmount is required.")
            .GreaterThan(0).WithMessage("OrderAmount must be greater than 0.");   
    }
}
