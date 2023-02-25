using VerdeBordo.Core.Enums;

namespace VerdeBordo.Application.InputModels.Users;

public record CreateUserInputModel(string FirstName, string LastName, string Username, string Email, string Password, Role Role);