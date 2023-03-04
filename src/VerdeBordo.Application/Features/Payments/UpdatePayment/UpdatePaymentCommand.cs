using MediatR;

namespace VerdeBordo.Application.Features.Payments.UpdatePayment;

public class UpdatePaymentCommand : IRequest<Unit>
{
    public UpdatePaymentCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}