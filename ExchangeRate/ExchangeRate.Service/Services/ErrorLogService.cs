using ExchangeRate.Core.LogModels;
using ExchangeRate.Core.Repositories;
using ExchangeRate.Core.Services;
using ExchangeRate.Core.UnitOfWork;
using ExchangeRate.Helpers.Models.Dtos.LogModelDtos;
using ExchangeRate.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Service.Services
{
    public class ErrorLogService : IErrorLogService
    {
        public IGenericRepository<ErrorLog> _errorLogRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ErrorLogService(IGenericRepository<ErrorLog> errorLogRepository, IUnitOfWork unitOfWork)
        {
            _errorLogRepository = errorLogRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddErrorLog(ErrorLogDto item)
        {
            await _errorLogRepository.AddAsync(ObjectMapper.Mapper.Map<ErrorLog>(item));
            await _unitOfWork.CommitAsync();
        }


        public async Task ErrorLogWithBulk(IEnumerable<ErrorLogDto> list)
        {
            await _errorLogRepository.WithBulk(ObjectMapper.Mapper.Map<IEnumerable<ErrorLog>>(list));
            await _unitOfWork.CommitAsync();
        }
    }
}
