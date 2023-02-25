using VerdeBordo.Application.Features.Suppliers.Queries.GetSuppliersByUserId;

namespace VerdeBordo.UnitTests.Features.Suppliers.Queries;

public class GetSuppliersByUserIdQueryHandlerTests
{
    private readonly Mock<ISupplierRepository> _supplierRepositoryMock = new();
    private readonly Mock<IUserRepository> _userRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid user should throw exception")]
    public async Task GivenAnInvalidUserWhenQueryIsExecutedShouldThrowException()
    {
        // Arrange
        var query = new GetSuppliersByUserIdQuery(Guid.NewGuid());
        var sut = GenerateQueryHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(query, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("User not found");
    }

    private GetSuppliersByUserIdQueryHandler GenerateQueryHandler() => new(_supplierRepositoryMock.Object, _userRepositoryMock.Object);
}