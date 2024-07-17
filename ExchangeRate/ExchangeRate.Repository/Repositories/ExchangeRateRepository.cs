using ExchangeRate.Core.DbModels;
using ExchangeRate.Core.Repositories;
using ExchangeRate.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRate.Repository.Repositories
{
    public class ExchangeRateRepository : GenericRepository<ExchangeRate.Core.DbModels.ExchangeRate>, IExchangeRateRepository
    {
        public ExchangeRateRepository(AppDbContext context) : base(context)
        {
        }
    }
}
