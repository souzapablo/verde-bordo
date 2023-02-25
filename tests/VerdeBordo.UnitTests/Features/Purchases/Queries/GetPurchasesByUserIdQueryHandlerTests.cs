using VerdeBordo.Application.Features.Purchases.Queries.GetPurchasesByUserId;

namespace VerdeBordo.UnitTests.Features.Purchases.Queries;

public class GetPurchasesByUserIdQueryHandlerTests
{
    private readonly Mock<IPurchaseRepository> _purchaseRepositoryMock = new();
    private readonly Mock<IUserRepository> _userRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid user should throw exception")]
    public async Task GivenAnInvalidUserWhenQueryIsExecutedShouldThrowException()
    {
        // Arrange
        var query = new GetPurchasesByUserIdQuery(Guid.NewGuid());
        var sut = GenerateQueryHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(query, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("User not found");
    }

    private GetPurchasesByUserIdQueryHandler GenerateQueryHandler() => new(_purchaseRepositoryMock.Object, _userRepositoryMock.Object);
}