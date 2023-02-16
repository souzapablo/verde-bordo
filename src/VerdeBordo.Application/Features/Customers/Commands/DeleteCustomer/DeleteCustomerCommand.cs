using MediatR;

namespace VerdeBordo.Application.Features.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<Unit>
{
    public DeleteCustomerCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
