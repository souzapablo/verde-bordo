using MediatR;

namespace VerdeBordo.Application.Features.Suppliers.Commands.CreateSupplier;

public class CreateSupplierCommand : IRequest<Guid>
{
    public CreateSupplierCommand(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
