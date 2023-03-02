using MediatR;
using VerdeBordo.Application.ViewModels.Orders;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Orders.Queries.GetOrders;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderViewModel>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<OrderViewModel>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAllAsync(x => x.Customer, x => x.Embroidery);

        return orders.Select(x => new OrderViewModel(x.Id, x.Customer.Name, x.Embroidery.Description, x.DueDate, x.Status)).ToList();
    }
}