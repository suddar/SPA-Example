using System.Drawing;
using System.Runtime.Versioning;

namespace Application.Services
{
    internal class ThumbnailService : IThumbnailService
    {
        [SupportedOSPlatform("windows")]
        public async Task<MemoryStream> GenerateImage(IFormFile file, int with, int height)
        {
            using MemoryStream ms = new();
            await file.CopyToAsync(ms);

            Image image = Image.FromStream(ms);
            var thumbnaiImage = image.GetThumbnailImage(with, height, () => false, IntPtr.Zero);

            using var thumbnaiStream = new MemoryStream();
            thumbnaiImage.Save(thumbnaiStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            thumbnaiImage.Dispose();

            return thumbnaiStream;
        }
    }
}
