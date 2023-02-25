using VerdeBordo.Application.Features.Purchases.Queries.GetPurchaseById;

namespace VerdeBordo.UnitTests.Features.Purchases.Queries;

public class GetPurchaseByIdQueryHandlerTests
{
    private readonly Mock<IPurchaseRepository> _purchaseRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid purchase should throw exception")]
    public async Task GivenAnInvalidPurchaseWhenQueryIsExecutedShouldThrowException()
    {
        // Arrange
        var query = new GetPurchaseByIdQuery(Guid.NewGuid());
        var sut = GenerateQueryHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(query, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Purchase not found");
    }

    private GetPurchaseByIdQueryHandler GenerateQueryHandler() => new(_purchaseRepositoryMock.Object);
}
