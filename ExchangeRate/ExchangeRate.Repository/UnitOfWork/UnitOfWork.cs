using System.Threading.Tasks;
using ExchangeRate.Core.Repositories;
using ExchangeRate.Core.UnitOfWork;
using ExchangeRate.Repository.Context;
using ExchangeRate.Repository.Repositories;

namespace ExchangeRate.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ExchangeRateRepository _exchangeRates;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IExchangeRateRepository ExchangeRates => _exchangeRates ??= new ExchangeRateRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
