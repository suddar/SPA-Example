﻿using Microsoft.AspNetCore.Http;
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

        // create 
        [HttpPost]
        public async Task<IActionResult> UploadResource([FromForm] List<IFormFile> files)
        {
            foreach (var item in files)
                await _resourceService.UploadResourceAsync(item);

            return Ok();
        }

        // read
        [HttpGet()]
        public async Task<IActionResult> GetResources(int pageIndex, int size)
        {
            var resources = await _resourceService.GetResourcesAsync(pageIndex, size);
            return Ok(resources);
        }

        [HttpGet("{size}")]
        public async Task<IActionResult> GetPagination(int size)
        {
            var pageTotal = await _resourceService.GetPageTotal(size);
            return Ok(pageTotal);
        }

        // update
        [HttpPut()]
        public async Task<IActionResult> UpdateResource([FromForm] IFormFile file, int id)
        {
            await _resourceService.UpdateResourceAsync(id, file);
            return Ok();
        }

        // delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(int id)
        {
            await _resourceService.DeleteResource(id);
            return Ok();
        }

        // delete
        [HttpDelete()]
        public async Task<IActionResult> DeleteAllResources()
        {
            await _resourceService.DeleteAllResources();
            return Ok();
        }
    }
}