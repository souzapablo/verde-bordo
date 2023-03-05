using MediatR;

namespace VerdeBordo.Application.Features.Orders.Commands.Deliver;

public class DeliverCommand : IRequest<Unit>
{
    public DeliverCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}