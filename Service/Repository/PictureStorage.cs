using System;
using System.IO;
using System.Threading.Tasks;
using EcommerceApplication2.Service.Interface;
using Microsoft.AspNetCore.Http;

namespace EcommerceApplication2.Service.Repository
{
    public class PictureStorage : IPictureStorage
    {
        public async Task<string> StorePicture(string uploadsFolderPath, IFormFile file)
        {
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}