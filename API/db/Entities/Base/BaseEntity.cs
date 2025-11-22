namespace API.db.Entities.Base;

public class BaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime LastModifiedOn { get; set; }
}
