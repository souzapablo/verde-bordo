using MediatR;

namespace VerdeBordo.Application.Features.Suppliers.Commands.DeleteSupplier;

public class DeleteSupplierCommand : IRequest<Unit>
{
    public DeleteSupplierCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
