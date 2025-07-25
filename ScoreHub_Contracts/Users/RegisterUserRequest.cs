using ScoreHub_Domain.Enums;

namespace ScoreHub_Contracts.Users;

public record RegisterUserRequest(
    string Name, string Email, string Password, Role Role, string GroupNumber);