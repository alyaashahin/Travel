using Azure.Core;
using static System.Net.Mime.MediaTypeNames;

namespace Travel.Services;
public class LocalImageService
{
    private readonly string uploadsFolder;
    private readonly IWebHostEnvironment _env;

    public LocalImageService(IWebHostEnvironment env)
    {
        _env = env;

        uploadsFolder = Path.Combine(_env.WebRootPath, "images");

        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }
    }

    public async Task<string> UploadImageAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is empty");

        var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"/images/{fileName}";
    }

    public void DeleteImage(string imageUrl)
    {
        var imagePath = Path.Combine(_env.WebRootPath, imageUrl.TrimStart('/'));

        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);
        }

    }
}