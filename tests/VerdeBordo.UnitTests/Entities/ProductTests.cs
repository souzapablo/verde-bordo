namespace VerdeBordo.UnitTests.Entities;

public class ProductTests
{
    [Fact(DisplayName = "Given a valid new Price should update Price")]
    public void GivenAValidNewPriceUpdatePriceShouldUpateProduct()
    {
        // Arrange
        var sut = FakeProductFactory.ProductFaker();
        var initialDate = sut.LastUpdate;

        // Act
        sut.UpdatePrice(22_972);

        // Assert
        sut.Price.Should().Be(22_972);
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }
}