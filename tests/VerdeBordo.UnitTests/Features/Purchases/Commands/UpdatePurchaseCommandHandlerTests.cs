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

    [Fact(DisplayName = "Given a valid UpdatePurchaseCommand should update Purchase")]
    public async Task GivenOnlyANewPurchasedAmountWhenCommandIsExecutedShouldUpdateOnlyPurchasedAmount()
    {
        // Arrange
        var purchase = FakePurchaseFactory.FakePurchase(); 
        var initialDate = purchase.LastUpdate;
        var command = new UpdatePurchaseCommand(purchase.Id, 101_0, null, null);
        var sut = GenerateCommandHandler();

        _purchaseRepositoryMock.Setup(x => x.GetByIdAsync(purchase.Id))
            .ReturnsAsync(purchase);

        // Act
        await sut.Handle(command, new CancellationToken());

        // Assert
        purchase.PurchasedAmount.Should().Be(101_0);
        purchase.Shipment.Should().Be(purchase.Shipment);
        purchase.PurchaseDate.Should().Be(purchase.PurchaseDate);
        purchase.LastUpdate.Should().NotBeSameDateAs(initialDate);
        _purchaseRepositoryMock.Verify(x => x.UpdateAsync(purchase), Times.Once);
    }

    private UpdatePurchaseCommandHandler GenerateCommandHandler() => new(_purchaseRepositoryMock.Object);
}
