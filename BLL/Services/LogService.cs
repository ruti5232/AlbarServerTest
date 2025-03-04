using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //return _mapper.Map<LogDTO>(await _logRepository.AddAsync(_mapper.Map<Log>(logDto)));
            var logEntity = _mapper.Map<Log>(logDto);
            var addedLog = await _logRepository.AddAsync(logEntity);
            return _mapper.Map<LogDTO>(addedLog);
        }
        public async Task LogErrorAsync(string message, Exception ex)
        {
            await _logRepository.LogErrorAsync(message, ex);
        }
    }
}
