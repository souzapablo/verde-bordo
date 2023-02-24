using VerdeBordo.Core.Enums;

namespace VerdeBordo.Core.Entities;

public class User : BaseEntity
{
    public User(string firstName, string lastName, string username, string email, string password, Role role)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        Password = password;
        Role = role;

        Customers = new();
        Suppliers = new();
        Purchases = new();
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Role Role { get; private set; }
    public List<Customer> Customers { get; private set; }
    public List<Supplier> Suppliers { get; private set; }
    public List<Purchase> Purchases { get; private set; }
}