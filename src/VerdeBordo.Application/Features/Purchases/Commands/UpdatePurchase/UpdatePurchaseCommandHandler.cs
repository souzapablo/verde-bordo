using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Purchases.Commands.UpdatePurchase;

public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand, Unit>
{
    private readonly IPurchaseRepository _purchaseRepository;

    public UpdatePurchaseCommandHandler(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task<Unit> Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchase = await _purchaseRepository.GetByIdAsync(request.PurchaseId);

        if (purchase is null)
            throw new Exception("Purchase not found");

        purchase.UpdatePurchase(request.NewPurchasedAmount, request.NewShipment, request.NewPurchaseDate);

        await _purchaseRepository.UpdateAsync(purchase);

        return Unit.Value;
    }
}
