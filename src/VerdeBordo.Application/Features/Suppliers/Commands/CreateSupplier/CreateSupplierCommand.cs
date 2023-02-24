using MediatR;

namespace VerdeBordo.Application.Features.Suppliers.Commands.CreateSupplier;

public class CreateSupplierCommand : IRequest<Guid>
{
    public CreateSupplierCommand(Guid userId, string name)
    {
        UserId = userId;
        Name = name;
    }

    public Guid UserId { get; }
    public string Name { get; }
}
