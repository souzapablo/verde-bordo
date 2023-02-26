using MediatR;

namespace VerdeBordo.Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<Unit>
{
    public UpdateCustomerCommand(Guid id, string newContact)
    {
        Id = id;
        NewContact = newContact;
    }

    public Guid Id { get; }
    public string NewContact { get; }
}
