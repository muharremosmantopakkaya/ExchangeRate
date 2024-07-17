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
    public class ApplicationLogService : IApplicationLogService
    {
        public IGenericRepository<ApplicationLog> _applicationLogRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationLogService(IGenericRepository<ApplicationLog> applicationLogRepository, IUnitOfWork unitOfWork)
        {
            _applicationLogRepository = applicationLogRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddApplicationLog(ApplicationLogDto item)
        {
            await _applicationLogRepository.AddAsync(ObjectMapper.Mapper.Map<ApplicationLog>(item));
            await _unitOfWork.CommitAsync();
        }

        public async Task ApplicationLogWithBulk(IEnumerable<ApplicationLogDto> list)
        {
            await _applicationLogRepository.WithBulk(ObjectMapper.Mapper.Map<IEnumerable<ApplicationLog>>(list));
            await _unitOfWork.CommitAsync();
        }
    }
}
