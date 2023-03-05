using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Orders.Commands.CompleteFinishing;

public class CompleteFinishingCommandHandler : IRequestHandler<CompleteFinishingCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;

    public CompleteFinishingCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(CompleteFinishingCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);

        if (order is null)
            throw new Exception("Order not found");
        
        order.CompleteFinishing();

        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}