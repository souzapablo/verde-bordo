using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product is null)
            throw new Exception("Product not found");

        product.UpdatePrice(request.NewPrice);

        await _productRepository.UpdateAsync(product);

        return Unit.Value;
    }
}
