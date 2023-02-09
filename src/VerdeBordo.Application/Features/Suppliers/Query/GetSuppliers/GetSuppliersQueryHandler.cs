using MediatR;
using VerdeBordo.Application.ViewModels.Suppliers;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Suppliers.Query.GetSuppliers
{
    public class GetSuppliersQueryHandler : IRequestHandler<GetSuppliersQuery, List<SupplierViewModel>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetSuppliersQueryHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<List<SupplierViewModel>> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.GetSuppliersAsync();

            return suppliers.Select(s => new SupplierViewModel
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
        }
    }
}
