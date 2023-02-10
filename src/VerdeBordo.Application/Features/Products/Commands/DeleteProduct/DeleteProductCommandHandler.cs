using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product is null)
            throw new Exception("Product not found");

        product.ToggleActiveStatus();

        await _productRepository.UpdateAsync(product);

        return Unit.Value;
    }
}
