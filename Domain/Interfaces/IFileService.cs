namespace CarShopFinal.Domain.Interfaces;

public interface IFileService
{
    Task<string> UploadFileAsync(Stream fileStream, string originalName);
    void DeleteFile(string fileUrl);
}