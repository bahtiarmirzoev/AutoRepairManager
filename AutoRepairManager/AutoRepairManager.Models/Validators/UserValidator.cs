using AutoRepairManager.Models.Models;
using FluentValidation;

namespace AutoRepairManager.Models.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 20).WithMessage("Username must be between 3 and 20 characters long.");

            RuleFor(user => user.PasswordHash)
                .NotEmpty().WithMessage("Password is required.")
                .Length(6, 100).WithMessage("Password must be at least 6 characters long.");

            RuleFor(user => user.Role)
                .IsInEnum().WithMessage("Role must be a valid UserRole value.");
        }
    }
}
