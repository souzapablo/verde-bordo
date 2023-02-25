using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);

        if (customer is null)
            throw new Exception("Customer not found");

        customer.Delete();

        await _customerRepository.UpdateAsync(customer);

        return Unit.Value;
    }
}
