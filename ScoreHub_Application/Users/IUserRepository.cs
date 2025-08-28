using ScoreHub_Domain.Entities;

namespace ScoreHub_Domain.Repositories;

public interface IUserRepository
{
    public Task AddAsync(User user);
     
}