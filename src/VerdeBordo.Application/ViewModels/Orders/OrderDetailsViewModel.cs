using VerdeBordo.Application.ViewModels.Embroideries;
using VerdeBordo.Application.ViewModels.Payments;

namespace VerdeBordo.Application.ViewModels.Orders;

public record OrderDetailsViewModel(Guid Id, Guid CustomerId, string CustomerName, 
List<EmbroideryViewModel> Embroideries, DateTime DueDate, decimal? shipment, 
string PaymentMethod, List<PaymentViewModel> Payments, decimal TotalValue, string Status);