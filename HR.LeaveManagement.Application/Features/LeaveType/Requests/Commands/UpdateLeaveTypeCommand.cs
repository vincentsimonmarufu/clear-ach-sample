using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Requests.Commands;

public class UpdateLeaveTypeCommand : IRequest<Unit>
{
    public required LeaveTypeDto LeaveTypeDto { get; set; }
}