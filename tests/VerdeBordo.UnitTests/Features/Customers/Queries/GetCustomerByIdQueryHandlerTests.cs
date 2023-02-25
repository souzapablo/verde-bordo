using VerdeBordo.Application.Features.Customers.Queries.GetCustomerById;

namespace VerdeBordo.UnitTests.Features.Customers.Queries;

public class GetCustomerByIdQueryHandlerTests
{
    private readonly Mock<ICustomerRepository> _customerRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid customer should trhow exception")]
    public async Task GivenAnInvalidCustomerWhenQueryIsExecutedShouldThrowException()
    {
        // Arrange
        var query = new GetCustomerByIdQuery(Guid.NewGuid());
        var sut = GenerateQueryHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(query, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Customer not found");
    }

    private GetCustomerByIdQueryHandler GenerateQueryHandler() => new(_customerRepositoryMock.Object);
}

