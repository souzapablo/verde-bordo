﻿namespace VerdeBordo.Core.Entities;

public class Purchase : BaseEntity
{
    public Purchase() { }

    public Purchase(Guid userId, Guid productId, decimal amountPurchased, decimal? shipment, DateTime purchaseDate)
    {
        UserId = userId;
        ProductId = productId;
        PurchasedAmount = amountPurchased;
        Shipment = shipment;
        PurchaseDate = purchaseDate;
    }

    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }
    public decimal PurchasedAmount { get; private set; }
    public decimal? Shipment { get; private set; }
    public DateTime PurchaseDate { get; private set; }

    public decimal GetTotalValue() => PurchasedAmount * Product.Price + Shipment.GetValueOrDefault();

    public void UpdatePurchase(decimal? newPurchasedAmount, decimal? newShipment, DateTime? newPurchaseDate)
    {
        if (newPurchasedAmount.HasValue)
            PurchasedAmount = newPurchasedAmount.Value;

        if ((newShipment is null && Shipment.HasValue) || newShipment.HasValue)
            Shipment = newShipment;
        
        if (newPurchaseDate.HasValue)
            PurchaseDate = newPurchaseDate.Value;

        Update();
    }

}
