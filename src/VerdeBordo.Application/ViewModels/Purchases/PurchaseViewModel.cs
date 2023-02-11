namespace VerdeBordo.Application.ViewModels.Purchases;

public record PurchaseViewModel(Guid Id, string ProductDescription, decimal TotalValue, DateTime PurchaseDate);
