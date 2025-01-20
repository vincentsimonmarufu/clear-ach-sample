using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using ValidationException = HR.LeaveManagement.Application.Exceptions.ValidationException;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }

        var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request.CreateLeaveAllocationDto);
        leaveAllocation = await _leaveAllocationRepository.AddAsync(leaveAllocation);
        return leaveAllocation.Id;
    }
}