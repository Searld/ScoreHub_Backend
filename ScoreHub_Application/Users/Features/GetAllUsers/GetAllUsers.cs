using ScoreHub_Application.Abstractions;
using ScoreHub_Contracts.Users;

namespace ScoreHub_Application.Users.Features.GetAllUsers;

public class GetAllUsers : IQueryHandler<IEnumerable<UserDto>, GetAllUsersQuery>
{
    private readonly IUserReadDbContext _context;

    public GetAllUsers(IUserReadDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery query)
    {
        return null;
    }   
}