﻿using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Queries;

public class GetLeaveAllocationDetailQuery : IRequest<LeaveAllocationDto>
{
    public int Id { get; set; }
}