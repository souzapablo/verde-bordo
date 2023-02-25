using VerdeBordo.Application.Features.Products.Commands.CreateProduct;

namespace VerdeBordo.UnitTests.Features.Products.Commands;

public class CreateProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock = new();
    private readonly Mock<ISupplierRepository> _supplierRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid supplier should throw exception")]
    public async Task GivenAnInvalidSupplierWhenCommandIsExecutedShoudlTrhowException()
    {
        // Arrange
        var command = new CreateProductCommand(Guid.NewGuid(), "Test description", 3_40);
        var sut = GenerateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Supplier not found");
    }

    private CreateProductCommandHandler GenerateCommandHandler() => new CreateProductCommandHandler(_productRepositoryMock.Object, _supplierRepositoryMock.Object);
}
