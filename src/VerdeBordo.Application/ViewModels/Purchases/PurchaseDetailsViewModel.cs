namespace VerdeBordo.Application.ViewModels.Purchases
{
    public record PurchaseDetailsViewModel(Guid PurchaseId, string ProductDescription, decimal PurchasedAmount, decimal TotalValue, decimal? Shipment, DateTime PurchaseDate);
}
