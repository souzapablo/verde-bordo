using MediatR;
using VerdeBordo.Application.ViewModels.Customers;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Customers.Queries.GetByUserId;

public class GetCustomersByUserIdQueryHandler : IRequestHandler<GetCustomersByUserIdQuery, List<CustomerViewModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _customerRepository;

    public GetCustomersByUserIdQueryHandler(IUserRepository userRepository, ICustomerRepository customerRepository)
    {
        _userRepository = userRepository;
        _customerRepository = customerRepository;
    }
    
    public async Task<List<CustomerViewModel>> Handle(GetCustomersByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
            throw new Exception("User not found");

        var customers = await _customerRepository.GetByUserIdAsync(request.UserId);

        return customers.Select(x => new CustomerViewModel(x.Id, x.Name)).ToList();
    }
}