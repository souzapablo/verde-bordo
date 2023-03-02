using VerdeBordo.Core.Enums;

namespace VerdeBordo.Application.InputModels.Orders;

public record CreateOrderInputModel(Guid CustomerId, DateTime DueDate, PaymentMethod PaymentMethod);