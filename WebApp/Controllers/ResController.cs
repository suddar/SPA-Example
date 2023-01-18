using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResController : ControllerBase
    {
        private readonly ResourceService _resourceService;

        public ResController(ResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadResource([FromForm] IFormFile file)
        {
            var resourceId = await _resourceService.UploadResource(file);
            return Ok(new { resourceId });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteResource(int id)
        {
            _resourceService.DeleteResource(id);
            return Ok();
        }
    }
}
