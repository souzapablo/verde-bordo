using MediatR;

namespace VerdeBordo.Application.Features.Embroideries.Commands.DeleteEmbroidery;

public class DeleteEmbroideryCommand : IRequest<Unit>
{
    public DeleteEmbroideryCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }    
}