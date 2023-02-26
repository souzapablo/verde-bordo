using MediatR;

namespace VerdeBordo.Application.Features.Purchases.Commands.UpdatePurchase;

public class UpdatePurchaseCommand : IRequest<Unit>
{
    public UpdatePurchaseCommand(Guid purchaseId, decimal? newAmountPurchased, decimal? newShipment, DateTime? newPurchaseDate)
    {
        PurchaseId = purchaseId;
        NewPurchasedAmount = newAmountPurchased;
        NewShipment = newShipment;
        NewPurchaseDate = newPurchaseDate;
    }

    public Guid PurchaseId { get; }
    public decimal? NewPurchasedAmount { get; }
    public decimal? NewShipment { get; }
    public DateTime? NewPurchaseDate { get; }
}
