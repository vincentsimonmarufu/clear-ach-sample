using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistence.Configurations.Entities;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasData(
            new LeaveType { Id = 1, DefaultDays = 22, Name = "Vacation Leave" },
            new LeaveType { Id = 2, DefaultDays = 12, Name = "Sick Leave" },
            new LeaveType { Id = 3, DefaultDays = 12, Name = "Study Leave" }
        );
    }
}