using MediatR;

namespace VerdeBordo.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<Unit>
{
    public UpdateProductCommand(Guid id, decimal newPrice)
    {
        Id = id;
        NewPrice = newPrice;
    }

    public Guid Id { get; set; }
    public decimal NewPrice { get; set; }
}
