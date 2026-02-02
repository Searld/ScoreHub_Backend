using Microsoft.EntityFrameworkCore;
using ScoreHub_Application.Abstractions;

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
        
        
    }
}