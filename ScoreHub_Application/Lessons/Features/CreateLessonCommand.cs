using ScoreHub_Contracts.Lessons;
using ScoreHub_Infrastructure;

namespace ScoreHub_Application.Lessons.Features;

public record CreateLessonCommand(CreateLessonDto Dto) : ICommand;
