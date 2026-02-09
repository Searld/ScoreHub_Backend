using ScoreHub_Application.Abstractions;
using ScoreHub_Contracts.MKN;

namespace ScoreHub_Application.MKN.Features.GenerateTeamCommand;

public class GenerateTeamHandler : ICommandHandler<GeneratedTeamsDto, GenerateTeamCommand>
{
    private readonly IStudentReadDbContext _studentReadContext;

    public GenerateTeamHandler(IStudentReadDbContext studentReadContext)
    {
        _studentReadContext = studentReadContext;
    }
    public Task<GeneratedTeamsDto> Handle(GenerateTeamCommand command)
    {
        
    }
}