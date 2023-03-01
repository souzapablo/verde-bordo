namespace VerdeBordo.UnitTests.Fakers;

public class FakeOrderFactory
{
    public static Order OrderFaker(bool isActive = true, OrderStatus status = OrderStatus.Created) =>
    new Faker<Order>("pt_BR")
        .RuleFor(o => o.Id, o => Guid.NewGuid())
        .RuleFor(o => o.LastUpdate, o => o.Date.Past())
        .RuleFor(o => o.IsActive, o => isActive)
        .RuleFor(o => o.Customer, o => FakeCustomerFactory.CustomerFaker())
        .RuleFor(o => o.Embroidery, o => FakeEmbroideryFactory.EmbroideryFaker())
        .RuleFor(o => o.Shipment, o => o.Random.Decimal(1, 100))
        .RuleFor(o => o.Status, o => status);
}