using ScoreHub_Application.Abstractions;
using ScoreHub_Application.Users.Features.GetByEmailOrId;
using ScoreHub_Domain.Entities;

namespace ScoreHub_Application.Services;

public class TelegramService
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IQueryHandler<Student, GetUsersByEmailOrIdQuery> _queryHandler;

    public TelegramService(
        IJwtProvider jwtProvider, 
        IQueryHandler<Student, GetUsersByEmailOrIdQuery> query)
    {
        _jwtProvider = jwtProvider;
        _queryHandler = query;
    }
    public async Task<string> GetTgTempToken(Guid userId)
    {
        return _jwtProvider.GenerateTGTempToken(userId);
    }
    
    public async Task<string> GetTgToken(Guid userId)
    {
        var query = new GetUsersByEmailOrIdQuery(userId);
        var user = await _queryHandler.Handle(query);
        return _jwtProvider.GenerateToken(user);
    }
}