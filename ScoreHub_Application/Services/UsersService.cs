using ScoreHub_Domain.Repositories;

namespace ScoreHub_Application.Services;

public class UsersService
{
    private readonly IUserRepository _userRepository;

    public UsersService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    
}