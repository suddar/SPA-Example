using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        public ImageController() { }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("Files");
        }

        [HttpGet]
        public IActionResult DownloadFile(string fileName)
        {
            // Lấy đường dẫn tuyệt đối của tệp
            var filePath = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot", fileName);

            // Trả về URL của tệp
            return PhysicalFile(filePath, "application/octet-stream");
        }

    }
}
