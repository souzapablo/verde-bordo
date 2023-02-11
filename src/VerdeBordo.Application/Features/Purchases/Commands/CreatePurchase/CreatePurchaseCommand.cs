using MediatR;

namespace VerdeBordo.Application.Features.Purchases.Commands.CreatePurchase;

public class CreatePurchaseCommand : IRequest<Guid>
{
    public CreatePurchaseCommand(Guid productId, decimal amountPurchased, DateTime purchaseDate, decimal? shipment)
    {
        ProductId = productId;
        AmountPurchased = amountPurchased;
        PurchaseDate = purchaseDate;
        Shipment = shipment;
    }

    public Guid ProductId { get; }
    public decimal AmountPurchased { get; }
    public DateTime PurchaseDate { get; }
    public decimal? Shipment { get; }
}
