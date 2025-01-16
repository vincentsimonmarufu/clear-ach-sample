﻿using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Queries;

public class GetLeaveRequestListQuery : IRequest<List<LeaveRequestListDto>>
{
    
}