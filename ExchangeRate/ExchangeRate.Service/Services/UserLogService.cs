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
    public class UserLogService : IUserLogService
    {
        private readonly IGenericRepository<UserLog> _userLogService;
        private readonly IUnitOfWork _unitOfWork;
        public UserLogService(IGenericRepository<UserLog> userLogService, IUnitOfWork unitOfWork)
        {
            _userLogService = userLogService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddUserLog(UserLogDto item)
        {
            await _userLogService.AddAsync(ObjectMapper.Mapper.Map<UserLog>(item));
            await _unitOfWork.CommitAsync();
        }

        public async Task UserLogWithBulk(IEnumerable<UserLogDto> list)
        {
            await _userLogService.WithBulk(ObjectMapper.Mapper.Map<IEnumerable<UserLog>>(list));
            await _unitOfWork.CommitAsync();
        }
    }
}
