using DAL.Entities;


namespace DAL.Repositories
{
    public interface ILogRepository
    {
        Task<Log> AddAsync(Log log);
        Task LogErrorAsync(string message, Exception ex);

    }
}
