namespace VerdeBordo.Application.InputModels.Customers;

public record CreateCustomerInputModel(Guid UserId, string Name, string Contact);
