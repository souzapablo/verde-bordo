namespace VerdeBordo.Core.Entities;

public class Supplier : BaseEntity
{
    public Supplier() { }

    public Supplier(Guid userId, string name)
    {
        UserId = userId;
        Name = name;

        Products = new List<Product>();
    }

    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public string Name { get; private set; }
    public List<Product> Products { get; private set; }

    public void UpdateName(string newName)
    {
        Name = newName;
        Update();
    }
}
