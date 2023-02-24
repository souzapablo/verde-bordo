using MediatR;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUserRepository _userRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUserRepository userRepository)
    {
        _customerRepository = customerRepository;
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
            throw new Exception("User not found");

        var customer = new Customer(user.Id, request.Name, request.Contact);

        await _customerRepository.CreateAsync(customer);

        return customer.Id;
    }
}
