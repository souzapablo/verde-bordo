﻿namespace VerdeBordo.UnitTests.Entities;

public class PurchaseTests
{
    [Fact(DisplayName = "Given only a new PurchasedAmount UpdatePurchase should update only PurchasedAmount")]
    public void GivenANewPurchasedAmountWhenUpdateIsCalledShouldUpdatePurchasedAmount()
    {
        // Arrange
        var purchase = GetFakePurchase();
        var intialDate = purchase.LastUpdate;

        // Act
        purchase.UpdatePurchase(101_1, null, null);

        // Assert
        purchase.PurchasedAmount.Should().Be(101_1);
        purchase.Shipment.Should().Be(purchase.Shipment);
        purchase.PurchaseDate.Should().BeSameDateAs(purchase.PurchaseDate);
        purchase.LastUpdate.Should().NotBeSameDateAs(intialDate);
    }

    [Fact(DisplayName = "Given only a new Shipment UpdatePurchase should update only Shipment")]
    public void GivenANewShipmentWhenUpdateIsCalledShouldUpdateShipment()
    {
        // Arrange
        var newShipment = 101_0;
        var purchase = GetFakePurchase();
        var initialDate = purchase.LastUpdate;

        // Act
        purchase.UpdatePurchase(null, newShipment, null);

        // Assert
        purchase.PurchasedAmount.Should().Be(purchase.PurchasedAmount);
        purchase.Shipment.Should().Be(101_0);
        purchase.PurchaseDate.Should().BeSameDateAs(purchase.PurchaseDate);
        purchase.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }

    [Fact(DisplayName = "Given only a null new Shipment UpdatePurchase should update only Shipment")]
    public void GivenANullNewShipmentWhenUpdateIsCalledShouldUpdateShipment()
    {
        // Arrange
        var purchase = GetFakePurchase();
        var initialDate = purchase.LastUpdate;

        // Act
        purchase.UpdatePurchase(null, null, null);

        // Assert
        purchase.PurchasedAmount.Should().Be(purchase.PurchasedAmount);
        purchase.Shipment.Should().BeNull();
        purchase.PurchaseDate.Should().BeSameDateAs(purchase.PurchaseDate);
        purchase.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }

    [Fact(DisplayName = "Given only a new PurchaseDate UpdatePurchase should update only PurchaseDate")]
    public void GivenANewPurchaseDateWhenUpdateIsCalledShouldUpdatePurchaseDate()
    {
        // Arrange
        var newPurchaseDate = DateTime.Now;
        var purchase = GetFakePurchase();
        var initialDate = purchase.LastUpdate;

        // Act
        purchase.UpdatePurchase(null, null, newPurchaseDate);

        // Assert
        purchase.PurchasedAmount.Should().Be(purchase.PurchasedAmount);
        purchase.Shipment.Should().Be(purchase.Shipment);
        purchase.PurchaseDate.Should().NotBeSameDateAs(initialDate);
        purchase.PurchaseDate.Should().Be(newPurchaseDate);
        purchase.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }

    private static Purchase GetFakePurchase(bool isActive = true) =>  FakePurchaseFactory.PurchaseFaker(isActive);
}
