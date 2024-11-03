using AutoRepairManager.Models.Models;
using FluentValidation;

namespace AutoRepairManager.Models.Validators
{
    public class InvoiceValidator : AbstractValidator<Invoice>
    {
        public InvoiceValidator()
        {
            RuleFor(invoice => invoice.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required.");

            RuleFor(invoice => invoice.RepairOrderId)
                .NotEmpty().WithMessage("Repair Order ID is required.");

            RuleFor(invoice => invoice.InvoiceDate)
                .NotEmpty().WithMessage("Invoice date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Invoice date cannot be in the future.");

            RuleFor(invoice => invoice.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");

            RuleFor(invoice => invoice.InvoiceStatus)
                .NotEmpty().WithMessage("Invoice status is required.")
                .Length(2, 50).WithMessage("Invoice status must be between 2 and 50 characters long.");
        }
    }
}
