using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApplication2.Entities;

namespace EcommerceApplication2.Service.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product> GetProductWithPicture(int id);

        Task<Product> GetById(int id);

        void Insert(Product product);

        void Remove(Product product);
    }
}