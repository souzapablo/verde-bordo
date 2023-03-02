using MediatR;
using VerdeBordo.Core.Enums;

namespace VerdeBordo.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<Guid>
{
    public CreateOrderCommand(Guid customerId, DateTime dueDate, PaymentMethod paymentMethod)
    {
        CustomerId = customerId;
        DueDate = dueDate;
        PaymentMethod = paymentMethod;
    }

    public Guid CustomerId { get; }
    public DateTime DueDate { get; }
    public PaymentMethod PaymentMethod { get; }
}