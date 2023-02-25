using VerdeBordo.Application.Features.Products.Commands.DeleteProduct;

namespace VerdeBordo.UnitTests.Features.Products.Commands;

public class DeleteProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock = new();

    [Fact(DisplayName = "Given a valid product should delete")]
    public async Task GivanAValidUserWhenCommandIsExecutedIsActiveShouldBeFalse()
    {
        // Arrange
        var product = FakeProductFactory.FakeProduct();
        var initialDate = product.LastUpdate;
        var command = new DeleteProductCommand(product.Id);
        var sut = GenereateCommandHanlder();

        _productRepositoryMock.Setup(x => x.GetByIdAsync(product.Id))
            .ReturnsAsync(product);

        // Act
        await sut.Handle(command, new CancellationToken());

        // Assert
        product.IsActive.Should().BeFalse();
        product.LastUpdate.Should().NotBeSameDateAs(initialDate);
        _productRepositoryMock.Verify(x => x.UpdateAsync(product), Times.Once);
    }

    [Fact(DisplayName = "Given an invalid product should throw exception")]
    public async Task GivanAnInvalidUserWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var command = new DeleteProductCommand(Guid.NewGuid());
        var sut = GenereateCommandHanlder();


        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Product not found");
    }

    private DeleteProductCommandHandler GenereateCommandHanlder() => new(_productRepositoryMock.Object);
}
