using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadResource([FromForm] IFormFile file)
        {
            var resourceId = await _resourceService.UploadResourceAsync(file);
            return Ok(resourceId);
        }

        [HttpPost("{page}")]
        public async Task<IActionResult> GetResource([FromForm] IFormFile file)
        {
            var resourceId = await _resourceService.UploadResourceAsync(file);
            return Ok(resourceId);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteResource(int id)
        {
            _resourceService.DeleteResource(id);
            return Ok();
        }
    }
}
