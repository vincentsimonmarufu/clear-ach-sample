using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Requests.Commands;

public class CreateLeaveTypeCommand : IRequest<int>
{
    public required CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }
}