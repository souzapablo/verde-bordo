using VerdeBordo.Core.Entities;

namespace VerdeBordo.Application.ViewModels.Suppliers
{
    public record SupplierDetailsViewModel(Guid Id, List<Product> Products);
}
