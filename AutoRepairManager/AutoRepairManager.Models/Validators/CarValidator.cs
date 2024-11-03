using AutoRepairManager.Models.Models;
using FluentValidation;

namespace AutoRepairManager.Models.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.Make)
                .NotEmpty().WithMessage("Make is required.")
                .Length(2, 50).WithMessage("Make must be between 2 and 50 characters long.");

            RuleFor(car => car.Model)
                .NotEmpty().WithMessage("Model is required.")
                .Length(2, 50).WithMessage("Model must be between 2 and 50 characters long.");

            RuleFor(car => car.LicensePlate)
                .NotEmpty().WithMessage("License Plate is required.")
                .Length(1, 15).WithMessage("License Plate must be between 1 and 15 characters long.");

            RuleFor(car => car.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required.");
        }
    }
}
