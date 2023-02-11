using MediatR;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Purchases.Commands.CreatePurchase;

public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, Guid>
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IProductRepository _productRepository;

    public CreatePurchaseCommandHandler(IPurchaseRepository purchaseRepository, IProductRepository productRepository)
    {
        _purchaseRepository = purchaseRepository;
        _productRepository = productRepository;
    }

    public async Task<Guid> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product is null)
            throw new Exception("Product not found");

        var purchase = new Purchase(product.Id, request.AmountPurchased, request.Shipment, request.PurchaseDate);

        await _purchaseRepository.CreateAsync(purchase);

        return purchase.Id;
    }
}
