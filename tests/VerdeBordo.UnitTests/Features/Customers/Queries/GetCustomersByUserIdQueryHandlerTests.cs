using VerdeBordo.Application.Features.Customers.Queries.GetByUserId;

namespace VerdeBordo.UnitTests.Features.Customers.Queries;

public class GetCustomersByUserIdQueryHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new();
    private readonly Mock<ICustomerRepository> _customerRepositoryMock = new();


    [Fact(DisplayName = "Given an invalid user should throw exception")]
    public async Task GivenAnInvalidUserWhenQueryIsExecutedShouldThrowException()
    {
        // Arrange
        var query = new GetCustomersByUserIdQuery(Guid.NewGuid());
        var sut = GenerateQueryHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(query, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("User not found");
    }

    public GetCustomersByUserIdQueryHandler GenerateQueryHandler() => new(_userRepositoryMock.Object, _customerRepositoryMock.Object);
}