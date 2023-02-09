using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, Unit>
    {
        private readonly ISupplierRepository _supplierRepository;

        public DeleteSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.Id);

            if (supplier is null)
                throw new Exception("Supplier not found");

            supplier.ToggleActiveStatus();

            await _supplierRepository.UpdateAsync(supplier);

            return Unit.Value;
        }
    }
}
