namespace ScoreHub_Contracts.MKN;

public record CreateLessonDto(
    List<Guid> StudentIds,
    int LessonNumber,
    string? ReasonForAbsence,
    Guid TeacherId
    
    );