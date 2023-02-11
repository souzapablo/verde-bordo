using MediatR;

namespace VerdeBordo.Application.Features.Purchases.Commands.DeletePurchase
{
    public class DeletePurchaseCommand : IRequest<Unit>
    {
        public DeletePurchaseCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
