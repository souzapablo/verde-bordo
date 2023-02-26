using MediatR;
using VerdeBordo.Application.ViewModels.Products;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductWithSupplierIdViewModel>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductWithSupplierIdViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(x => x.Supplier);

        return products.Select(x => new ProductWithSupplierIdViewModel(x.Supplier.Name, x.Id, x.Description, x.Price)).ToList();
    }
}
