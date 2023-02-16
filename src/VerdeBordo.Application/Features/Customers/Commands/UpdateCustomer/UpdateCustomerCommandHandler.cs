using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);

        if (customer is null)
            throw new Exception("Customer not found");

        customer.UpdateContact(request.NewContact);

        await _customerRepository.UpdateAsync(customer);

        return Unit.Value;
    }
}
