using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;

public class CreateLeaveAllocationCommand : IRequest<int>
{
    public required CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; }
}