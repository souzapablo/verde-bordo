using MediatR;

namespace VerdeBordo.Application.Features.Orders.Commands.CompleteEmbroidery;

public class CompleteEmbroideryCommand : IRequest<Unit>
{
    public CompleteEmbroideryCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}