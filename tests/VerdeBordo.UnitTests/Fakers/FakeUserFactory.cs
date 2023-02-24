using VerdeBordo.Core.Enums;

namespace VerdeBordo.UnitTests.Fakers;

public class FakeUserFactory
{
    public static User FakeUser(bool isActive = true, Role role = Role.Admin) => 
    new Faker<User>("pt_BR")
    .RuleFor(u => u.Id, u => Guid.NewGuid())
    .RuleFor(u => u.IsActive, u => isActive)
    .RuleFor(u => u.LastUpdate, u => u.Date.Past())
    .RuleFor(u => u.FirstName, u => u.Person.FirstName)
    .RuleFor(u => u.LastName, u => u.Person.LastName)
    .RuleFor(u => u.Username, u => u.Person.UserName)
    .RuleFor(u => u.Email, u => u.Person.Email)
    .RuleFor(u => u.Password, u => u.Lorem.Paragraph())
    .RuleFor(u => u.Role, u => role);
    
}