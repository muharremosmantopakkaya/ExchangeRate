using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRate.Core.Services
{
    public interface IExchangeRateService
    {
        Task FetchAndSaveExchangeRatesAsync();
        Task<IEnumerable<ExchangeRate.Core.DbModels.ExchangeRate>> GetAllExchangeRatesAsync();
    }
}
