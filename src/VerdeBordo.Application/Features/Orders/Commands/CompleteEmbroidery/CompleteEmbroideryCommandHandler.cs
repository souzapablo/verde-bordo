using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Orders.Commands.CompleteEmbroidery;

public class CompleteEmbroideryCommandHandler : IRequestHandler<CompleteEmbroideryCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;

    public CompleteEmbroideryCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(CompleteEmbroideryCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);

        if (order is null)
            throw new Exception("Order not found");
        
        order.CompleteEmbroidery();

        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}