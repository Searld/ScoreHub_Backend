using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Enums;

namespace ScoreHub_Contracts;

public record CreateLessonRequest(
    Guid SubjectId, string Name, DateTime StartTime,
    bool IsCommandLesson,  LessonStatus Status, List<TeamRequest>? Teams = null, 
    List<Guid>? Students = null);