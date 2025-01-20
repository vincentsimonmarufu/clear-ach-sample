using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators;

public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
{
    public UpdateLeaveTypeDtoValidator()
    {
        Include(new ILeaveTypeDtoValidator());
        RuleFor(p => p.Id)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
    }
}