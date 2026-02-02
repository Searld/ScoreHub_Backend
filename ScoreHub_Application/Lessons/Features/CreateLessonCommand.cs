using ScoreHub_Application.Abstractions;
using ScoreHub_Contracts.Lessons;

namespace ScoreHub_Application.Lessons.Features;

public record CreateLessonCommand(CreateLessonDto Dto) : ICommand;
