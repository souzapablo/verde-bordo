using VerdeBordo.Application.Features.Purchases.Commands.UpdatePurchase;

namespace VerdeBordo.UnitTests.Features.Purchases.Commands;

public class UpdatePurchaseCommandHandlerTests
{
    private readonly Mock<IPurchaseRepository> _purchaseRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid purchase should throw exception")]
    public async Task GivenAnInvalidPurchaseWhenCommandIsExecutedShouldThrowExcepton()
    {
        // Arrange
        var command = new UpdatePurchaseCommand(Guid.NewGuid(), null, null, null);
        var sut = GenerateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Purchase not found");
    }

    [Fact(DisplayName = "Given only a new PurchasedAmount should update only PurchasedAmount")]
    public async Task GivenOnlyANewPurchasedAmountWhenCommandIsExecutedShouldUpdateOnlyPurchasedAmount()
    {
        // Arrange
        var purchase = FakePurchaseFactory.FakePurchase(); 
        var initialDate = purchase.LastUpdate;
        var command = new UpdatePurchaseCommand(purchase.Id, 101_0, null, null);
        var sut = GenerateCommandHandler();

        SetupGetById(purchase);

        // Act
        await sut.Handle(command, new CancellationToken());

        // Assert
        purchase.PurchasedAmount.Should().Be(101_0);
        purchase.Shipment.Should().Be(purchase.Shipment);
        purchase.PurchaseDate.Should().Be(purchase.PurchaseDate);
        purchase.LastUpdate.Should().NotBeSameDateAs(initialDate);
        _purchaseRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Purchase>()), Times.Once);
    }

    [Fact(DisplayName = "Given only a new Shipment should update only Shipment")]
    public async Task GivenOnlyANewShipmentWhenCommandIsExecutedShouldUpdateOnlyShipment()
    {
        // Arrange
        var purchase = FakePurchaseFactory.FakePurchase();
        var initialDate = purchase.LastUpdate;
        var command = new UpdatePurchaseCommand(purchase.Id, null, 101_0, null);
        var sut = GenerateCommandHandler();

        SetupGetById(purchase);

        // Act
        await sut.Handle(command, new CancellationToken());

        // Assert
        purchase.PurchasedAmount.Should().Be(purchase.PurchasedAmount);
        purchase.Shipment.Should().Be(101_0);
        purchase.PurchaseDate.Should().Be(purchase.PurchaseDate);
        purchase.LastUpdate.Should().NotBeSameDateAs(initialDate);
        _purchaseRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Purchase>()), Times.Once);
    }

    [Fact(DisplayName = "Given only a new PurchaseDate should update only PurchaseDate")]
    public async Task GivenOnlyANewPurchaseDatetWhenCommandIsExecutedShouldUpdateOnlyPurchaseDate()
    {
        // Arrange
        var newPurchaseDate = new DateTime(2022, 1, 2);
        var purchase = FakePurchaseFactory.FakePurchase();
        var initialDate = purchase.LastUpdate;
        var command = new UpdatePurchaseCommand(purchase.Id, null, null, newPurchaseDate);
        var sut = GenerateCommandHandler();

        SetupGetById(purchase);

        // Act
        await sut.Handle(command, new CancellationToken());

        // Assert
        purchase.PurchasedAmount.Should().Be(purchase.PurchasedAmount);
        purchase.Shipment.Should().Be(purchase.Shipment);
        purchase.PurchaseDate.Should().Be(newPurchaseDate);
        purchase.LastUpdate.Should().NotBeSameDateAs(initialDate);
        _purchaseRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Purchase>()), Times.Once);
    }

    private UpdatePurchaseCommandHandler GenerateCommandHandler() => new(_purchaseRepositoryMock.Object);

    private void SetupGetById(Purchase purchase)
    {
        _purchaseRepositoryMock.Setup(x => x.GetByIdAsync(purchase.Id))
            .ReturnsAsync(purchase);
    }
}
