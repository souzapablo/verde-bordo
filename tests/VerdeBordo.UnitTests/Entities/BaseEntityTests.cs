namespace VerdeBordo.UnitTests.Entities;

public class BaseEntityTests
{
    [Theory(DisplayName = "Toggle IsActive property changes the status")]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenAnyValidEntityWhenToggleActiveStatusIsCalledShouldChangeActiveStatusToOpposite(bool isActive)
    {
        // Arrange
        var supplier = FakeSupplierFactory.SupplierFaker(isActive);
        var initialDate = supplier.LastUpdate;

        // Act
        supplier.Delete();

        // Assert
        supplier.IsActive.Should().NotBe(isActive);
        initialDate.Should().NotBeSameDateAs(supplier.LastUpdate);
    }
}
