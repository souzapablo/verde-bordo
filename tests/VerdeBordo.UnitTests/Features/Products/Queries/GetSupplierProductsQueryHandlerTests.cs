using VerdeBordo.Application.Features.Products.Queries.GeSupplierProducts;

namespace VerdeBordo.UnitTests.Features.Products.Queries;

public class GetSupplierProductsQueryHandlerTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock = new();
    private readonly Mock<ISupplierRepository> _supplierRepositoryMock = new();


    [Fact(DisplayName = "Given an invalid supplier should throw exception")]
    public async Task GivenAnInvalidSupplierWhenQueryIsExecutedShouldThrowException()
    {
        // Arrange
        var query = new GetSupplierProductsQuery(Guid.NewGuid());
        var sut = GenerateQueryHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(query, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Supplier not found");
    }

    private GetSupplierProductsQueryHandler GenerateQueryHandler() => new GetSupplierProductsQueryHandler(_productRepositoryMock.Object, _supplierRepositoryMock.Object);
}
