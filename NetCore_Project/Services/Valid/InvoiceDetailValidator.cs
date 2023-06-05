using FluentValidation;
using NetCore_Project.Models;

namespace NetCore_Project.Services.Valid
{
    //public class InvoiceDetailFieldValidator : AbstractValidator<InvoiceDetail>
    //{
    //    public InvoiceDetailFieldValidator()
    //    {
    //        RuleFor(c => c.InvoiceDetailsNo)
    //            .NotEmpty().WithMessage("InvoiceDetailsNo is required.")
    //            .MaximumLength(250).WithMessage("InvoiceDetailsNo cannot exceed 250 characters.");
    //        RuleFor(c => c.SequenceNo)
    //            .NotEmpty().WithMessage("SequenceNo is required.")
    //            .MaximumLength(250).WithMessage("SequenceNo cannot exceed 250 characters.");
    //        RuleFor(p => p.Quantity)
    //            .Must(BeValidDecimal)
    //            .WithMessage("Quantity is not valid.");
    //        RuleFor(p => p.UnitPrice)
    //            .Must(BeValidDecimal)
    //            .WithMessage("UnitPrice is not valid.");
    //    }
    //    private bool BeValidDecimal(decimal? price)
    //    {
    //        return price > 0;
    //    }
    //}
}
