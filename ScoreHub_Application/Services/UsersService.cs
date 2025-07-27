using ScoreHub_Contracts.Users;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Enums;
using ScoreHub_Domain.Repositories;
using ScoreHub_Infrastructure;

namespace ScoreHub_Application.Services;

public class UsersService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public UsersService(
        IUserRepository userRepository, 
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task<GetUserResponse> GetUserByEmailAsync(string email)
    {
        var userEntity = await _userRepository.GetUserByEmail(email);
        return new GetUserResponse(
            userEntity.Id, userEntity.Email, 
            userEntity.Name, userEntity.GroupNumber, userEntity.Role);
    }

    public async Task RegisterUser(RegisterUserRequest request)
    {
        var hashedPassword = _passwordHasher.Generate(request.Password);

        var user = new User()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            AssistantData = request.Role == Role.Assistant ? new AssistantData() : null,
            TeacherData = request.Role == Role.Teacher ? new TeacherData() : null,
            StudentData = request.Role == Role.Student ? new StudentData() : null,
            GroupNumber = request.GroupNumber,
            Name = request.Name,
            PasswordHash = hashedPassword,
            Role = request.Role
        };
        
        await _userRepository.AddAsync(user);
    }

    public async Task<string> Login(string email, string password)
    {
        var user = await _userRepository.GetUserByEmail(email);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (!_passwordHasher.Verify(user.PasswordHash, password))
        {
            throw new Exception("Failed to login");
        }

        var token = _jwtProvider.GenerateToken(user);
        return token;
    }

    public async Task<List<GetUserResponse>> GetAllUsers()
    {
        var usersEntities = await _userRepository.GetAllUsers();
        return usersEntities.Select(u=> new GetUserResponse(
            u.Id, u.Email,  u.Name, u.GroupNumber, u.Role)).ToList();
    }
}