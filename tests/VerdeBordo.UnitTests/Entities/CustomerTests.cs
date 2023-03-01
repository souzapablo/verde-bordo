namespace VerdeBordo.UnitTests.Entities;

public class CustomerTests
{
    [Fact(DisplayName = "Given a valid new Contact should update Customer")]
    public void GivenAValidNewContactWhenUpdateCustomerIsExecutedShouldUpdateCustomer()
    {
        // Arrange
        var sut = FakeCustomerFactory.CustomerFaker();
        var initialDate = sut.LastUpdate;

        // Act
        sut.UpdateContact("New contact");

        // Assert
        sut.Contact.Should().Be("New contact");
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }
}