using MediatR;

namespace VerdeBordo.Application.Features.Orders.Commands.ReproveDraft;

public class ReproveDraftCommand : IRequest<Unit>
{
    public ReproveDraftCommand(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; }
}