using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Queries;

public class GetLeaveRequestDetailQuery : IRequest<LeaveRequestDto>
{
    public int Id { get; set; }
}