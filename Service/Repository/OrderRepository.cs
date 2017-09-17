using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApplication2.DataContext;
using EcommerceApplication2.Entities;
using EcommerceApplication2.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication2.Service.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EcommerceContext context;
        public OrderRepository(EcommerceContext context)
        {
            this.context = context;

        }
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await context.Orders.FindAsync(id);
        }
    }
}