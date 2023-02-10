using VerdeBordo.Application.Features.Products.Queries.GetProductById;

namespace VerdeBordo.UnitTests.Features.Products
{
    public class GetProductByIdQueryHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock = new();

        [Fact(DisplayName = "Given an invalid product should throw exception")]
        public async Task GivenAnInvalidProductWhenCommandIsExecutedShoudlTrhowException()
        {
            // Arrange
            var command = new GetProductByIdQuery(Guid.NewGuid());
            var sut = GenerateCommandHandler();

            // Act
            Func<Task> task = async () => await sut.Handle(command, new CancellationToken());

            // Assert
            await task.Should().ThrowAsync<Exception>();
        }

        private GetProductByIdQueryHandler GenerateCommandHandler() => new(_productRepositoryMock.Object);
    }
}
