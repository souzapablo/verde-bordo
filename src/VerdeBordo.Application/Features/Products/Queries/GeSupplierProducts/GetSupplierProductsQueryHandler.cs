using MediatR;
using VerdeBordo.Application.ViewModels.Products;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Products.Queries.GeSupplierProducts;

public class GetSupplierProductsQueryHandler : IRequestHandler<GetSupplierProductsQuery, List<ProductViewModel>>
{
    private readonly IProductRepository _productRepository;
    private readonly ISupplierRepository _supplierRepository;

    public GetSupplierProductsQueryHandler(IProductRepository productRepository, ISupplierRepository supplierRepository)
    {
        _productRepository = productRepository;
        _supplierRepository = supplierRepository;
    }

    public async Task<List<ProductViewModel>> Handle(GetSupplierProductsQuery request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.GetByIdAsync(request.SupplierId);

        if (supplier is null)
            throw new Exception("Supplier not found");

        var supplierProducts = await _productRepository.GetBySupplierIdAsync(supplier.Id);

        return supplierProducts.Select(x => new ProductViewModel(x.Id, x.Description, x.Price)).ToList();
    }
}
