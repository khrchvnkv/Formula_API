using Formula_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formula_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private static List<Driver> _drivers = new List<Driver>()
        {
            new Driver()
            {
                Id = 1,
                Name = "Aaa",
                DriverNumber = 123,
                Team = "Aaa_Team"
            },
            new Driver()
            {
                Id = 2,
                Name = "Bbb",
                DriverNumber = 234,
                Team = "Aaa_Team"
            },
            new Driver()
            {
                Id = 3,
                Name = "Ccc",
                DriverNumber = 345,
                Team = "Aaa_Team"
            }
        };

        [HttpGet]
        [Route(nameof(Get))]
        public IActionResult Get()
        {
            return Ok(_drivers);
        }

        [HttpGet]
        [Route(nameof(GetById))]
        public IActionResult GetById(int id)
        {
            return Ok(_drivers.FirstOrDefault(d => d.Id == id));
        }

        [HttpPost]
        [Route(nameof(AddDriver))]
        public IActionResult AddDriver(Driver newDriver)
        {
            _drivers.Add(newDriver);
            return Ok();
        }

        [HttpPatch]
        [Route(nameof(UpdateDriver))]
        public IActionResult UpdateDriver(Driver driver)
        {
            var existDriver = _drivers.FirstOrDefault(d => d.Id == driver.Id);
            if (existDriver is null) return NotFound();

            existDriver.Name = driver.Name;
            existDriver.DriverNumber = driver.DriverNumber;
            existDriver.Team = driver.Team;
            
            return NoContent(); 
        }

        [HttpDelete]
        [Route(nameof(DeleteDriver))]
        public IActionResult DeleteDriver(int id)
        {
            var driver = _drivers.FirstOrDefault(d => d.Id == id);
            if (driver is null) return NotFound();
            
            _drivers.Remove(driver);
            return NoContent();
        }
    }
}