using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPA_Example.Architecture.Application.Services;

namespace SPA_Example.Pages.Admin.Resources
{
    public class UploadModel : PageModel
    {
        private readonly IResourceService _resourceService;
        //private readonly IWebHostEnvironment _environment;
        public UploadModel(IWebHostEnvironment environment, IResourceService resourceService)
        {
            //_environment = environment;
            _resourceService = resourceService;
        }

        [BindProperty]
        public IFormFile Upload { get; set; }
        public async Task OnPostAsync()
        {
            //var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
            //using var fileStream = new FileStream(file, FileMode.Create);
            //await Upload.CopyToAsync(fileStream);

            if (Upload != null)
            {
                using MemoryStream ms = new();
                await Upload.CopyToAsync(ms);
                var resource = new ResourceObject
                {
                    ContentType = Upload.ContentType,
                    Bytes = ms.ToArray()
                };
                await _resourceService.SaveAsync(resource);
            }
        }
    }
}
