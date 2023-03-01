namespace VerdeBordo.UnitTests.Fakers;

public class FakeEmbroideryFactory
{
    public static Embroidery EmbroideryFaker(bool isActive = true) =>
    new Faker<Embroidery>("pt_BR")
        .RuleFor(e => e.Id, e => Guid.NewGuid())
        .RuleFor(e => e.LastUpdate, e => e.Date.Past())
        .RuleFor(e => e.IsActive, e => isActive)
        .RuleFor(e => e.Description, e => e.Lorem.Sentence())
        .RuleFor(e => e.Details, e => e.PickRandom<EmbroideryDetails>())
        .RuleFor(e => e.Size, e => e.PickRandom<EmbroiderySize>())
        .RuleFor(e => e.Price, e => e.Random.Decimal(1, 100))
        .RuleFor(e => e.HasFrame, e => e.Random.Bool());
}