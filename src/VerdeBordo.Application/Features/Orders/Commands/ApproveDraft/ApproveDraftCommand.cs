using MediatR;

namespace VerdeBordo.Application.Features.Orders.Commands.ApproveDraft
{
    public class ApproveDraftCommand : IRequest<Unit>
    {
        public ApproveDraftCommand(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; }
    }
}