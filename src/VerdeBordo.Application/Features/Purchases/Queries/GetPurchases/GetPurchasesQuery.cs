using MediatR;
using VerdeBordo.Application.ViewModels.Purchases;

namespace VerdeBordo.Application.Features.Purchases.Queries.GetPurchases;

public class GetPurchasesQuery : IRequest<List<PurchaseViewModel>>
{
}
