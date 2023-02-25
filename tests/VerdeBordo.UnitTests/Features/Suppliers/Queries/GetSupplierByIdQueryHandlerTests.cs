using VerdeBordo.Application.Features.Suppliers.Queries.GetSupplierById;

namespace VerdeBordo.UnitTests.Features.Suppliers.Queries;

public class GetSupplierByIdQueryHandlerTests
{
    private readonly Mock<ISupplierRepository> _supplierRepositoryMock = new();


    [Fact(DisplayName = "Given an invalid supplier should throw exception")]
    public async Task GivenAnInvalidIdWhenQueryIsExecutedShouldThrowException()
    {
        // Arrange
        var query = new GetSupplierByIdQuery(Guid.NewGuid());
        var sut = GenerateQueryHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(query, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Supplier not found");
    }

    private GetSupplierByIdQueryHandler GenerateQueryHandler() => new(_supplierRepositoryMock.Object);

}
