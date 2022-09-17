using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult test()
        {
            return Ok("merhaba");
        }


        [HttpGet("getcarbyid")]
        public IActionResult GetCarById(int id)
        {

            var result = _carService.GetCarById(id);

            if (result.Success == true)
            {
                return Ok(_carService.GetCarById(id));
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("addcar")]
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);

            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
