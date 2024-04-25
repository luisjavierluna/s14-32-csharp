using eventPlannerBack.BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileImageController : ControllerBase
    {
        private readonly CloudinaryService _imageService;

        public ProfileImageController(CloudinaryService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> UploadImage(IFormFile file)
        {
            var result = await _imageService.UploadImage(file);
            return Ok(result);
        }
    }
}
