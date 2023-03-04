using VerdeBordo.Application.ViewModels.Embroideries;

namespace VerdeBordo.Application.ViewModels.Orders;

public record OrderDetailsViewModel(Guid Id, Guid CustomerId, string CustomerName, 
List<EmbroideryViewModel> Embroideries, DateTime DueDate, decimal? shipment, 
string PaymentMethod, int Payments, decimal TotalValue, string Status);