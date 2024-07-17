using System.Threading.Tasks;
using ExchangeRate.Core.Repositories;

namespace ExchangeRate.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IExchangeRateRepository ExchangeRates { get; }
        Task<int> CompleteAsync();
        void Commit();
        Task CommitAsync();
    }
}
