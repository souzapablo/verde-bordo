namespace VerdeBordo.Application.InputModels.Purchases;

public record CreatePurchaseInputModel(Guid ProductId, decimal AmountPurchased, DateTime PurchaseDate, decimal? Shipment = null);
