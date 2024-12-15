using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Concrete
{
    public class FileService : IFileService
    {
        public async Task<String> SaveFile(IFormFile file, string directory, string[] allowedExtensions)
        {
            var wwwPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var path = Path.Combine(wwwPath, directory); // wwwroot/images

            var extension = Path.GetExtension(file.FileName);

            //check extension
            if (!allowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException($"Only {string.Join(",", allowedExtensions)} allowed extension.");
            }
            // create unique name

            var newFileName = $"{Guid.NewGuid().ToString()}{extension}";

            var fullPath = Path.Combine(path, newFileName);

            //create file stream

            using var fileStream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return newFileName;
        }

        public void DeleteFile(string fileName,string directory)
        {
            var wwwPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var fullPath= Path.Combine(wwwPath,directory ,fileName);

            if (!Path.Exists(fullPath)) 
            {
                throw new FileNotFoundException($"{fileName} does not exist.");
            }
            File.Delete(fullPath);
        }
    }
}
