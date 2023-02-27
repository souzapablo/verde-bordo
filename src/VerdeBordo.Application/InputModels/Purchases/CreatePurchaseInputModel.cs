namespace VerdeBordo.Application.InputModels.Purchases;

public record CreatePurchaseInputModel(Guid UserId, Guid ProductId, decimal PurchasedAmount, DateTime PurchaseDate, decimal? Shipment = null);
