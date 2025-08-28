using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Repositories;
using ScoreHub_Domain.Repositories.Features.GetWithFilters;
using ScoreHub_Infrastructure;

namespace ScoreHub_Application.Services;

public class TelegramService
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IQueryHandler<User, GetUsersByEmailOrIdQuery> _queryHandler;

    public TelegramService(
        IJwtProvider jwtProvider, 
        IQueryHandler<User, GetUsersByEmailOrIdQuery> query)
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