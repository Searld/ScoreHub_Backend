using ScoreHub_Application.Abstractions;
using ScoreHub_Contracts.Users;

namespace ScoreHub_Application.Users.Features.GetAllUsers;

public class GetAllUsers : IQueryHandler<IEnumerable<UserDto>, GetAllUsersQuery>
{
    private readonly IStudentReadDbContext _context;

    public GetAllUsers(IStudentReadDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery query)
    {
        return null;
    }   
}