namespace VerdeBordo.UnitTests.Fakers;

public class FakeProductFactory
{
    public static Product ProductFaker(bool isActive = true) =>
        new Faker<Product>("pt_BR")
        .RuleFor(s => s.Id, s => Guid.NewGuid())
        .RuleFor(s => s.Description, s => s.Commerce.Product())
        .RuleFor(p => p.Price, p => p.Finance.Amount(1, 100,2))
        .RuleFor(s => s.IsActive, s => isActive)
        .RuleFor(s => s.LastUpdate, s => s.Date.Past())
        .Generate();
}
