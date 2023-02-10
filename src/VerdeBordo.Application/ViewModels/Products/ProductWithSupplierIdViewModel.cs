namespace VerdeBordo.Application.ViewModels.Products;

public record ProductWithSupplierIdViewModel(string SupplierName, Guid ProductId, string Description, decimal Price);
