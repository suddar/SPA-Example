using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPA_Example.Architecture.Application.Services;

namespace SPA_Example.Pages.Admin.Resources
{
    public class UploadModel : PageModel
    {
        private readonly IResourceService _resourceService;
        private readonly IWebHostEnvironment _environment;
        public UploadModel(IResourceService resourceService, IWebHostEnvironment environment)
        {
            _environment = environment;
            _resourceService = resourceService;
        }

        public List<ResourceObject>? ResourcesList { get; set; }
        [BindProperty]
        public IFormFile? Upload { get; set; }

        public async Task OnGet()
        {
            ResourcesList = await _resourceService.GetResourceObjects();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
            //using var fileStream = new FileStream(file, FileMode.Create);
            //await Upload.CopyToAsync(fileStream);

            if (Upload == null)
                return new BadRequestResult();

            using MemoryStream ms = new();
            await Upload.CopyToAsync(ms);
            var resource = new ResourceObject
            {
                Name = Upload.FileName,
                ContentType = Upload.ContentType,
                Bytes = ms.ToArray()
            };

            await _resourceService.SaveAsync(resource);
            return Page();
        }
    }
}
