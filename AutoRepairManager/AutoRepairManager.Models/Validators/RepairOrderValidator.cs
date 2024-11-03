using AutoRepairManager.Models.Models;
using FluentValidation;

namespace AutoRepairManager.Models.Validators
{
    public class RepairOrderValidator : AbstractValidator<RepairOrder>
    {
        public RepairOrderValidator()
        {
            RuleFor(order => order.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required.");

            RuleFor(order => order.CarId)
                .NotEmpty().WithMessage("Car ID is required.");

            RuleFor(order => order.ServiceTypeId)
                .NotEmpty().WithMessage("Service Type ID is required.");

            RuleFor(order => order.OrderDate)
                .NotEmpty().WithMessage("Order date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Order date cannot be in the future.");

            RuleFor(order => order.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Length(1, 50).WithMessage("Status must be between 1 and 50 characters long.");
        }
    }
}
