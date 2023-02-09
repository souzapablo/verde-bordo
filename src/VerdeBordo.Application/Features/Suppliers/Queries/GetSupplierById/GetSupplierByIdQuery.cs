using MediatR;
using VerdeBordo.Application.ViewModels.Suppliers;

namespace VerdeBordo.Application.Features.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQuery : IRequest<SupplierDetailsViewModel>
    {
        public GetSupplierByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
