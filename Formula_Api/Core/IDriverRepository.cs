using Formula_Api.Models;

namespace Formula_Api.Core
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        Task<Driver?> GetByDriverNumber(int driverNumber); 
    }
}