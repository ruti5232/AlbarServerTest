using DAL.Entities;

namespace DAL.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);          
    }
}
