using CarRentalSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
      
            private readonly ICarService _carService;
        private readonly IUserRepository _userRepository;

            public CarController(ICarService carService)
            {
                _carService = carService;
            }

            [HttpGet("available")]
            [Authorize(Roles = "User,Admin")]
            public async Task<IActionResult> GetAvailableCars()
            {
                var availableCars = await _carService.GetAvailableCars();
                return Ok(availableCars);
            }

            [HttpPost("{carId}/rent")]
            [Authorize(Roles = "User")]
            public async Task<IActionResult> RentCar(int carId, [FromQuery] int userId, [FromQuery] int rentalDays)
            {
                var result = await _carService.RentCar(carId, userId, rentalDays);
                if (!result)
                {
                    return BadRequest("Car not available or rental failed.");
                }
            //var u = _userRepository.GetUserById(userId);
            Console.WriteLine();

                return Ok($"Car rented successfully for {rentalDays} days.");
            }

            [HttpPost("add")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> AddCar([FromBody] Car car)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _carService.AddCar(car);
                if (!result)
                {
                    return StatusCode(500, "Error occurred while adding the car.");
                }

                return Ok("Car added successfully.");
            }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var result = await _carService.DeleteCar(id);
            if (!result)
            {
                return NotFound("Car not found or deletion failed.");
            }

            return Ok("Car deleted successfully.");
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCar(int id,  Car updatedCar)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _carService.UpdateCar(id, updatedCar);
            if (!result)
            {
                return NotFound("Car not found or update failed.");
            }

            return Ok("Car updated successfully.");
        }

    }
}
