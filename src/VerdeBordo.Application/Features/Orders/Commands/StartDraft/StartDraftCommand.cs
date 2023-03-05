using MediatR;

namespace VerdeBordo.Application.Features.Orders.Commands.StartDraft;

public class StartDraftCommand : IRequest<Unit>
{
    public StartDraftCommand(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; }
}