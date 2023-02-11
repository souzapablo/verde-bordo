namespace VerdeBordo.UnitTests.Fakers;

public class FakePurchaseFactory
{
    public static Purchase FakePurchase(bool isActive = true) =>
        new Faker<Purchase>("pt_BR")
        .RuleFor(s => s.Id, s => Guid.NewGuid())
        .RuleFor(p => p.Product, p => FakeProductFactory.FakeProduct())
        .RuleFor(p => p.PurchasedAmount, p => p.Random.Decimal(0, 100))
        .RuleFor(p => p.Shipment, p => p.Random.Decimal(0, 100))
        .RuleFor(s => s.IsActive, s => isActive)
        .RuleFor(s => s.LastUpdate, s => s.Date.Past())
        .RuleFor(s => s.PurchaseDate, s => s.Date.Past())
        .Generate();
}
