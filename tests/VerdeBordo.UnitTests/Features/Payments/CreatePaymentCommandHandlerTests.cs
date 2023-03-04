using VerdeBordo.Application.Features.Payments.Commands;

namespace VerdeBordo.UnitTests.Features.Payments;

public class CreatePaymentCommandHandlerTests
{
    private readonly Mock<IPaymentRepository> _paymentRepositoryMock = new();
    private readonly Mock<IOrderRepository> _orderRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid order should throw exception")]
    public async Task GivenAnInvalidOrderWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var command = new CreatePaymentCommand(Guid.NewGuid(), 10, DateTime.Now);
        var sut = GenreateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Order not found");
    }

    [Theory(DisplayName = "Given an invalid amount payment should throw exception")]
    [InlineData(1)]
    [InlineData(0.000001D)]
    public async Task GivenAnInvalidAmountWhenCommandIsExecutedShouldThrowException(decimal extraAmount)
    {
        // Arrange
        var order = FakeOrderFactory.OrderFaker();
        var maxValue = order.GetTotalValue();
        var command = new CreatePaymentCommand(order.Id, maxValue + extraAmount, DateTime.Now);
        var sut = GenreateCommandHandler();

        _orderRepositoryMock.Setup(x => x.GetByIdAsync(order.Id))
            .ReturnsAsync(order);

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Payment amount is higher than order total value");

    }

    private CreatePaymentCommandHandler GenreateCommandHandler() => new(_paymentRepositoryMock.Object, _orderRepositoryMock.Object);
}