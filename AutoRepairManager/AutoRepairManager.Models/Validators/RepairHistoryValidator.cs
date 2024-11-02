using FluentValidation;

namespace AutoRepairManager.Models.Validators
{
    public class RepairHistoryValidator : AbstractValidator<RepairHistory>
    {
        public RepairHistoryValidator()
        {
            RuleFor(repairHistory => repairHistory.CarId)
                .NotEmpty().WithMessage("Car ID is required.");

            RuleFor(repairHistory => repairHistory.RepairDate)
                .NotEmpty().WithMessage("Repair date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Repair date cannot be in the future.");

            RuleFor(repairHistory => repairHistory.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(5, 250).WithMessage("Description must be between 5 and 250 characters long.");

            RuleFor(repairHistory => repairHistory.Cost)
                .GreaterThan(0).WithMessage("Cost must be greater than zero.");
        }
    }
}
