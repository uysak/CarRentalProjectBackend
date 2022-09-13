using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        [HttpGet]
        public IActionResult test()
        {
            return Ok("merhaba");
        }

        [HttpGet("getcarbyid")]
        public IActionResult GetCarById(int id)
        {
            ICarService carService = new CarManager(new EfCarDal());

            var result = carService.GetCarById(id);

            if (result.Success == true)
            {
                return Ok(carService.GetCarById(id));
            }

            return BadRequest(result.Message);
        }



    }
}
