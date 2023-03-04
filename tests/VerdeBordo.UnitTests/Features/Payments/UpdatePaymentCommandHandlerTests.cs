using VerdeBordo.Application.Features.Payments.UpdatePayment;

namespace VerdeBordo.UnitTests.Features.Payments;

public class UpdatePaymentCommandHandlerTests
{
    private readonly Mock<IPaymentRepository> _paymentRepositoryMock = new();
    
    [Fact(DisplayName = "Given an invalid payment should throw exception")]
    public async Task GivenAnInvalidPaymentWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var command = new UpdatePaymentCommand(Guid.NewGuid());
        var sut = GenerateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Payment not found");
    }

    private UpdatePaymentCommandHandler GenerateCommandHandler() => new(_paymentRepositoryMock.Object);
}