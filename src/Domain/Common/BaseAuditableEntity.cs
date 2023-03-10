namespace ProjectTemplate.Domain;

public interface IBaseAuditableEntity
{
    DateTime createdOn { get; set; }
    string? createdBy { get; set; }
    DateTime? lastModifiedOn { get; set; }
    string? lastModifiedBy { get; set; }
}

public abstract class BaseAuditableEntity<T> : BaseEntity<T>, IBaseAuditableEntity
{
    public DateTime createdOn { get; set; }
    public string? createdBy { get; set; }
    public DateTime? lastModifiedOn { get; set; }
    public string? lastModifiedBy { get; set; }
}
