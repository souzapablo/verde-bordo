using MediatR;
using VerdeBordo.Application.ViewModels.Embroideries;
using VerdeBordo.Application.ViewModels.Orders;
using VerdeBordo.Core.Extensions;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDetailsViewModel>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderDetailsViewModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {   
        var order = await _orderRepository.GetByIdAsync(request.Id, x => x.Customer, x => x.Embroideries, x => x.Payments);

        if (order is null)
            throw new Exception("Order not found");

        var embroideriesViewModels = order.Embroideries.Select(x => new EmbroideryViewModel(x.Id, x.Description, x.Price)).ToList();
        
        return new OrderDetailsViewModel(
            order.Id, 
            order.CustomerId,
            order.Customer.Name,
            embroideriesViewModels,
            order.DueDate,
            order.Shipment,
            order.PaymentMethod.GetDescription(),
            order.Payments.Count,
            order.GetTotalValue(),
            order.Status.GetDescription());
    }
}