using MediatR;

namespace VerdeBordo.Application.Features.Purchases.Commands.CreatePurchase;

public class CreatePurchaseCommand : IRequest<Guid>
{
    public CreatePurchaseCommand(Guid userId, Guid productId, decimal purchasedAmount, DateTime purchaseDate, decimal? shipment)
    {
        UserId = userId;
        ProductId = productId;
        PurchasedAmount = purchasedAmount;
        PurchaseDate = purchaseDate;
        Shipment = shipment;
    }

    public Guid UserId { get; }
    public Guid ProductId { get; }
    public decimal PurchasedAmount { get; }
    public DateTime PurchaseDate { get; }
    public decimal? Shipment { get; }
}
