using MediatR;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;

        public CreateProductCommandHandler(IProductRepository productRepository, ISupplierRepository supplierRepository)
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.SupplierId);

            if (supplier is null) 
                throw new Exception("Supplier not found");

            var product = new Product(supplier.Id, request.Description, request.Price);

            await _productRepository.CreateProductAsync(product);

            return product.Id;
        }
    }
}
