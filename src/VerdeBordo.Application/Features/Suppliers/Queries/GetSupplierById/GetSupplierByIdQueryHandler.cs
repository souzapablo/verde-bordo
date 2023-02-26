using MediatR;
using VerdeBordo.Application.ViewModels.Products;
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
        var supplier = await _supplierRepository.GetByIdAsync(request.Id, x => x.Products);

        if (supplier is null)
            throw new Exception("Supplier not found");

        var productsViewModels = supplier.Products.Select(x => new ProductViewModel(x.Id, x.Description, x.Price));

        return new SupplierDetailsViewModel(supplier.Id, supplier.Name, productsViewModels.ToList());
    }
}
