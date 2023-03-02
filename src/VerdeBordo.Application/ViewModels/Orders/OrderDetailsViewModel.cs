namespace VerdeBordo.Application.ViewModels.Orders;

public record OrderDetailsViewModel(Guid id, Guid customerId, string CustomerName, Guid EmbroideryId, string EmbroideryDescription, decimal Price, DateTime DueDate, decimal? shipment, string PaymentMethod, int Payments, decimal TotalValue, string Status);