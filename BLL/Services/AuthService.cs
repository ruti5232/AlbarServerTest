using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;
        private readonly ILogService _logService;
        public AuthService(IUserRepository userRepository, TokenService tokenService, ILogService logService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _logService = logService;   
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            try
            {
                var user = await _userRepository.GetUserByUsernameAsync(username);
                if (user == null || !VerifyPassword(user, password))
                {
                    throw new UnauthorizedAccessException("Invalid username or password.");
                }

                return _tokenService.GenerateToken(user);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync($"Error in AuthenticateAsync - Username: {username}", ex);
                throw;
            }
        }

        private bool VerifyPassword(User user, string password)
        {
            return user.Password == password;
        }
    }
}
