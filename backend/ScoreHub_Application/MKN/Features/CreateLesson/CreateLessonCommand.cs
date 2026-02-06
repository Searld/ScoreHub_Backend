using ScoreHub_Application.Abstractions;
using ScoreHub_Contracts.MKN;

namespace ScoreHub_Application.MKN.CreateLesson;

public record CreateLessonCommand(CreateLessonDto Dto) : ICommand;