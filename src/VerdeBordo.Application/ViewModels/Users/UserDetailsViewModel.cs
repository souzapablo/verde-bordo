namespace VerdeBordo.Application.ViewModels.Users;

public record UserDetailsViewModel(Guid id, string FirstName, string LastName, string Username, string Email, string Role);