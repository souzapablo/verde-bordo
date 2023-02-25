using MediatR;
using VerdeBordo.Application.ViewModels.Purchases;

namespace VerdeBordo.Application.Features.Purchases.Queries.GetPurchasesByUserId;

public class GetPurchasesByUserIdQuery : IRequest<List<PurchaseViewModel>>
{
    public GetPurchasesByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; }    
}