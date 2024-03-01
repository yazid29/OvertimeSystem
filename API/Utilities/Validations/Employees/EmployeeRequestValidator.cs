using API.DTOs.Employees;
using FluentValidation;

namespace API.Utilities.Validations.Employees
{
    public class EmployeeRequestValidator : AbstractValidator<EmployeeRequestDto>
    {
        public EmployeeRequestValidator()
        {
            RuleFor(e => e.FirstName)
            .NotEmpty().WithMessage("First Name is required");
            RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(e => e.Salary)
            .NotEmpty().WithMessage("Salary is required");
            RuleFor(e => e.Position)
            .NotEmpty().WithMessage("Position is required");
            RuleFor(e => e.Department)
            .NotEmpty().WithMessage("Department is required");
            RuleFor(e => e.ManagerId)
            .NotEmpty().WithMessage("ManagerId is required");

        }
    }
}
