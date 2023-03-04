using VerdeBordo.Application.Features.Embroideries.Commands;

namespace VerdeBordo.UnitTests.Features.Embroideries;

public class CreateEmbroideryCommandHandlerTests
{
    private readonly Mock<IEmbroideryRepository> _embroideryRepositoryMock = new();
    private readonly Mock<IOrderRepository> _orderRepositoryMock = new();
    [Fact(DisplayName = "Given an invalid order should throw exception")]
    public async Task GivenAnInvalidOrderWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var command = new CreateEmbroideryCommand(Guid.NewGuid(), "Testing embroidery", EmbroideryDetails.Sentence, EmbroiderySize.Small, 10, true);
        var sut = GenreateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Order not found");
    }

    private CreateEmbroideryCommandHandler GenreateCommandHandler() => new(_embroideryRepositoryMock.Object, _orderRepositoryMock.Object);
}