using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Requests.Queries;

public class GetLeaveTypeDetailQuery : IRequest<LeaveTypeDto>
{
    public int Id { get; set; }
}