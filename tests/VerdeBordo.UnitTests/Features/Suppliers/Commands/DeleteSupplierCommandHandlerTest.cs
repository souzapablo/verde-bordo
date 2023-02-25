using VerdeBordo.Application.Features.Suppliers.Commands.DeleteSupplier;

namespace VerdeBordo.UnitTests.Features.Suppliers.Commands;

public class DeleteSupplierCommandHandlerTest
{
    private readonly Mock<ISupplierRepository> _supplierRepositoryMock = new();

    [Fact(DisplayName = "Given a valid supplier should delete")]
    public async Task GivanAValidUserWhenCommandIsExecutedIsActiveShouldBeFalse()
    {
        // Arrange
        var supplier = FakeSupplierFactory.FakeSupplier();
        var initialDate = supplier.LastUpdate;
        var command = new DeleteSupplierCommand(supplier.Id);
        var sut = GenereateCommandHanlder();

        _supplierRepositoryMock.Setup(x => x.GetByIdAsync(supplier.Id))
            .ReturnsAsync(supplier);

        // Act
        await sut.Handle(command, new CancellationToken());

        // Assert
        supplier.IsActive.Should().BeFalse();
        supplier.LastUpdate.Should().NotBeSameDateAs(initialDate);
        _supplierRepositoryMock.Verify(x => x.UpdateAsync(supplier), Times.Once);
    }

    [Fact(DisplayName = "Given an invalid supplier should throw exception")]
    public async Task GivanAnInvalidUserWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var command = new DeleteSupplierCommand(Guid.NewGuid());
        var sut = GenereateCommandHanlder();


        // Act
        Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

        // Assert
        await task.Should().ThrowAsync<Exception>().WithMessage("Supplier not found");
    }

    private DeleteSupplierCommandHandler GenereateCommandHanlder() => new (_supplierRepositoryMock.Object);
}
