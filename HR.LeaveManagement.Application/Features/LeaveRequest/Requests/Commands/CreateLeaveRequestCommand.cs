using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands;

public class CreateLeaveRequestCommand : IRequest<int>
{
    public required CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }
}