using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Orders.Commands.StartDraft;

public class StartDraftCommandHandler : IRequestHandler<StartDraftCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;

    public StartDraftCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(StartDraftCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);

        if (order is null)
            throw new Exception("Order not found");
        
        order.StartDraft();

        await _orderRepository.UpdateAsync(order);
        
        return Unit.Value;
    }
}