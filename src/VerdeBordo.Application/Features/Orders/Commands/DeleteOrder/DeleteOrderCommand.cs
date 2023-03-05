using MediatR;

namespace VerdeBordo.Application.Features.Orders.Commands.DeleteOrder;

public class DeleteOrderCommand : IRequest<Unit>
{
    public DeleteOrderCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}