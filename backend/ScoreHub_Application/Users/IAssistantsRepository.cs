using ScoreHub_Domain.Entities;

namespace ScoreHub_Application.Users;

public class IAssistantsRepository
{
    public IQueryable<Assistant> ReadStudents { get; }

}