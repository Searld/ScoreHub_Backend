using Microsoft.EntityFrameworkCore;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Repositories;
using ScoreHub_Infrastructure;

namespace ScoreHub_Application.Lessons.Features;

public class CreateLessonCommandHandler : ICommandHandler<CreateLessonCommand>
{
    private readonly IUserReadDbContext _usersReadContext;
    private readonly ISubjectRepository _subjectRepository;

    public CreateLessonCommandHandler(
        IUserReadDbContext usersReadContext,
        ISubjectRepository subjectRepository)
    {
        _usersReadContext = usersReadContext;
        _subjectRepository = subjectRepository;
    }
    public async Task Handle(CreateLessonCommand command)
    {
        var students = await _usersReadContext.ReadUsers
            .OfType<Student>()
            .Where(s => command.Dto.StudentIds.Contains(s.Id))
            .ToListAsync();

        var lesson = new Lesson()
        {
            Id = Guid.NewGuid(),
            IsCommandLesson = command.Dto.IsCommandLesson,
            Name = command.Dto.Name,
            StartAt = command.Dto.StartAt,
            Status = command.Dto.Status,
            Students = students
        };
        
    }
}