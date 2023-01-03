using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        public ResourcesController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet("ClearAll")]
        public async Task<ActionResult<List<ResourceObject>>> ClearAll()
        {
            return Ok(await _resourceService.ClearAll());
        }

        [HttpGet("GetResources")]
        public async Task<ActionResult<List<ResourceObject>>> GetResources()
        {
            return Ok(await _resourceService.GetResourceObjectsAsync());
        }

        [HttpGet("Upload")]
        public async Task<IActionResult> PostResources([FromForm] Resource resource)
        {
            if (resource.File == null)
                return new BadRequestResult();

            await _resourceService.SaveAsync(resource.File);
            return Ok("Done");
        }
    }

    public class Resource
    {
        public IFormFile? File { get; set; }
        public string? Name { get; set; }
    }
}
