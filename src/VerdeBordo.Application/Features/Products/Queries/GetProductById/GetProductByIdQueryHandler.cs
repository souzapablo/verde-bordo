using MediatR;
using VerdeBordo.Application.ViewModels.Products;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailsViewModel>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDetailsViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product is null)
            throw new Exception("Product not found");

        return new ProductDetailsViewModel(product.Supplier.Name, product.Id, product.Description, product.Price);
    }
}
