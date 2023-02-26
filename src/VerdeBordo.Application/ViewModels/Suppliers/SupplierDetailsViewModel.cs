using VerdeBordo.Application.ViewModels.Products;

namespace VerdeBordo.Application.ViewModels.Suppliers;

public record SupplierDetailsViewModel(Guid Id, string Name, List<ProductViewModel> Products);
