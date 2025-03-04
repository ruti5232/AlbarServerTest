using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ILogService
    {
        Task<LogDTO> AddAsync(LogDTO logDto);
        Task LogErrorAsync(string message, Exception ex);
    }
}
