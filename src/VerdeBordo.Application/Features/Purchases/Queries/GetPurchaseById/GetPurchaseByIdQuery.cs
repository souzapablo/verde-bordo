using MediatR;
using VerdeBordo.Application.ViewModels.Purchases;

namespace VerdeBordo.Application.Features.Purchases.Queries.GetPurchaseById;

public class GetPurchaseByIdQuery : IRequest<PurchaseDetailsViewModel>
{
    public GetPurchaseByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
