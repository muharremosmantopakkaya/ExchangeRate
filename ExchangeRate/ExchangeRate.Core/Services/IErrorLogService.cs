using ExchangeRate.Helpers.Models.Dtos.LogModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Core.Services
{
    public interface IErrorLogService
    {
        Task AddErrorLog(ErrorLogDto item);

        Task ErrorLogWithBulk(IEnumerable<ErrorLogDto> list);

    }
}
