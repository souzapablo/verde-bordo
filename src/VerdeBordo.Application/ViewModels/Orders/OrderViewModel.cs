using VerdeBordo.Core.Enums;

namespace VerdeBordo.Application.ViewModels.Orders;

public record OrderViewModel(Guid id, string CustomerName, string EmbroideryDescription, DateTime DueDate, OrderStatus Status);