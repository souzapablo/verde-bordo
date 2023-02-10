using MediatR;
using VerdeBordo.Application.ViewModels.Products;

namespace VerdeBordo.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDetailsViewModel>
    {
        public GetProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; }
    }
}
