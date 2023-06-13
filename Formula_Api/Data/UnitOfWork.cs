using Formula_Api.Core;
using Formula_Api.Core.Repositories;

namespace Formula_Api.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiDbContext _context;
        
        public IDriverRepository Drivers { get; }

        public UnitOfWork(ApiDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger = loggerFactory.CreateLogger("logs");

            Drivers = new DriverRepository(_context, logger);
        }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();

        public async void Dispose() => await _context.DisposeAsync();
    }
}