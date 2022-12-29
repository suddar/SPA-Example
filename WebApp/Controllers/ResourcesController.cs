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

        [HttpGet("ClearResources")]
        public async Task<ActionResult<List<ResourceObject>>> ClearAll()
        {
            return Ok(await _resourceService.ClearAll());
        }

        [HttpGet("Resources")]
        public async Task<ActionResult<List<ResourceObject>>> GetResources()
        {
            return Ok(await _resourceService.GetResourceObjectsAsync());
        }

        [HttpPost("Resources")]
        public async Task<IActionResult> Resources([FromForm] Resource resource)
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
