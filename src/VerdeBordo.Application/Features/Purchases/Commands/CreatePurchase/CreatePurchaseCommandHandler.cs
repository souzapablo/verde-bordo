using MediatR;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Purchases.Commands.CreatePurchase;

public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, Guid>
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;

    public CreatePurchaseCommandHandler(IPurchaseRepository purchaseRepository, IProductRepository productRepository,
        IUserRepository userRepository)
    {
        _purchaseRepository = purchaseRepository;
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
            throw new Exception("User not found");

        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product is null)
            throw new Exception("Product not found");

        var purchase = new Purchase(user.Id, product.Id, request.AmountPurchased, request.Shipment, request.PurchaseDate);

        await _purchaseRepository.CreateAsync(purchase);

        return purchase.Id;
    }
}
