using ScoreHub_Application.Abstractions;
using ScoreHub_Domain.Entities.MKN;
using ScoreHub_Domain.Enums;

namespace ScoreHub_Application.MKN.CreateLesson;

public class CreateLessonHandler : ICommandHandler<CreateLessonCommand>
{
    private readonly ILessonsRepository _lessonsRepository;

    public CreateLessonHandler(ILessonsRepository lessonsRepository)
    {
        _lessonsRepository = lessonsRepository;
    }

    public async Task Handle(CreateLessonCommand command)
    {
        var lesson = new LessonMkn()
        {
            IsStudentAttended = false,
            LessonNumber = command.Dto.LessonNumber,
            ReasonForAbsence = command.Dto.ReasonForAbsence,
            Status = LessonStatus.InProgress
        };
        
        //generateTeamsHandler.Handle
        
        
        await _lessonsRepository.AddAsync(lesson);
    }
}