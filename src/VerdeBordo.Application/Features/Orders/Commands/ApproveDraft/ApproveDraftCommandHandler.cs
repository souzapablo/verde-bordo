using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Orders.Commands.ApproveDraft;

public class ApproveDraftCommandHandler : IRequestHandler<ApproveDraftCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;

    public ApproveDraftCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;   
    }

    public async Task<Unit> Handle(ApproveDraftCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);

        if (order is null)
            throw new Exception("Order not found");
        
        order.ApproveDraft();

        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}