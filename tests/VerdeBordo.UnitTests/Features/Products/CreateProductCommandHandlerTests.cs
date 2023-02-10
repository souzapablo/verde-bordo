using VerdeBordo.Application.Features.Products.Commands;

namespace VerdeBordo.UnitTests.Features.Products
{
    public class CreateProductCommandHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock = new();
        private readonly Mock<ISupplierRepository> _supplierRepositoryMock = new();

        [Fact(DisplayName = "Given an invalid supplier should throw exception")]

        private CreateProductCommandHandler GenerateCommandHandler() => new CreateProductCommandHandler(_productRepositoryMock.Object, _supplierRepositoryMock.Object);
    }
}
