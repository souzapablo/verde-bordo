namespace VerdeBordo.Core.Entities;

public class Supplier : BaseEntity
{
    public Supplier() { }

    public Supplier(string name)
    {
        Name = name;

        Products = new List<Product>();
    }

    public string Name { get; private set; }
    public List<Product> Products { get; private set; }

    public void UpdateName(string newName)
    {
        Name = newName;
        Update();
    }
}
