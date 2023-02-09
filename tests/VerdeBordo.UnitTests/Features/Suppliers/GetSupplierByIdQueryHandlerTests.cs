using FluentAssertions;
using Moq;
using VerdeBordo.Application.Features.Suppliers.Queries.GetSupplierById;
using VerdeBordo.Core.Repositories;
using Xunit;

namespace VerdeBordo.UnitTests.Features.Suppliers
{
    public class GetSupplierByIdQueryHandlerTests
    {
        private readonly Mock<ISupplierRepository> _supplierRepositoryMock;

        public GetSupplierByIdQueryHandlerTests()
        {
            _supplierRepositoryMock = new();
        }


        [Fact(DisplayName = "Throw exception when user doesn't exist")]
        public async Task GivenAnInvalidIdWhenQueryIsExecutedShouldThrowException()
        {
            // Arrange
            var query = new GetSupplierByIdQuery(Guid.NewGuid());
            var sut = GenerateQueryHandler();

            // Act
            Func<Task> task = async() => await sut.Handle(query, new CancellationToken());

            // Assert
            await task.Should().ThrowAsync<Exception>();
        }

        private GetSupplierByIdQueryHandler GenerateQueryHandler() => new(_supplierRepositoryMock.Object);

    }
}
