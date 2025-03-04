using DAL.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine($"Entity State Before SaveChanges: {_appDbContext.Entry(log).State}");
            await SaveChangesAsync();
            Console.WriteLine($"Entity State After SaveChanges: {_appDbContext.Entry(log).State}");
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
