using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Unit>
    {
        private readonly ISupplierRepository _supplierRepository;

        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.Id);

            if (supplier is null)
                throw new Exception("Supplier not found");

            supplier.UpdateName(request.NewName);

            await _supplierRepository.UpdateSupplier(supplier);

            return Unit.Value;
        }
    }
}
