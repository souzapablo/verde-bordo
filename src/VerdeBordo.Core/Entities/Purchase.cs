namespace VerdeBordo.Core.Entities;

public class Purchase : BaseEntity
{
    public Purchase(Guid productId, decimal amountPurchased, decimal? shipment, DateTime purchaseDate)
    {
        ProductId = productId;
        AmountPurchased = amountPurchased;
        Shipment = shipment;
        PurchaseDate = purchaseDate;
    }

    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }
    public decimal AmountPurchased { get; private set; }
    public decimal? Shipment { get; private set; }
    public DateTime PurchaseDate { get; private set; }
    public decimal GetTotalValue() => AmountPurchased * Product.Price - Shipment.GetValueOrDefault();
}
