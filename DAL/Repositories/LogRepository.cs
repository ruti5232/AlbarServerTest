using DAL.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Http;


namespace DAL.Repositories
{
    public class LogRepository : ILogRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogRepository(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Log> AddAsync(Log log)
        {
            var res = await _appDbContext.Logs.AddAsync(log);
            await SaveChangesAsync();
            return res.Entity;
        }

        public async Task LogErrorAsync(string message, Exception ex)
        {
            var log = new Log
            {
                LogId = 0,
                Timestamp = DateTime.UtcNow,
                Level = "Error",
                Message = message.ToString(),
                StackTrace = ex.StackTrace.ToString(),
                Source = ex.Source.ToString(),
                RequestPath = _httpContextAccessor.HttpContext?.Request.Path.ToString(),
            };
            await AddAsync(log);
        }

        private async Task SaveChangesAsync() => await _appDbContext.SaveChangesAsync();

    }
}
