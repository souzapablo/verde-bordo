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

    public Guid PurchaseId { get; set; }
    public decimal? NewPurchasedAmount { get; set; }
    public decimal? NewShipment { get; set; }
    public DateTime? NewPurchaseDate { get; set; }
}
