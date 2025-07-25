using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Repositories;

namespace ScoreHub_Application.Services;

public class UsersService
{
    private readonly IUserRepository _userRepository;

    public UsersService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _userRepository.GetUserByEmail(email);
    }

    public async Task RegisterUser(User user)
    {
        await _userRepository.AddAsync(user);
    }
        
}