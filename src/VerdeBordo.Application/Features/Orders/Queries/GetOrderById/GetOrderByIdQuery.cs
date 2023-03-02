using MediatR;
using VerdeBordo.Application.ViewModels.Orders;

namespace VerdeBordo.Application.Features.Orders.Queries.GetOrderById;

public class GetOrderByIdQuery : IRequest<OrderDetailsViewModel>
{
    public GetOrderByIdQuery(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; }
}