using ScoreHub_Domain.Entities;

namespace ScoreHub_Contracts;

public record GetSubjectResponse(Guid Id, string Name, List<Guid> Lessons);