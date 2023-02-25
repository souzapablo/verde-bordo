using VerdeBordo.Application.Features.Customers.Commands.CreateCustomer;

namespace VerdeBordo.UnitTests.Features.Customers.Commands;

public class CreateCustomerCommandHandlerTests
{
    private readonly Mock<ICustomerRepository> _customerRepositoryMock = new();
    private readonly Mock<IUserRepository> _userRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid user should throw exception")]
    public async Task GivenAnInvalidUserWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var command = new CreateCustomerCommand(Guid.NewGuid(), "Bolton", "Testing");
        var sut = GenerateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("User not found");
    }

    private CreateCustomerCommandHandler GenerateCommandHandler() => new CreateCustomerCommandHandler(_customerRepositoryMock.Object, _userRepositoryMock.Object);
}