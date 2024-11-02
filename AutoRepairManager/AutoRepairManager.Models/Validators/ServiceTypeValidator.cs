using FluentValidation;

namespace AutoRepairManager.Models.Validators
{
    public class ServiceTypeValidator : AbstractValidator<ServiceType>
    {
        public ServiceTypeValidator()
        {
            RuleFor(serviceType => serviceType.Name)
                .NotEmpty().WithMessage("Service Type Name is required.")
                .Length(1, 100).WithMessage("Service Type Name must be between 1 and 100 characters long.");

            RuleFor(serviceType => serviceType.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }
}
