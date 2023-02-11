using MediatR;
using VerdeBordo.Application.ViewModels.Purchases;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Purchases.Queries.GetPurchases;

public class GetPurchasesQueryHandler : IRequestHandler<GetPurchasesQuery, List<PurchaseViewModel>>
{
    private readonly IPurchaseRepository _purchaseRepository;

    public GetPurchasesQueryHandler(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task<List<PurchaseViewModel>> Handle(GetPurchasesQuery request, CancellationToken cancellationToken)
    {
        var purchases = await _purchaseRepository.GetAllAsync();

        return purchases.Select(x => new PurchaseViewModel(x.Id, x.Product.Description, x.GetTotalValue(), x.PurchaseDate)).ToList();
    }
}
