using ScoreHub_Contracts;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Repositories;

namespace ScoreHub_Application.UseCases;

public class CreateSubjectUseCase
{
    private readonly ISubjectRepository _subjectRepository;
    private readonly IUserRepository _userRepository;

    public CreateSubjectUseCase(ISubjectRepository subjectRepository, IUserRepository userRepository)
    {
        _subjectRepository = subjectRepository;
        _userRepository = userRepository;
    }

    public async Task Execute(CreateSubjectRequest request)
    {
        var teacher = await _userRepository.GetUserByID(request.TeacherId);
        var subject = new Subject()
        {
            Name = request.Name,
            Id = Guid.NewGuid(),
            Lessons = [],
            TeacherId = request.TeacherId,
            Teacher = teacher
        };
        _subjectRepository.CreateSubject(subject);
    }
}