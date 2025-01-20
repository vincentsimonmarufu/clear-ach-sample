using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;

public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        
        RuleFor(p => p.NumberOfDays)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

        RuleFor(p => p.Period)
            .GreaterThanOrEqualTo(DateTime.Now.Year)
            .WithMessage("{PropertyName} must be after or equal to the current year");

        RuleFor(p => p.LeaveTypeId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
            .MustAsync(async (id, token) =>
            {
                var leaveTypeExists = await _leaveTypeRepository.ExistsAsync(id);
                return !leaveTypeExists;
            });
    }
}