using VerdeBordo.Application.Features.Customers.Commands.UpdateCustomer;

namespace VerdeBordo.UnitTests.Features.Customers.Commands;

public class UpateCustomerCommandHandlerTests
{
    private readonly Mock<ICustomerRepository> _customerRepositoryMock = new();

    [Fact(DisplayName = "Given an invalid customer should throw exception")]
    public async Task GivenAnInvalidCustomerWhenCommandIsExecutedShouldTrhowException()
    {
        // Arrange
        var command = new UpdateCustomerCommand(Guid.NewGuid(), "new contact");
        var sut = GenerateCommandHandler();

        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>();
    }

    [Fact(DisplayName = "Given a new contact should update customer contact")]
    public async Task GivenANewContactWhenCommandIsExecutedShouldUpdateCustomerContact()
    {
        // Arrange
        var customer = FakeCustomerFactory.FakeCustomer();
        var inicialDate = customer.LastUpdate;
        var command = new UpdateCustomerCommand(customer.Id, "new contact");
        var sut = GenerateCommandHandler();
        _customerRepositoryMock.Setup(x => x.GetByIdAsync(customer.Id))
            .ReturnsAsync(customer);

        // Act
        await sut.Handle(command, new CancellationToken());

        // Assert
        customer.Contact.Should().Be("new contact");
        customer.LastUpdate.Should().NotBeSameDateAs(inicialDate);
        _customerRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Customer>()), Times.Once);
    }

    private UpdateCustomerCommandHandler GenerateCommandHandler() => new(_customerRepositoryMock.Object);
}
