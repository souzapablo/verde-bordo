using MediatR;

namespace VerdeBordo.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand : IRequest<Guid>
{
    public CreateCustomerCommand(string name, string contact)
    {
        Name = name;
        Contact = contact;
    }

    public string Name { get; set; }
    public string Contact { get; set; }
}
