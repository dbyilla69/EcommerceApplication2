using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EcommerceApplication2.Service.Interface
{
    public interface IPictureStorage
    {
           Task<string> StorePicture(string uploadsFolderPath, IFormFile file);
    }
}