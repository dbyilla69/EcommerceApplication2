using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApplication2.Entities;

namespace EcommerceApplication2.Service.Interface
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<CartItem>> GetAll();

        Task<CartItem> GetById(int id);

        void Insert(CartItem cart);//Insert & Add the samething

        //void Update(CartItem cart);//Look up async update/edit

        // void Delete(int id); look into Deleting a certain ID that is async

        //int Count(); //Might have to add count later, not sure if needed now

        //void Save(); IMplement in UOW SaveChangeAsync

    }
}