using FluentValidation;
using NetCore_Project.Models;

namespace NetCore_Project.Services.Valid
{
    public class CustomerFieldValidator : AbstractValidator<Customer>
    {
        public CustomerFieldValidator()
        {
            RuleFor(c => c.CustomerNo)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters.");
            RuleFor(c => c.CustomerFirstName)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters.");
            RuleFor(c => c.CustomerLastName)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters.");
            RuleFor(c => c.CustomerCompany)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters.");
            RuleFor(c => c.CustomerAddress)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters.");
            RuleFor(c => c.CustomerDistrict)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters.");
            RuleFor(c => c.CustomerCity)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters.");
            RuleFor(c => c.CustomerTaxNo)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters.");
            //RuleFor(c => c.Email)
            //    .NotEmpty().WithMessage("Email is required.")
            //    .EmailAddress().WithMessage("Invalid email address.");
        }

    }
}
