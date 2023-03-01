using VerdeBordo.Application.Features.Users.Commands.UpdateUser;

namespace VerdeBordo.UnitTests.Features.Users.Commands;

public class UpdateUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid user should throw exception")]
    public async Task GivenAnInvalidUserWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var command = new UpdateUserCommand(Guid.NewGuid(), null, null, null);
        var sut = GenerateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("User not found"); 
    }

    [Fact(DisplayName = "Given a valid UpdateUserCommand should update user")]
    public async Task GivenOnlyANewFirstNameWhenCommandIsExecutedShouldUpdateFirstName()
    {
        // Arrange
        var user = FakeUserFactory.UserFaker();
        var command = new UpdateUserCommand(user.Id, "Test", "McTesty", "test@test.com");
        var sut = GenerateCommandHandler();

        _userRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(user);

        // Act
        await sut.Handle(command, new CancellationToken());

        // Assert
        user.FirstName.Should().Be("Test");
        _userRepositoryMock.Verify(x => x.UpdateAsync(user), Times.Once);
    }

    private UpdateUserCommandHandler GenerateCommandHandler() => new(_userRepositoryMock.Object);
}