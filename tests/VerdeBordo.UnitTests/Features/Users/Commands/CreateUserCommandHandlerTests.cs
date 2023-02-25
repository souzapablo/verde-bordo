using VerdeBordo.Application.Features.Users.Commands.CreateUser;

namespace VerdeBordo.UnitTests.Features.Users.Commands;

public class CreateUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new();

    [Fact(DisplayName = "Given a registered e-mail should throw exception")]
    public async Task GivenARegisteredEmailWhenCommandIsExecutedShouldThrowException()
    {
        // Assert
        var command = new CreateUserCommand("Test", "McTesty", "tester", "test@test.com", "testpassword", Role.Admin);
        var sut = GenerateCommandHandler();

        _userRepositoryMock.Setup(x => x.IsEmailRegistered(It.IsAny<string>()))
            .ReturnsAsync(true);

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("E-mail already registered");
    }

    private CreateUserCommandHandler GenerateCommandHandler() => new(_userRepositoryMock.Object);    
}