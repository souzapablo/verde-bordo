using MediatR;
using VerdeBordo.Application.ViewModels.Customers;

namespace VerdeBordo.Application.Features.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQuery : IRequest<CustomerDetailsViewModel>
{
    public GetCustomerByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}
