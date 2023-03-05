using MediatR;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Embroideries.Commands.CreateEmbroideiry;

public class CreateEmbroideryCommandHandler : IRequestHandler<CreateEmbroideryCommand, Guid>
{
    private readonly IEmbroideryRepository _embroideryRepository;
    private readonly IOrderRepository _orderRepository;

    public CreateEmbroideryCommandHandler(IEmbroideryRepository embroideryRepository, IOrderRepository orderRepository)
    {
        _embroideryRepository = embroideryRepository;
        _orderRepository = orderRepository;
    }

    public async Task<Guid> Handle(CreateEmbroideryCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);

        if (order is null)
            throw new Exception("Order not found");
        
        var embroideiry = new Embroidery(order.Id, request.Description, request.Details, request.Size, request.Price, request.HasFrame);

        await _embroideryRepository.CreateAsync(embroideiry);

        return order.Id;
    }
}