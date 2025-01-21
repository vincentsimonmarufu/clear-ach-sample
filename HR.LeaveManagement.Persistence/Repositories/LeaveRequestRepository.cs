using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly HrLeaveManagementDbContext _dbContext;

    public LeaveRequestRepository(HrLeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int queryId)
    {
        return await _dbContext.LeaveRequests
            .Include(lr => lr.LeaveType)
            .FirstOrDefaultAsync(lr => lr.Id == queryId);
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        return await _dbContext.LeaveRequests
            .Include(lr => lr.LeaveType)
            .ToListAsync();
    }

    public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approved)
    {
        leaveRequest.Approved = approved;
        _dbContext.Entry(leaveRequest).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}