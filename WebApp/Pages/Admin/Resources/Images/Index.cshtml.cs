using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Entities.Resources;
using Application.Services;

namespace WebApp.Pages.Admin.Resources
{
    public class IndexModel : PageModel
    {
        public List<ResourceObject> ResourcesList { get; set; }
        private readonly IOldResourceService _resourceService;

        public IndexModel(IOldResourceService resourceService)
        {
            ResourcesList = new();
            _resourceService = resourceService;
        }

        public async Task OnGet()
        {
            ResourcesList = await _resourceService.GetResourceObjectsAsync();
        }
    }
}
