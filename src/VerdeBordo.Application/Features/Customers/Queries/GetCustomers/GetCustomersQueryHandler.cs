using MediatR;
using VerdeBordo.Application.ViewModels.Customers;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Customers.Queries.GetCustomers;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerViewModel>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<CustomerViewModel>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAllAsync();

        return customers.Select(x => new CustomerViewModel(x.Id, x.Name)).ToList();
    }
}
