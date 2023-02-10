using VerdeBordo.Core.Entities;

namespace VerdeBordo.Application.ViewModels.Suppliers;

public record SupplierDetailsViewModel(Guid Id, string Name, List<Product> Products);
