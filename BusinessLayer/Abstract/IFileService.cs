using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Abstract
{
    public interface IFileService
    {
        void DeleteFile(string fileName, string directory);
        Task<string> SaveFile(IFormFile file, string directory, string[] allowedExtensions);
    }
}