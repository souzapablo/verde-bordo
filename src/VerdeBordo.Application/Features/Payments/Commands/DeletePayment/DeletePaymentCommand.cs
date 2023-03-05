using MediatR;

namespace VerdeBordo.Application.Features.Payments.Commands.DeletePayment;

public class DeletePaymentCommand : IRequest<Unit>
{
    public DeletePaymentCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}