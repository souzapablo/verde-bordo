namespace VerdeBordo.UnitTests.Entities;

public class PurchaseTests
{
    [Fact(DisplayName = "Given a new PurchasedAmount should update PurchasedAmount")]
    public void GivenANewPurchasedAmountWhenUpdateIsCalledShouldUpdatePurchasedAmount()
    {
        // Arrange
        var newPurchasedAmount = 101;
        var purchase = FakePurchaseFactory.FakePurchase();
        var firstDate = purchase.LastUpdate;

        // Act
        purchase.UpdatePurchasedAmount(newPurchasedAmount);

        // Assert
        purchase.PurchasedAmount.Should().Be(newPurchasedAmount);
        purchase.LastUpdate.Should().NotBeSameDateAs(firstDate);
    }

    [Fact(DisplayName = "Given a new Shipment should update Shipment")]
    public void GivenANewShipmentWhenUpdateIsCalledShouldUpdateShipment()
    {
        // Arrange
        var newShipment = 101;
        var purchase = FakePurchaseFactory.FakePurchase();
        var firstDate = purchase.LastUpdate;

        // Act
        purchase.UpdateShipment(newShipment);

        // Assert
        purchase.Shipment.Should().Be(newShipment);
        purchase.LastUpdate.Should().NotBeSameDateAs(firstDate);
    }

    [Fact(DisplayName = "Given a new PurchaseDate should update PurchaseDate")]
    public void GivenANewPurchaseDateWhenUpdateIsCalledShouldUpdatePurchaseDate()
    {
        // Arrange
        var newPurchaseDate = DateTime.Now;
        var purchase = FakePurchaseFactory.FakePurchase();
        var firstDate = purchase.LastUpdate;

        // Act
        purchase.UpdatePurchaseDate(newPurchaseDate);

        // Assert
        purchase.PurchaseDate.Should().Be(newPurchaseDate);
        purchase.LastUpdate.Should().NotBeSameDateAs(firstDate);
    }
}
