using MediatR;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Suppliers.Commands.CreateSupplier;

public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Guid>
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUserRepository _userRepository;

    public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, IUserRepository userRepository)
    {
        _supplierRepository = supplierRepository;
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
            throw new Exception("User not found");

        var supplier = new Supplier(user.Id, request.Name);

        await _supplierRepository.CreateAsync(supplier);

        return supplier.Id;
    }
}
