using MediatR;

namespace VerdeBordo.Application.Features.Suppliers.Commands.UpdateSupplier;

public class UpdateSupplierCommand : IRequest<Unit>
{
    public UpdateSupplierCommand(Guid id, string newName)
    {
        Id = id;
        NewName = newName;
    }

    public Guid Id { get; }
    public string NewName { get; }
}
