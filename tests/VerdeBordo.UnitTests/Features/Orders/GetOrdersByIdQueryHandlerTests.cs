using VerdeBordo.Application.Features.Orders.Queries.GetOrderById;

namespace VerdeBordo.UnitTests.Features.Orders;

public class GetOrdersByIdQueryHandlerTests
{
    private readonly Mock<IOrderRepository> _orderRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid order should throw exception")]
    public async Task GivenAnInvalidOrderWhenQueryIsExecutedShouldThrowException()
    {
        // Arrange
        var query = new GetOrderByIdQuery(Guid.NewGuid());
        var sut = GenerateQueryHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(query, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Order not found");
    }

    private GetOrderByIdQueryHandler GenerateQueryHandler() => new(_orderRepositoryMock.Object);
}