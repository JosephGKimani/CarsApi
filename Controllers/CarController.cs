using CarApi.AppDbContext;
using CarApi.DTOs;
using CarApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarApi.Controllers
{
    [Route("api/CarController")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarDbContext _context;
        public CarController(CarDbContext Context)
        {
            _context = Context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cars = _context.Cars.ToList();
            var carsdtoList = new List<GetCarDto>(); // Create a list to store each car's details

            foreach (var car in cars)
            {
                var carsObject = new GetCarDto
                {
                    Name = car.Name,
                    Model = car.Model,
                    YearOfManufacture = car.YearOfManufacture
                };
                carsdtoList.Add(carsObject); // Add the DTO to the list
            }

            return Ok(carsdtoList); // Return the list of DTOs
        }

        [HttpPost]
        public IActionResult post([FromBody] GetCarDto getCarDto)
        {
            var cardto = new GetCarDto()
            {
                Name = getCarDto.Name,
                Model = getCarDto.Model,
                YearOfManufacture = getCarDto.YearOfManufacture

            };
            var car = new Car()
            {
                Name = getCarDto.Name,
                Model = getCarDto.Model,
                YearOfManufacture = getCarDto.YearOfManufacture


            };

          
            if (car == null)
            {
                return NotFound("Kindly add some data");

            }
            _context.Cars.Add(car);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), cardto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult Getbyid([FromRoute] Guid id)
        {

            var car = _context.Cars.Find(id);

            if (car == null) { return NotFound("The problem is on our side"); };
            var carsdto = new GetCarDto()
            {
                Name = car.Name,
                Model = car.Model,
                YearOfManufacture = car.YearOfManufacture

            };


            return Ok(carsdto);

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var car = _context.Cars.Find(id);
            if (car == null)
            {
                return BadRequest("empty");
            }
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return Ok("Deleted");



        }
    }
}
