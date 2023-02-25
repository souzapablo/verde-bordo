using VerdeBordo.Application.Features.Users.Commands.DeleteUser;

namespace VerdeBordo.UnitTests.Features.Users.Commands;

public class DeleteUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid user should throw exception")]
    public async Task GivenAnInvalidUserWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var command = new DeleteUserCommand(Guid.NewGuid());
        var sut = GenerateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("User not found");
    }

    [Fact(DisplayName = "Given a valid DeleteUserCommand should delete user")]
    public async Task GivenAValidDeleteUserWhenCommandIsExecutedCommandShouldDeleteUser()
    {
        // Arrange
        var user = FakeUserFactory.FakeUser();
        var command = new DeleteUserCommand(user.Id);
        var initialDate = user.LastUpdate;
        var sut = GenerateCommandHandler();

        _userRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(user);

        // Act
        await sut.Handle(command, new CancellationToken());

        // Assert
        user.IsActive.Should().BeFalse();
        user.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }

    private DeleteUserCommandHandler GenerateCommandHandler() => new(_userRepositoryMock.Object);
}