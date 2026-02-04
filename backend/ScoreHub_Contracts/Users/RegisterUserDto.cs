using ScoreHub_Domain.Enums;

namespace ScoreHub_Contracts.Users;

public record RegisterUserDto(
    string Name, string Surname, string? Patronymic, string Email, string Password, string? GroupNumber);