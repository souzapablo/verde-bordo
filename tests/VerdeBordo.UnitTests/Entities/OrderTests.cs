namespace VerdeBordo.UnitTests.Entities;

public class OrderTests
{
    [Fact(DisplayName = "Given a valid status when StartDraft is called should change status to Draft")]
    public void GivenAValidStatusWhenStartDraftIsCalledShouldChangeStatusToDraft()
    {
        // Arrange
        var sut = GetFakeOrder();
        var initialDate = sut.LastUpdate;

        // Act
        sut.StartDraft();

        // Assert
        sut.Status.Should().Be(OrderStatus.Draft);
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }

    [Fact(DisplayName = "Given an invalid status when StartDraft is called should throw exception")]
    public void GivenAnInvalidStatusWhenStratDraftIsCalledShouldThrowException()
    {
        // Arrange
        var sut = GetFakeOrder(true, OrderStatus.Finishing);

        // Act
        Action action = () => sut.StartDraft();

        // Assert
        action.Should().Throw<Exception>().WithMessage("Invalid status");
    }

    [Fact(DisplayName = "Given a valid status when CompleteDraft is called should change status to AwaitingDraftApproval")]
    public void GivenAValidStatusWhenCompleteDraftIsCalledShouldChangeStatusToAwaitingDraftApproval()
    {
        // Arrange
        var sut = GetFakeOrder(true, OrderStatus.Draft);
        var initialDate = sut.LastUpdate;

        // Act
        sut.CompleteDraft();

        // Assert
        sut.Status.Should().Be(OrderStatus.AwaitingDraftApproval);
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }

    [Fact(DisplayName = "Given an invalid status when CompleteDraft is called should throw exception")]
    public void GivenAnInvalidStatusWhenCompleteDraftIsCalledShouldThrowException()
    {
        // Arrange
        var sut = GetFakeOrder(true, OrderStatus.Finishing);

        // Act
        Action action = () => sut.CompleteDraft();

        // Assert
        action.Should().Throw<Exception>().WithMessage("Invalid status");
    }

    [Fact(DisplayName = "Given a valid status when ApproveDraft is called should change status to Embroidering")]
    public void GivenAValidStatusWhenApproveDraftIsCalledShouldChangeStatusToEmbroidering()
    {
        // Arrange
        var sut = GetFakeOrder(true, OrderStatus.AwaitingDraftApproval);
        var initialDate = sut.LastUpdate;

        // Act
        sut.ApproveDraft();

        // Assert
        sut.Status.Should().Be(OrderStatus.Embroidering);
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }

    [Fact(DisplayName = "Given an invalid status when ApproveDraft is called should throw exception")]
    public void GivenAnInvalidStatusWhenApproveDraftIsCalledShouldThrowException()
    {
        // Arrange
        var sut = GetFakeOrder(true, OrderStatus.Finishing);

        // Act
        Action action = () => sut.ApproveDraft();

        // Assert
        action.Should().Throw<Exception>().WithMessage("Invalid status");
    }
    
    [Fact(DisplayName = "Given a valid satus when ReproveDraft is called should change status to Draft")]
    public void GivenAValidStatusWhenReproveDraftIsCalledShouldChangeStatusToEmbroidering()
    {
        // Arrange
        var sut = GetFakeOrder(true, OrderStatus.AwaitingDraftApproval);
        var initialDate = sut.LastUpdate;

        // Act
        sut.ReproveDraft();

        // Assert
        sut.Status.Should().Be(OrderStatus.Draft);
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }
    

    [Fact(DisplayName = "Given an invalid status when ReproveDraft is called should throw exception")]
    public void GivenAValidStatusWhenReproveDraftIsCalledShouldChangeStatusToDraft()
    {
        // Arrange
        var sut = GetFakeOrder(true, OrderStatus.Finishing);

        // Act
        Action action = () => sut.ReproveDraft();

        // Assert
        action.Should().Throw<Exception>().WithMessage("Invalid status");
    }

