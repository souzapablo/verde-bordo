namespace VerdeBordo.Application.ViewModels.Payments;

public record PaymentViewModel(Guid Id, decimal Amount, DateTime DueDate, DateTime? PaymentDate);