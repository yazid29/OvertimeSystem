using API.DTOs.Employees;
using API.DTOs.Overtimes;
using FluentValidation;

namespace API.Utilities.Validations.Employees
{
    public class OvertimeRequestValidator : AbstractValidator<OvertimeRequestDto>
    {
        public OvertimeRequestValidator()
        {
            RuleFor(e => e.Reason)
            .NotEmpty().WithMessage("Reason is required");
            RuleFor(e => e.TotalHours)
            .NotEmpty().WithMessage("TotalHours is required")
            .LessThanOrEqualTo(9).WithMessage("should not be more than 9 hours");
        }
    }
}
