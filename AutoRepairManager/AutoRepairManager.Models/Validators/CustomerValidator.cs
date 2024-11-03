using AutoRepairManager.Models.Models;
using FluentValidation;

namespace AutoRepairManager.Models.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 20).WithMessage("Username must be between 3 and 20 characters long.");

            RuleFor(customer => customer.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters long.");

            RuleFor(customer => customer.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .Length(2, 50).WithMessage("Surname must be between 2 and 50 characters long.");

            RuleFor(customer => customer.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(customer => customer.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+\d{1,3}\d{9,}$").WithMessage("Phone number must be in the format +[country_code][number].");
        }
    }
}
