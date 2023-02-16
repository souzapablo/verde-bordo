namespace VerdeBordo.Core.Entities;

public class Customer : BaseEntity
{
    public Customer(string name, string contact)
    {
        Name = name;
        Contact = contact;
    }

    public string Name { get; private set; }
    public string Contact { get; set; }
}
