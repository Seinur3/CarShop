using CarShopFinal.Domain.Interfaces;

namespace CarShopFinal.Infrastructure.Services;

public class FileService : IFileService
{
    private readonly string _uploadDirectory;

    public FileService(IWebHostEnvironment hostingEnvironment)
    {
        _uploadDirectory = Path.Combine(hostingEnvironment.WebRootPath, "uploads"); 
        Directory.CreateDirectory(_uploadDirectory);
    }
    
    public async Task<string> UploadFileAsync(Stream fileStream, string originalName)
    {
        // photka.jpg -> 2423-1234-5678-7934.jpg   .docx -> jpg
        var ext = Path.GetExtension(originalName);
        var fileName = $"{Guid.NewGuid()}{ext}";
        Console.WriteLine($"filename Created");

        var filePath = Path.Combine(Path.Combine(_uploadDirectory, fileName));
        Console.WriteLine($"Uploading file {fileName}...");
        await using var stream = File.Create(filePath);
        await fileStream.CopyToAsync(stream);
        // string fileName = s[do tochki].jpg
        
        return fileName;
    }

    public void DeleteFile(string fileUrl)
    {
        var filePath = Path.Combine(_uploadDirectory, fileUrl);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}