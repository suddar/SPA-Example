using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpPost("Upload")]
        public async Task<IActionResult> PostResources([FromForm] ResourceObject resource)
        {
            if (resource == null)
                return new BadRequestResult();

            await _resourceService.SaveToDatabaseAsync(resource);
            return Ok("Uploaded");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditResource(int id, [FromBody] ResourceObject value)
        {
            await _resourceService.Update(id, value);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _resourceService.Delete(id);
            return Ok("Deleted");
        }

        [HttpPost("Edit/{id}")]
        public IActionResult EResources([FromForm] IFormFile file)
        {
            Console.WriteLine("edit");
            Console.WriteLine(JsonConvert.SerializeObject(file));
            return Ok("Uploaded");
        }
    }
}
