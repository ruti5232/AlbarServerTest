using BLL.DTOs;


namespace BLL.Services
{
    public interface ILogService
    {
        Task<LogDTO> AddAsync(LogDTO logDto);
        Task LogErrorAsync(string message, Exception ex);
    }
}
