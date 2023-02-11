using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Purchases.Commands.DeletePurchase
{
    public class DeletePurchaseCommandHandler : IRequestHandler<DeletePurchaseCommand, Unit>
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public DeletePurchaseCommandHandler(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<Unit> Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(request.Id);

            if (purchase is null)
                throw new Exception("Purchase not found");

            purchase.ToggleActiveStatus();

            await _purchaseRepository.UpdateAsync(purchase);

            return Unit.Value;
        }
    }
}
