using ScoreHub_Domain.Enums;

namespace ScoreHub_Contracts.Users;

public record GetUserResponse(Guid Id, string Email, string Name, Role Role);