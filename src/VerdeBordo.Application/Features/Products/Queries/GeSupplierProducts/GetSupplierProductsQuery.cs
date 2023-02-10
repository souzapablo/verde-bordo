using MediatR;
using VerdeBordo.Application.ViewModels.Products;

namespace VerdeBordo.Application.Features.Products.Queries.GeSupplierProducts;

public class GetSupplierProductsQuery : IRequest<List<ProductViewModel>>
{
    public GetSupplierProductsQuery(Guid supplierId)
    {
        SupplierId = supplierId;
    }

    public Guid SupplierId { get; set; }
}
