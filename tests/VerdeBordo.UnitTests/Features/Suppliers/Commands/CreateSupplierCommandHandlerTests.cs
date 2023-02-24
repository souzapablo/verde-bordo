using VerdeBordo.Application.Features.Suppliers.Commands.CreateSupplier;

namespace VerdeBordo.UnitTests.Features.Suppliers.Commands;

public class CreateSupplierCommandHandlerTests
{
    private readonly Mock<ISupplierRepository> _supplierRepositoryMock = new();
    private readonly Mock<IUserRepository> _userRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid user should trhow exception")]
    public async Task GivenAnInvalidUserWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var command = new CreateSupplierCommand(Guid.NewGuid(), "Testing");
        var sut = GenerateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>();
    }

    private CreateSupplierCommandHandler GenerateCommandHandler() => new CreateSupplierCommandHandler(_supplierRepositoryMock.Object, _userRepositoryMock.Object);
}