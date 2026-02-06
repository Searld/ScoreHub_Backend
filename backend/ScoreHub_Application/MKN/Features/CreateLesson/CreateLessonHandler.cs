using ScoreHub_Application.Abstractions;
using ScoreHub_Domain.Entities.MKN;
using ScoreHub_Domain.Enums;

namespace ScoreHub_Application.MKN.CreateLesson;

public class CreateLessonHandler : ICommandHandler<CreateLessonCommand>
{
    public CreateLessonHandler()
    {
        
    }

    public Task Handle(CreateLessonCommand command)
    {
        var lesson = new LessonMkn()
        {
            IsStudentAttended = false,
            LessonNumber = command.Dto.LessonNumber,
            ReasonForAbsence = command.Dto.ReasonForAbsence,
            Status = LessonStatus.InProgress
        };
        
        
        
    }
}