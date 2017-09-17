using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApplication2.Entities;

namespace EcommerceApplication2.Service.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();

        Task<Order> GetById(int id);

        // void Delete(int id); look into Deleting a certain ID that is async

        //int Count(); //Might have to add count later, not sure if needed now

        //void Save(); IMplement in UOW SaveChangeAsync
    }
}