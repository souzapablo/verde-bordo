namespace VerdeBordo.Core.Entities;

public class Purchase : BaseEntity
{
    public Purchase() { }

    public Purchase(Guid productId, decimal amountPurchased, decimal? shipment, DateTime purchaseDate)
    {
        ProductId = productId;
        PurchasedAmount = amountPurchased;
        Shipment = shipment;
        PurchaseDate = purchaseDate;
    }

    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }
    public decimal PurchasedAmount { get; private set; }
    public decimal? Shipment { get; private set; }
    public DateTime PurchaseDate { get; private set; }

    public decimal GetTotalValue() => PurchasedAmount * Product.Price + Shipment.GetValueOrDefault();

    public void UpdatePurchasedAmount(decimal newPurchasedAmount)
    {
        PurchasedAmount = newPurchasedAmount;
        Update();
    }

    public void UpdateShipment(decimal newShipment)
    {
        Shipment = newShipment;
        Update();
    }

    public void UpdatePurchaseDate(DateTime newPurchaseDate)
    {
        PurchaseDate = newPurchaseDate;
        Update();
    }
}
