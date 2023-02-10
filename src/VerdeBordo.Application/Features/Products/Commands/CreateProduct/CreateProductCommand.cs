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

    public Guid SupplierId { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
