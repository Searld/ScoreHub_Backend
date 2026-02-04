using Microsoft.EntityFrameworkCore;
using ScoreHub_Application.Abstractions;
using ScoreHub_Contracts.Users;

namespace ScoreHub_Application.Users.Features.GetByEmailOrId;

public class GetUsersByEmailOrId : IQueryHandler<UserDto, GetUsersByEmailOrIdQuery>
{
    private readonly IStudentReadDbContext _context;

    public GetUsersByEmailOrId(IStudentReadDbContext context)
    {
        _context = context;
    }
    public async Task<UserDto> Handle(GetUsersByEmailOrIdQuery query)
    {
        return null;
    }
}