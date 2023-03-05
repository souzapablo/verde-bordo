using MediatR;

namespace VerdeBordo.Application.Features.Orders.Commands.CompleteDraft;

public class CompleteDraftCommand : IRequest<Unit>
{
    public CompleteDraftCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}