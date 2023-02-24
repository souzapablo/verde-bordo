using VerdeBordo.Application.Features.Purchases.Commands.CreatePurchase;

namespace VerdeBordo.UnitTests.Features.Purchases.Commands;

public class CreatePurchaseCommandHandlerTests
{
    private readonly Mock<IPurchaseRepository> _purchaseRepositoryMock = new();
    private readonly Mock<IProductRepository> _productRepositoryMock = new();
    private readonly Mock<IUserRepository> _userRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid product should throw exception")]
    public async Task GivenAnInvalidProductWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var command = new CreatePurchaseCommand(Guid.NewGuid(), Guid.NewGuid(), 2_0, DateTime.Now, null);
        var sut = GenerateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>();
    }


    [Fact(DisplayName = "Given an invalid user should throw exception")]
    public async Task GivenAnInvalidUserWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var product = FakeProductFactory.FakeProduct();
        var command = new CreatePurchaseCommand(Guid.NewGuid(), Guid.NewGuid(), 2_0, DateTime.Now, null);
        var sut = GenerateCommandHandler();

        _productRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(product);

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>();
    }

    private CreatePurchaseCommandHandler GenerateCommandHandler() => new(_purchaseRepositoryMock.Object, _productRepositoryMock.Object, _userRepositoryMock.Object);
}
