using System.Threading.Tasks;
using EcommerceApplication2.Entities;
using Microsoft.AspNetCore.Http;

namespace EcommerceApplication2.Service.Interface
{
    public interface IPictureService
    {
         Task<Picture> UploadPicture(Product product, IFormFile file, string uploadsFolderPath);
    }
}