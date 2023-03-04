namespace VerdeBordo.Application.InputModels.Payments;

public record CreatePaymentInputModel(decimal Amount, DateTime DueDate);