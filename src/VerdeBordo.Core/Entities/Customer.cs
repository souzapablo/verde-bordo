namespace VerdeBordo.Core.Entities;

public class Customer : BaseEntity
{
    public Customer() { }

    public Customer(Guid userId, string name, string contact)
    {
        UserId = userId;
        Name = name;
        Contact = contact;
    }

    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public string Name { get; private set; }
    public string Contact { get; set; }

    public void UpdateContact(string newContact)
    {
        Contact = newContact;
        Update();
    }
}
