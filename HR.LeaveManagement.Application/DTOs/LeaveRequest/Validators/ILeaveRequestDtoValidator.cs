using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;

public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start date is required.")
            .LessThan(x => x.EndDate).WithMessage("Start date must be before end date.");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("End date is required.")
            .GreaterThan(x => x.StartDate).WithMessage("End date must be after start date.");

        RuleFor(x => x.LeaveTypeId)
            .NotEmpty().WithMessage("Leave type is required.")
            .GreaterThan(0).WithMessage("Leave type must be a positive number.")
            .MustAsync(async (leaveTypeId, cancellation) =>
            {
                var leaveTypeExists = await _leaveTypeRepository.ExistsAsync(leaveTypeId);
                return !leaveTypeExists;
            }).WithMessage("Leave type must be valid.");
    }
}