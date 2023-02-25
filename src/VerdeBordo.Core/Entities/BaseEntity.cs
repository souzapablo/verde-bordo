namespace VerdeBordo.Core.Entities;

public abstract class BaseEntity
{
    protected BaseEntity() { }

    public Guid Id { get; private set; }
    public bool IsActive { get; private set; } = true;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime LastUpdate { get; private set; } = DateTime.UtcNow;

    public void Delete() 
    {
        IsActive = !IsActive;
        Update();
    }

    protected void Update() => LastUpdate = DateTime.Now;
}
