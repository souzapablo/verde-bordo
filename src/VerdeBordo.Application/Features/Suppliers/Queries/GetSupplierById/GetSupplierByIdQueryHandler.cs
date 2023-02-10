using MediatR;
using VerdeBordo.Application.ViewModels.Suppliers;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Suppliers.Queries.GetSupplierById;

public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, SupplierDetailsViewModel>
{
    private readonly ISupplierRepository _supplierRepository;

    public GetSupplierByIdQueryHandler(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<SupplierDetailsViewModel> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.GetByIdAsync(request.Id);

        if (supplier is null)
            throw new Exception("Supplier not found");

        return new SupplierDetailsViewModel(supplier.Id, supplier.Name, supplier.Products);
    }
}
