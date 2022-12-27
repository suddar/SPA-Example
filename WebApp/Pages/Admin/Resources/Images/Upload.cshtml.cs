using Application.Services;
using Domain.Entities.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages.Admin.Resources
{
    public class UploadModel : PageModel
    {
        private readonly IResourceService _resourceService;
        private readonly IWebHostEnvironment _environment;
        public UploadModel(IResourceService resourceService, IWebHostEnvironment environment)
        {
            _environment = environment;
            _resourceService = resourceService;
            ResourcesList = new List<ResourceObject>();
        }

        public List<ResourceObject> ResourcesList { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        public IFormFile? UploadedFile { get; set; }

        public async Task OnGet()
        {
            ResourcesList = await _resourceService.GetResourceObjectsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
            //using var fileStream = new FileStream(file, FileMode.Create);
            //await Upload.CopyToAsync(fileStream);

            if (UploadedFile == null)
                return new BadRequestResult();

            if (OperatingSystem.IsWindows())
                await _resourceService.SaveAsync(UploadedFile);

            ResourcesList = await _resourceService.GetResourceObjectsAsync();
            return Page();
        }
    }
}
