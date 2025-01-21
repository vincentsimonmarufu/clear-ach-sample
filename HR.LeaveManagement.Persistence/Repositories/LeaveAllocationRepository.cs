using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly HrLeaveManagementDbContext _dbContext;

    public LeaveAllocationRepository(HrLeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int queryId)
    {
        return await _dbContext.LeaveAllocations
            .Include(la => la.LeaveType)
            .FirstOrDefaultAsync(la => la.Id == queryId);
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        return await _dbContext.LeaveAllocations
            .Include(la => la.LeaveType)
            .ToListAsync();
    }
}