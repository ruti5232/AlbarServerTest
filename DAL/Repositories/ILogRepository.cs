using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ILogRepository
    {
        Task<Log> AddAsync(Log log);
        Task LogErrorAsync(string message, Exception ex);

    }
}
