using FluentValidation;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.Models;

namespace NetCore_Project.Services.Valid
{
    public class InvoiceFieldValidator : AbstractValidator<CreateUpdateInvoiceDto>
    {
        public InvoiceFieldValidator()
        {
            RuleFor(c => c.InvoiceNo)
                .NotEmpty().WithMessage("InvoiceNo is required.")
                .MaximumLength(250).WithMessage("InvoiceNo cannot exceed 250 characters.");
            RuleFor(c => c.InvoiceDate)
                .Must(BeValidDateTime)
                .WithMessage("InvoiceDate is not a valid date.");
            RuleFor(c => c.PaymentMethod)
                .NotEmpty().WithMessage("PaymentMethod is required.")
                .MaximumLength(250).WithMessage("PaymentMethod cannot exceed 250 characters.");
            RuleFor(c => c.Vat)
                .NotEmpty().WithMessage("Vat is required.")
                .MaximumLength(10).WithMessage("Vat cannot exceed 10 characters.");
            //RuleFor(c => c.Email)
            //    .NotEmpty().WithMessage("Email is required.")
            //    .EmailAddress().WithMessage("Invalid email address.");
            RuleForEach(invoice => invoice.InvoiceDetails)
                .SetValidator(new InvoiceDetailFieldValidator());
        }
        private bool BeValidDateTime(DateTime? invoiceDate)
        {
            return invoiceDate <= DateTime.Now;
        }
    }
    public class InvoiceDetailFieldValidator : AbstractValidator<InvoiceDetail>
    {
        public InvoiceDetailFieldValidator()
        {
            RuleFor(c => c.InvoiceDetailsNo)
                .NotEmpty().WithMessage("InvoiceDetailsNo is required.")
                .MaximumLength(250).WithMessage("InvoiceDetailsNo cannot exceed 250 characters.");
            RuleFor(c => c.SequenceNo)
                .NotEmpty().WithMessage("SequenceNo is required.")
                .MaximumLength(250).WithMessage("SequenceNo cannot exceed 250 characters.");
            RuleFor(p => p.Quantity)
                .Must(BeValidDecimal)
                .WithMessage("Quantity is not valid.");
            RuleFor(p => p.UnitPrice)
                .Must(BeValidDecimal)
                .WithMessage("UnitPrice is not valid.");
        }
        private bool BeValidDecimal(decimal? value)
        {
            return value >= 0; // Giá trị phải lớn hơn hoặc bằng 0
        }
    }
}
