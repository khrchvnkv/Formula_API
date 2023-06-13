using Formula_Api.Data;
using Formula_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Formula_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DriverController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route(nameof(Get))]
        public async Task<IActionResult> Get() => 
            Ok(await  _context.Drivers.ToListAsync());

        [HttpGet]
        [Route(nameof(GetById))]
        public async Task<IActionResult> GetById(int id)
        {
            var driver = await GetDriverByIdAsync(id);
            if (driver is null) return NotFound();
            
            return Ok(driver);
        }

        [HttpPost]
        [Route(nameof(AddDriver))]
        public async Task<IActionResult> AddDriver(Driver newDriver)
        {
            await _context.Drivers.AddAsync(newDriver);
            await _context.SaveChangesAsync();
            
            return Ok();
        }

        [HttpPatch]
        [Route(nameof(UpdateDriver))]
        public async Task<IActionResult> UpdateDriver(Driver driver)
        {
            var existDriver = await GetDriverByIdAsync(driver.Id);
            if (existDriver is null) return NotFound();

            existDriver.Name = driver.Name;
            existDriver.DriverNumber = driver.DriverNumber;
            existDriver.Team = driver.Team;
            
            await _context.SaveChangesAsync(); 
            
            return NoContent(); 
        }

        [HttpDelete]
        [Route(nameof(DeleteDriver))]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await GetDriverByIdAsync(id);
            if (driver is null) return NotFound();
            
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private async Task<Driver?> GetDriverByIdAsync(int id) =>
            await _context.Drivers.FirstOrDefaultAsync(d => d.Id == id);
    }
}