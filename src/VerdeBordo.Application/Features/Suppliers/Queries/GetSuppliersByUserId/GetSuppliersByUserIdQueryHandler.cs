using MediatR;
using VerdeBordo.Application.ViewModels.Suppliers;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Suppliers.Queries.GetSuppliersByUserId;

public class GetSuppliersByUserIdQueryHandler : IRequestHandler<GetSuppliersByUserIdQuery, List<SupplierViewModel>>
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUserRepository _userRepoistory;

    public GetSuppliersByUserIdQueryHandler(ISupplierRepository supplierRepository, IUserRepository userRepository)
    {
        _supplierRepository = supplierRepository;
        _userRepoistory = userRepository;   
    }

    public async Task<List<SupplierViewModel>> Handle(GetSuppliersByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepoistory.GetByIdAsync(request.UserId);

        if (user is null)
            throw new Exception("User not found");

        var suppliers = await _supplierRepository.GetByUserIdAsync(user.Id);

        return suppliers.Select(x => new SupplierViewModel(x.Id, x.Name)).ToList();
    }
}