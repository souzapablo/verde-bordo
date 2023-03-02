using MediatR;
using VerdeBordo.Application.ViewModels.Orders;

namespace VerdeBordo.Application.Features.Orders.Queries.GetOrders;

public class GetOrdersQuery : IRequest<List<OrderViewModel>>
{
    
}