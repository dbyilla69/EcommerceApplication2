using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApplication2.DataContext;
using EcommerceApplication2.Entities;
using EcommerceApplication2.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication2.Service.Repository
{
    public class OrderLineRepository : IOrderLineRepository
    {
        private readonly EcommerceContext context;
        public OrderLineRepository(EcommerceContext context)
        {
            this.context = context;

        }

        public async Task<IEnumerable<OrderLine>> GetAll()
        {
            return await context.OrderLines.ToListAsync();
        }

        public async Task<OrderLine> GetById(int id)
        {
            return await context.OrderLines.FindAsync(id);
        }

        public void Insert(OrderLine orderLine)
        {
            context.OrderLines.Add(orderLine);
        }
    }
}