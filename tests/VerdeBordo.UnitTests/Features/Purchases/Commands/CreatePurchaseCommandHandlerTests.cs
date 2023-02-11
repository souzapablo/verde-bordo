using VerdeBordo.Application.Features.Purchases.Commands.CreatePurchase;

namespace VerdeBordo.UnitTests.Features.Purchases.Commands;

public class CreatePurchaseCommandHandlerTests
{
    private readonly Mock<IPurchaseRepository> _purchaseRepositoryMock = new();
    private readonly Mock<IProductRepository> _productRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid product should throw exception")]
    public async Task GivenAnInvalidProductWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var command = new CreatePurchaseCommand(Guid.NewGuid(), 2_0, DateTime.Now, null);
        var sut = GenerateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>();
    }

    private CreatePurchaseCommandHandler GenerateCommandHandler() => new(_purchaseRepositoryMock.Object, _productRepositoryMock.Object);
}