    [Fact(DisplayName = "Given a valid satus when CompleteEmbroidery is called should change status to Finishing")]
    public void GivenAValidStatusWhenCompleteEmbroideryIsCalledShouldChangeStatusToFinishing()
    {
        // Arrange
        var sut = GetFakeOrder(true, OrderStatus.Embroidering);
        var initialDate = sut.LastUpdate;

        // Act
        sut.CompleteEmbroidery();

        // Assert
        sut.Status.Should().Be(OrderStatus.Finishing);
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }

    [Fact(DisplayName = "Given an invalid status when CompleteEmbroidery is called should throw exception")]
    public void GivenAnInvalidStatusWhenCompleteEmbroideryIsCalledShouldThrowException()
    {
        // Arrange
        var sut = GetFakeOrder(true, OrderStatus.Finishing);

        // Act
        Action action = () => sut.CompleteEmbroidery();

        // Assert
        action.Should().Throw<Exception>().WithMessage("Invalid status");
    }

    [Fact(DisplayName = "Given a valid satus when CompleteFinishing is called should change status to Delivering")]
    public void GivenAValidStatusWhenCompleteFinishingIsCalledShouldChangeStatusToFinishing()
    {
        // Arrange
        var sut = GetFakeOrder(true, OrderStatus.Finishing);
        var initialDate = sut.LastUpdate;

        // Act
        sut.CompleteFinishing();

        // Assert
        sut.Status.Should().Be(OrderStatus.Delivering);
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }

    [Fact(DisplayName = "Given an invalid status when CompleteFinishing is called should throw exception")]
    public void GivenAnInvalidStatusWhenCompleteFinishingIsCalledShouldThrowException()
    {
        // Arrange
        var sut = GetFakeOrder(true, OrderStatus.Finished);

        // Act
        Action action = () => sut.CompleteFinishing();

        // Assert
        action.Should().Throw<Exception>().WithMessage("Invalid status");
    }   

    [Fact(DisplayName = "Given a valid satus when Deliver is called should change status to Finished")]
    public void GivenAValidStatusWhenDeliverIsCalledShouldChangeStatusToFinishing()
    {
        // Arrange
        var sut = GetFakeOrder(true, OrderStatus.Delivering);
        var initialDate = sut.LastUpdate;

        // Act
        sut.Deliver();

        // Assert
        sut.Status.Should().Be(OrderStatus.Finished);
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }

    [Fact(DisplayName = "Given an invalid status when Deliver is called should throw exception")]
    public void GivenAnInvalidStatusWhenDeliverIsCalledShouldThrowException()
    {
        // Arrange
        var sut = GetFakeOrder(true, OrderStatus.Finished);

        // Act
        Action action = () => sut.Deliver();

        // Assert
        action.Should().Throw<Exception>().WithMessage("Invalid status");
    }  

    [Fact(DisplayName = "Given a valid DueDate when SetDueDate is called should update DueDate")]
    public void GivenAValidDueDateWhenSetDueDateIsCalledShouldUpdateDueDate()
    {
        // Arrange
        var sut = GetFakeOrder();
        var newDueDate = new DateTime(2022, 12, 1);
        var initialDate = sut.LastUpdate;

        // Act
        sut.SetDueDate(newDueDate);

        // Assert
        sut.DueDate.Should().BeSameDateAs(newDueDate);
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }

    [Fact(DisplayName = "Given two Embroideries with Shipment GetTotalValue should return value correctly")]
    public void GivenTwoEmbroideriesWithShipmentGetTotalValueShouldReturnValueCorrectly()
    {
        // Arrange
        var sut = GetFakeOrder();
        var initialDate = sut.LastUpdate;
        var firstEmbroidery = FakeEmbroideryFactory.EmbroideryFaker();
        var secondEmbroidery = FakeEmbroideryFactory.EmbroideryFaker();
        sut.Embroideries.AddRange(new List<Embroidery> { firstEmbroidery, secondEmbroidery });

        // Act
        var totalValue = sut.GetTotalValue();

        // Assert
        totalValue.Should().Be(sut.Shipment + firstEmbroidery.Price + secondEmbroidery.Price);
    }

    private static Order GetFakeOrder(bool isActive = true, OrderStatus status = OrderStatus.Created) => FakeOrderFactory.OrderFaker(isActive, status);
}