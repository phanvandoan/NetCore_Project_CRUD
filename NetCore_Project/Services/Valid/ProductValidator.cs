using FluentValidation;
using NetCore_Project.Models;

namespace NetCore_Project.Services.Valid
{
    public class ProductFieldValidator : AbstractValidator<Product>
    {
        public ProductFieldValidator()
        {
            RuleFor(c => c.ProductNo)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters.");
            RuleFor(c => c.ProductName)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters.");
            RuleFor(c => c.Unit)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters.");
            //RuleFor(c => c.Email)
            //    .NotEmpty().WithMessage("Email is required.")
            //    .EmailAddress().WithMessage("Invalid email address.");
        }

    }
}
