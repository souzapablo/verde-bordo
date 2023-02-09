namespace VerdeBordo.UnitTests.Entities
{
    public class BaseEntityTests
    {
        [Theory(DisplayName = "Toggle IsActive property changes the status")]
        [InlineData(true)]
        [InlineData(false)]
        public void GivenAnyValidEntityWhenToggleActiveStatusIsCalledShouldChangeActiveStatusToOpposite(bool isActive)
        {
            // Arrange
            var supplier = FakeSupplierFactory.FakeSupplier(isActive);
            var initialDate = supplier.LastUpdate;

            // Act
            supplier.ToggleActiveStatus();

            // Assert
            supplier.IsActive.Should().NotBe(isActive);
            initialDate.Should().NotBeSameDateAs(supplier.LastUpdate);
        }
    }
}
