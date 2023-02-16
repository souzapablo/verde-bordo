namespace VerdeBordo.UnitTests.Fakers;

public class FakeCustomerFactory
{
    public static Customer FakeCustomer(bool isActive = true) =>
    new Faker<Customer>("pt_BR")
    .RuleFor(s => s.Id, s => Guid.NewGuid())
    .RuleFor(s => s.Name, s => s.Person.FirstName)
    .RuleFor(s => s.Contact, s => s.Person.Phone)
    .RuleFor(s => s.IsActive, s => isActive)
    .RuleFor(s => s.LastUpdate, s => s.Date.Past())
    .Generate();
}
