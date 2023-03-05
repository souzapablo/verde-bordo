using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Orders.Commands.ReproveDraft;

public class ReproveDraftCommandHandler : IRequestHandler<ReproveDraftCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;

    public ReproveDraftCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;   
    }

    public async Task<Unit> Handle(ReproveDraftCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);

        if (order is null)
            throw new Exception("Order not found");
        
        order.ReproveDraft();

        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}