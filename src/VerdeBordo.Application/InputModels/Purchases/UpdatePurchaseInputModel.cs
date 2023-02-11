namespace VerdeBordo.Application.InputModels.Purchases;

public record UpdatePurchaseInputModel(decimal? NewPurchasedAmount, decimal? NewShipment, DateTime? NewPurchaseDate);
