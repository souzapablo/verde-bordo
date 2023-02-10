using MediatR;
using VerdeBordo.Application.ViewModels.Purchases;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Purchases.Queries.GetPurchaseById
{
    public class GetPurchaseByIdQueryHandler : IRequestHandler<GetPurchaseByIdQuery, PurchaseDetailsViewModel>
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public GetPurchaseByIdQueryHandler(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<PurchaseDetailsViewModel> Handle(GetPurchaseByIdQuery request, CancellationToken cancellationToken)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(request.Id);

            if (purchase is null)
                throw new Exception("Purchase not found");

            return new PurchaseDetailsViewModel(purchase.Id, purchase.Product.Description, purchase.AmountPurchased, purchase.GetTotalValue(), purchase.Shipment, purchase.PurchaseDate);
        }
    }
}
