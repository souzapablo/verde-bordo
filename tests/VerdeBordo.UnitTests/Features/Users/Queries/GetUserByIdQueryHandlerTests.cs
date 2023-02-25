using VerdeBordo.Application.Features.Users.Queries.GetUserById;

namespace VerdeBordo.UnitTests.Features.Users.Queries;

public class GetUserByIdQueryHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid user should throw exception")]
    public async Task GivenAnInvalidUserWhenQueryIsExecutedShouldThrowException()
    {
        // Arrange
        var query = new GetUserByIdQuery(Guid.NewGuid());
        var sut = GenerateQueryHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(query, new CancellationToken());

        // Act
        await task.Should().ThrowAsync<Exception>().WithMessage("User not found");
    }

    public GetUserByIdQueryHandler GenerateQueryHandler() => new(_userRepositoryMock.Object);
}