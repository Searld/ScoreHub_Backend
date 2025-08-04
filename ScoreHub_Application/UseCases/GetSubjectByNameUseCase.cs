using ScoreHub_Contracts;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Repositories;

namespace ScoreHub_Application.UseCases;

public class GetSubjectByNameUseCase
{
    private readonly ISubjectRepository _subjectRepository;

    public GetSubjectByNameUseCase(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task<GetSubjectResponse> Execute(string name)
    {
        var subject = await _subjectRepository.GetSubjectByName(name);
        var getSubjectResponse = new GetSubjectResponse(subject.Id,subject.Name, subject.Lessons.Select(x => x.Id).ToList());
        return getSubjectResponse;
    }
}