using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPA_Example.Architecture.Application.Services;
using System.ComponentModel.Design;
using IResourceService = SPA_Example.Architecture.Application.Services.IResourceService;

namespace SPA_Example.Pages.Admin.Resources
{
    public class IndexModel : PageModel
    {
        public List<ResourceObject>? ResourcesList { get; set; }
        private readonly IResourceService _resourceService;

        public IndexModel(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public async Task OnGet()
        {
            ResourcesList = await _resourceService.GetResourceObjectsAsync();
        }
    }
}
