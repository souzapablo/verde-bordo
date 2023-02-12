using VerdeBordo.Application.Features.Purchases.Commands.DeletePurchase;

namespace VerdeBordo.UnitTests.Features.Purchases.Commands;

public class DeletePurchaseCommandHandlerTests
{
    private readonly Mock<IPurchaseRepository> _purchaseRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid purchase should throw exception")]
    public async Task GivenAnInvalidPurchaseWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var command = new DeletePurchaseCommand(Guid.NewGuid());
        var sut = GenerateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>();
    }

    private DeletePurchaseCommandHandler GenerateCommandHandler() => new(_purchaseRepositoryMock.Object);   
}
