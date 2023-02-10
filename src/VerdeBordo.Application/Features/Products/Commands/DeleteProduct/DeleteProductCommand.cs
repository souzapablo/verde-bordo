using MediatR;

namespace VerdeBordo.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<Unit>
{
    public DeleteProductCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
