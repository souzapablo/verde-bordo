using MediatR;
using VerdeBordo.Application.ViewModels.Suppliers;

namespace VerdeBordo.Application.Features.Suppliers.Queries.GetSuppliersByUserId;

public class GetSuppliersByUserIdQuery : IRequest<List<SupplierViewModel>>
{
    public GetSuppliersByUserIdQuery(Guid userId)
    {
        UserId = userId;    
    }

    public Guid UserId { get; }
}