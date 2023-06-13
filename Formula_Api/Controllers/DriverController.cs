using Formula_Api.Core;
using Formula_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formula_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DriverController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<IActionResult> GetAll() => 
            Ok(await _unitOfWork.Drivers.GetAll());

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
            await _unitOfWork.Drivers.Add(newDriver);
            await _unitOfWork.CompleteAsync();
            
            return Ok();
        }

        [HttpPatch]
        [Route(nameof(UpdateDriver))]
        public async Task<IActionResult> UpdateDriver(Driver driver)
        {
            var existDriver = await GetDriverByIdAsync(driver.Id);
            if (existDriver is null) return NotFound();

            await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.CompleteAsync();
            
            return NoContent(); 
        }

        [HttpDelete]
        [Route(nameof(DeleteDriver))]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await GetDriverByIdAsync(id);
            if (driver is null) return NotFound();
            
            await _unitOfWork.Drivers.Delete(driver);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        private async Task<Driver?> GetDriverByIdAsync(int id) =>
            await _unitOfWork.Drivers.GetById(id);
    }
}