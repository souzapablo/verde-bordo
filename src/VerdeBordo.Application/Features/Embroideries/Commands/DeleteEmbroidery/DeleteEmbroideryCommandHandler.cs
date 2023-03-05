using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Embroideries.Commands.DeleteEmbroidery;

public class DeleteEmbroideryCommandHandler : IRequestHandler<DeleteEmbroideryCommand, Unit>
{
    private readonly IEmbroideryRepository _embroideryRepository;

    public DeleteEmbroideryCommandHandler(IEmbroideryRepository embroideryRepository)
    {
        _embroideryRepository = embroideryRepository;
    }

    public async Task<Unit> Handle(DeleteEmbroideryCommand request, CancellationToken cancellationToken)
    {
        var embroideiry = await _embroideryRepository.GetByIdAsync(request.Id);

        if (embroideiry is null)
            throw new Exception("Embroidery not found");
        
        embroideiry.Delete();

        await _embroideryRepository.UpdateAsync(embroideiry);

        return Unit.Value;
    }
}