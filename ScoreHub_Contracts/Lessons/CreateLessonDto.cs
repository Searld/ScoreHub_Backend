using LessonMkn.Enums;

namespace ScoreHub_Contracts.Lessons;

public record CreateLessonDto(
    string Name,
    LessonStatus Status, 
    DateTime StartAt, 
    bool IsCommandLesson, 
    List<TeamDto>? Teams,
    Guid SubjectId,
    List<Guid> StudentIds);