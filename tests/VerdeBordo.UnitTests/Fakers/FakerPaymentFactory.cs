namespace VerdeBordo.UnitTests.Fakers;

public class FakerPaymentFactory
{
    public static Payment PaymentFaker(bool isActive = true, bool hasPaid = false) =>
        new Faker<Payment>("pt_BR")
        .RuleFor(p => p.Id, p => Guid.NewGuid())
        .RuleFor(p => p.IsActive, p => isActive)
        .RuleFor(p => p.LastUpdate, p => p.Date.Past())
        .RuleFor(p => p.Order, p => new Order())
        .RuleFor(p => p.DueDate, p => p.Date.Future())
        .RuleFor(p => p.Amount, p => p.Random.Decimal(0, 100))
        .RuleFor(p => p.HasPaid, p => hasPaid);
}