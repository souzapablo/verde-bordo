using MediatR;

namespace VerdeBordo.Application.Features.Payments.Commands;

public class CreatePaymentCommand : IRequest<Guid>
{
    public CreatePaymentCommand(Guid orderId, decimal amount, DateTime dueDate)
    {
        OrderId = orderId;
        Amount = amount;
        DueDate = dueDate;
    }

    public Guid OrderId { get; }
    public decimal Amount { get; }
    public DateTime DueDate { get; }
}