using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private IImageService _imageService;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("uploadimage")]
        public async Task<IActionResult> UploadImage(IFormFile file, int carId)
        {
            if (file != null)
            {
                var result = _imageService.UploadImage(file, carId);
                if (result.Success)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int carID)
        {
            var result = _imageService.GetImagesByCarId(carID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deleteimage")]
        public IActionResult DeleteImage(Image image)
        {
            var result = _imageService.Delete(image);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
