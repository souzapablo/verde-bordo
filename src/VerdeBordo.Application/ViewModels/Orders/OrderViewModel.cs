using VerdeBordo.Core.Enums;

namespace VerdeBordo.Application.ViewModels.Orders;

public record OrderViewModel(Guid id, string CustomerName, List<string> EmbroideriesDescription, DateTime DueDate, string Status);