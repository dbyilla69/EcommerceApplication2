using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApplication2.DataContext;
using EcommerceApplication2.Entities;
using EcommerceApplication2.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication2.Service.Repository
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly EcommerceContext context;
        public CartItemRepository(EcommerceContext context)
        {
            this.context = context;

        }
        // public void Delete(int id)
        // {
        //     var cartItem = GetById(id);
        //     if(cartItem != null)
        //     context.CartItems.Remove(cartItem);
        // }

        public async Task<IEnumerable<CartItem>> GetAll()
        {
             return await context.CartItems.ToListAsync();
        }

        public async Task<CartItem> GetById(int id)
        {
            return await context.CartItems.FindAsync(id);
        }

        public void Insert(CartItem cart)
        {
             context.CartItems.Add(cart);
        }

        // public void Update(CartItem cart)
        // {
        //     throw new NotImplementedException();
        // }
    }
}