using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogRepository _logRepository;

        public UserRepository(AppDbContext appDbContext, ILogRepository logRepository)
        {
            _appDbContext = appDbContext;
            _logRepository = logRepository;
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            try
            {
                return await _appDbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
            }
            catch (Exception ex)
            {
                await _logRepository.LogErrorAsync("Error in GetUserByUsername", ex);
                throw;
            }
        }
    }
}
