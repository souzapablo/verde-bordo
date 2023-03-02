using VerdeBordo.Application.Features.Orders.Commands.CreateOrder;

namespace VerdeBordo.UnitTests.Features.Orders
{
    public class CreateOrderCommandHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock = new();
        private readonly Mock<ICustomerRepository> _customerRepositoryMock = new();
        private readonly Mock<IEmbroideryRepository> _embroideryRepositoryMock = new();

        [Fact(DisplayName = "Given an invalid customer should throw exception")]
        public async Task GivenAnInvalidCustomerWhenCommandIsExecutedShouldThrowException()
        {
            // Arrange
            var command = new CreateOrderCommand(Guid.NewGuid(), DateTime.Now, PaymentMethod.Pix);
            var sut = GenerateCommandHandler();

            // Act 
            Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

            // Assert
            await task.Should().ThrowAsync<Exception>().WithMessage("Customer not found");
        }

        private CreateOrderCommandHandler GenerateCommandHandler() => new(_orderRepositoryMock.Object, _customerRepositoryMock.Object);
    }
}