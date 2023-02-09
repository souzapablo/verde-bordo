namespace VerdeBordo.UnitTests.Fakers
{
    public class FakeSupplierFactory
    {
        public static Supplier FakeSupplier(bool isActive) =>
            new Faker<Supplier>("pt_BR")
            .RuleFor(s => s.Id, s => Guid.NewGuid())
            .RuleFor(s => s.Name, s => s.Company.CompanyName())
            .RuleFor(s => s.IsActive, s => isActive)
            .RuleFor(s => s.LastUpdate, s =>  s.Date.Past())
            .Generate();

    }
    
}
