using MediatR;
using VerdeBordo.Application.ViewModels.Customers;

namespace VerdeBordo.Application.Features.Customers.Queries.GetCustomers;

public class GetCustomersQuery : IRequest<List<CustomerViewModel>>
{
}
