namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;

using FluentValidation;

public class CreateLeaveRequestValidator : AbstractValidator<CreateLeaveRequestDto>
{
    public CreateLeaveRequestValidator()
{
        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start date is required.")
            .LessThan(x => x.EndDate).WithMessage("Start date must be before end date.");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("End date is required.")
            .GreaterThan(x => x.StartDate).WithMessage("End date must be after start date.");
    
        RuleFor(x => x.LeaveTypeId)
            .NotEmpty().WithMessage("Leave type is required.")
            .GreaterThan(0).WithMessage("Leave type must be a positive number.");

        RuleFor(x => x.RequestedComments)
            .MaximumLength(250).WithMessage("Request comments must not exceed 250 characters.");
    }
}