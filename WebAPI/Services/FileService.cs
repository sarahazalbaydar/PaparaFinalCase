using Application.Abstractions.Services;
using System.Globalization;
using System.Text;

namespace WebAPI.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<string> SaveAttachmentAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("Document cannot be saved.");

        if (string.IsNullOrEmpty(_webHostEnvironment.WebRootPath))
            throw new InvalidOperationException("Make sure wwwroot folder exists.");

        var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "attachments");
        Directory.CreateDirectory(uploadsFolder);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return $"/attachments/{fileName}";
    }
}
