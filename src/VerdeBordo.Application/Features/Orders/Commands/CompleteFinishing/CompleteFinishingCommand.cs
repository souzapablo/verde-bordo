using MediatR;

namespace VerdeBordo.Application.Features.Orders.Commands.CompleteFinishing;

public class CompleteFinishingCommand : IRequest<Unit>
{
    public CompleteFinishingCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}