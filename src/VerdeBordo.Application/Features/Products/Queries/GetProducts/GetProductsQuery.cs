using MediatR;
using VerdeBordo.Application.ViewModels.Products;

namespace VerdeBordo.Application.Features.Products.Queries.GetProducts;

public class GetProductsQuery : IRequest<List<ProductWithSupplierIdViewModel>>
{
}
