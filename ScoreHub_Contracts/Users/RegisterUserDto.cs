using LessonMkn.Enums;

namespace ScoreHub_Contracts.Users;

public record RegisterUserDto(
    string Name, string Email, string Password, Role Role, string? GroupNumber);