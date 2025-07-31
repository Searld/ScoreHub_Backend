using ScoreHub_Domain.Entities;

namespace ScoreHub_Contracts.Users;

public record GetTeacherResponse(GetUserResponse User, List<Subject> Subjects);