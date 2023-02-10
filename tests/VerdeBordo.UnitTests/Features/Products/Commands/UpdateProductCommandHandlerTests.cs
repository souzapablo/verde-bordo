using Moq;
using VerdeBordo.Application.Features.Products.Commands.UpdateProduct;
using VerdeBordo.Application.Features.Suppliers.Commands.UpdateSupplier;
using VerdeBordo.Core.Entities;

namespace VerdeBordo.UnitTests.Features.Products.Commands;

public class UpdateProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _productRepository = new();

    [Fact(DisplayName = "Given a valid UpdateProductCommand should update price")]
    public async Task GivenAValidUserWhenCommandIsExecutedShouldUpdateName()
    {
        // Arrange
        var product = FakeProductFactory.FakeProduct();
        var initialDate = product.LastUpdate;
        var command = new UpdateProductCommand(product.Id, 25_335678);
        var sut = GenerateCommandHandler();

        _productRepository.Setup(x => x.GetByIdAsync(product.Id))
            .ReturnsAsync(product);

        // Act
        await sut.Handle(command, new CancellationToken());

        // Assert
        product.Price.Should().Be(25_335678);
        product.LastUpdate.Should().NotBeSameDateAs(initialDate);
        _productRepository.Verify(x => x.UpdateAsync(product), Times.Once());
    }

    [Fact(DisplayName = "Given an invalid product should throw exception")]
    public async Task GivenAnInvalidUserWhenCommandIsExecutedNameShouldThrowException()
    {
        // Arrange
        var command = new UpdateProductCommand(Guid.NewGuid(), 25_335678);
        var sut = GenerateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>();
    }

    private UpdateProductCommandHandler GenerateCommandHandler() => new(_productRepository.Object);
}
