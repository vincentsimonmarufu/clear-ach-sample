using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeValidator : AbstractValidator<CreateLeaveTypeDto>
{
        public CreateLeaveTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
    
            RuleFor(x => x.DefaultDays)
                .GreaterThan(0).WithMessage("Default days must be greater than 0.")
                .LessThan(100).WithMessage("Default days must be less than 100.");
        }
    }
}