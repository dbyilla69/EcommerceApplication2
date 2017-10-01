using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApplication2.Entities;

namespace EcommerceApplication2.Service.Interface
{
    public interface IPictureRepository
    {
        Task<IEnumerable<Picture>> GetPictures();
        //Task<IEnumerable<Picture>> GetAllPictures();
        Task<IEnumerable<Picture>> GetPictures(int productId);

    }
}