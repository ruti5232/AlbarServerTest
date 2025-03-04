using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories;


namespace BLL.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;
        public LogService(ILogRepository logRepository, IMapper mapper)
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }
        public async Task<LogDTO> AddAsync(LogDTO logDto)
        {
            try
            {
                var logEntity = _mapper.Map<Log>(logDto);
                var addedLog = await _logRepository.AddAsync(logEntity);
                return _mapper.Map<LogDTO>(addedLog);
            }
            catch (Exception ex)
            {
                await LogErrorToFileAsync(ex);
                throw;
            }

        }
        public async Task LogErrorAsync(string message, Exception ex)
        {
            await _logRepository.LogErrorAsync(message, ex);
        }

        private async Task LogErrorToFileAsync(Exception ex)
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "log.txt");
            try
            {
                string errorMessage = $"[{DateTime.Now}] - Error: {ex.Message}{Environment.NewLine}Stack Trace: {ex.StackTrace}{Environment.NewLine}";

                string directory = Path.GetDirectoryName(logFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                await File.AppendAllTextAsync(logFilePath, errorMessage);
            }
            catch (Exception fileEx)
            {
                Console.WriteLine($"Failed to write to log file: {fileEx.Message}");
            }
        }
    }
}
