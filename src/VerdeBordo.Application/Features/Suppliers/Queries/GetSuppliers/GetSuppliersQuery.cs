using MediatR;
using VerdeBordo.Application.ViewModels.Suppliers;

namespace VerdeBordo.Application.Features.Suppliers.Queries.GetSuppliers
{
    public class GetSuppliersQuery : IRequest<List<SupplierViewModel>>
    {
    }
}
