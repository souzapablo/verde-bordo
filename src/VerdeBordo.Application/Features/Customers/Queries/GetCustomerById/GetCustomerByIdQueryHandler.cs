using MediatR;
using VerdeBordo.Application.ViewModels.Customers;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDetailsViewModel>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDetailsViewModel> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);

        if (customer is null)
            throw new Exception("Customer not found");

        return new CustomerDetailsViewModel(customer.Id, customer.Name, customer.Contact);
    }
}
