namespace HR.LeaveManagement.Domain.Common;

public class BaseDomainEntity
{
    // Primary key for the entity
    public int Id { get; set; }

    // Audit fields
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; } = string.Empty;
    
    // Soft-delete functionality
    public bool IsDeleted { get; set; }
}