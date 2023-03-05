using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Orders.Commands.CompleteDraft;

public class CompleteDraftCommandHandler : IRequestHandler<CompleteDraftCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;

    public CompleteDraftCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(CompleteDraftCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);

        if (order is null)
            throw new Exception("Order not found");
        
        order.CompleteDraft();

        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}