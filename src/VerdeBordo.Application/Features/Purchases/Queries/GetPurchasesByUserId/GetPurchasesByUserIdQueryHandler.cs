using MediatR;
using VerdeBordo.Application.ViewModels.Purchases;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Purchases.Queries.GetPurchasesByUserId;

public class GetPurchasesByUserIdQueryHandler : IRequestHandler<GetPurchasesByUserIdQuery, List<PurchaseViewModel>>
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IUserRepository _userRepository;

    public GetPurchasesByUserIdQueryHandler(IPurchaseRepository purchaseRepository, IUserRepository userRepository)
    {
        _purchaseRepository = purchaseRepository;
        _userRepository = userRepository;
    }
    
    public async Task<List<PurchaseViewModel>> Handle(GetPurchasesByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
            throw new Exception("User not found");
        
        var pruchases = await _purchaseRepository.GetByUserIdAsync(user.Id);

        return pruchases.Select(x => new PurchaseViewModel(x.Id, x.Product.Description, x.GetTotalValue(), x.PurchaseDate)).ToList();
    }
}