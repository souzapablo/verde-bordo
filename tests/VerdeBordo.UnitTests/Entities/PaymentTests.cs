namespace VerdeBordo.UnitTests.Entities;

public class PaymentTests
{
    [Fact(DisplayName = "Given a valid payment when Pay is executed should update values")]
    public void GivenAValidPaymentWhenPayIsExecutedShouldUpdateValues()
    {
        // Arrange
        var sut = GetFakerPayment();
        var initialDate = sut.LastUpdate;

        // Act
        sut.Pay();

        // Assert
        sut.PaymentDate.Should().NotBeNull();
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
        sut.HasPaid.Should().BeTrue();
    }

    [Fact(DisplayName = "Given an already processed payment when Pay is executed should throw exception")]
    public void GivenAnAlreadyPaidPaymentWhenPayIsExecutedShouldThrowException()
    {
        // Arrange
        var sut = GetFakerPayment(true, true);

        // Act
        Action action = () => sut.Pay();

        //Assert
        action.Should().Throw<Exception>().WithMessage("Payment already processed");
    }

    private static Payment GetFakerPayment(bool isActive = true, bool hasPaid = false) => FakerPaymentFactory.PaymentFaker(isActive, hasPaid);
}