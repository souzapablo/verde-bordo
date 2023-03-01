using VerdeBordo.Application.Features.Customers.Commands.DeleteCustomer;

namespace VerdeBordo.UnitTests.Features.Customers.Commands;

public class DeleteCustomerCommandHandlerTests
{
    private readonly Mock<ICustomerRepository> _customerRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid customer should throw exception")]
    public async Task GivenAnInvalidCustomerWhenCommandIsExecutedShouldThrowException()
    {
        // Assert
        var command = new DeleteCustomerCommand(Guid.NewGuid());
        var sut = GenerateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Customer not found");
    }

    [Fact(DisplayName = "Givan a valid customer should should delete")]
    public async Task GivenAValidCustomerWhenCommandIsExecutedShouldDelete()
    {
        // Assert
        var customer = FakeCustomerFactory.CustomerFaker();
        var initialDate = customer.LastUpdate;
        var command = new DeleteCustomerCommand(customer.Id);
        var sut = GenerateCommandHandler();

        _customerRepositoryMock.Setup(x => x.GetByIdAsync(customer.Id))
            .ReturnsAsync(customer);

        // Act
        await sut.Handle(command, new CancellationToken());

        // Assert
        customer.IsActive.Should().BeFalse();
        customer.LastUpdate.Should().NotBeSameDateAs(initialDate);
        _customerRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Customer>()), Times.Once);
    }

    private DeleteCustomerCommandHandler GenerateCommandHandler() => new(_customerRepositoryMock.Object);
}
