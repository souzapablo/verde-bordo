using MediatR;

namespace VerdeBordo.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<Guid>
{
    public CreateProductCommand(Guid supplierId, string description, decimal price)
    {
        SupplierId = supplierId;
        Description = description;
        Price = price;
    }

    public Guid SupplierId { get; }
    public string Description { get; }
    public decimal Price { get; }
}
