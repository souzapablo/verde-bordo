using MediatR;

namespace VerdeBordo.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand : IRequest<Guid>
{
    public CreateCustomerCommand(Guid userId, string name, string contact)
    {
        UserId = userId;
        Name = name;
        Contact = contact;
    }
    
    public Guid UserId { get; }
    public string Name { get; }
    public string Contact { get; }
}
