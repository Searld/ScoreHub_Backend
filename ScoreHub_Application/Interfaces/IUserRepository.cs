using ScoreHub_Domain.Entities;

namespace ScoreHub_Domain.Repositories;

public interface IUserRepository
{
    public Task<User> GetUserByEmail(string email);
    public Task<User> GetUserByID(Guid id);
    public Task<User> GetTeacherByID(Guid id);  
    public Task<User> GetStudentByID(Guid id);  
    public Task<User> GetAssistantByID(Guid id);  
    public Task AddAsync(User user);
    public Task<List<User>> GetAllUsers();
    public Task<List<User>> GetAllUsersByGroup(int groupNumber);
 
}