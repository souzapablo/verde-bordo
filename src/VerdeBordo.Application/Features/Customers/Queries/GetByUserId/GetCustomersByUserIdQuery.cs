using MediatR;
using VerdeBordo.Application.ViewModels.Customers;

namespace VerdeBordo.Application.Features.Customers.Queries.GetByUserId;

public class GetCustomersByUserIdQuery : IRequest<List<CustomerViewModel>>
{
    public GetCustomersByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; }
}