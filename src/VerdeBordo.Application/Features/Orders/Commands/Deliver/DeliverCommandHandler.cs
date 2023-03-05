using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Orders.Commands.Deliver;

public class DeliverCommandHandler : IRequestHandler<DeliverCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;

    public DeliverCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(DeliverCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);

        if (order is null)
            throw new Exception("Order not found");
        
        order.Deliver();

        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}