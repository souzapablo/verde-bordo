using VerdeBordo.Application.Features.Suppliers.Commands.UpdateSupplier;

namespace VerdeBordo.UnitTests.Features.Suppliers.Commands
{
    public class UpdateSupplierCommandHandlerTest
    {

        private readonly Mock<ISupplierRepository> _supplierRepositoryMock;

        public UpdateSupplierCommandHandlerTest()
        {
            _supplierRepositoryMock = new();
        }

        [Fact(DisplayName = "Given a valid user UpdateSupplierCommand should update name")]
        public async Task GivenAValidUserWhenCommandIsExecutedShouldUpdateName()
        {
            // Arrange
            var supplier = FakeSupplierFactory.FakeSupplier();
            var initialDate = supplier.LastUpdate;
            var command = new UpdateSupplierCommand(supplier.Id, "New name");
            var sut = GenerateCommandHandler();

            _supplierRepositoryMock.Setup(x => x.GetByIdAsync(supplier.Id))
                .ReturnsAsync(supplier);

            // Act
            await sut.Handle(command, new CancellationToken());

            // Assert
            supplier.Name.Should().Be("New name");
            supplier.LastUpdate.Should().NotBeSameDateAs(initialDate);
            _supplierRepositoryMock.Verify(x => x.UpdateSupplier(supplier), Times.Once());
        }

        [Fact(DisplayName = "Given an invalid user UpdateSupplierCommand should throw Exception")]
        public async Task GivenAnInvalidUserWhenCommandIsExecutedNameShouldThrowException()
        {
            // Arrange
            var supplier = FakeSupplierFactory.FakeSupplier();
            var command = new UpdateSupplierCommand(supplier.Id, "New name");
            var sut = GenerateCommandHandler();

            // Act
            Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

            // Assert
            supplier.Name.Should().Be(supplier.Name);
            supplier.LastUpdate.Should().BeSameDateAs(supplier.LastUpdate);
            _supplierRepositoryMock.Verify(x => x.UpdateSupplier(supplier), Times.Never());
            await task.Should().ThrowAsync<Exception>();
        }

        private UpdateSupplierCommandHandler GenerateCommandHandler() => new(_supplierRepositoryMock.Object);
    }
}
