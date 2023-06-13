using Formula_Api.Data;
using Formula_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula_Api.Core.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        { }

        public override async Task<Driver?> GetById(int id)
        {
            try
            {
                return await _context.Drivers.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Driver?> GetByDriverNumber(int driverNumber)
        {
            try
            {
                return await _context.Drivers.AsNoTracking().FirstOrDefaultAsync(d => d.DriverNumber == driverNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}