using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApplication2.DataContext;
using EcommerceApplication2.Entities;
using EcommerceApplication2.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace EcommerceApplication2.Service.Repository
{
    public class PictureRepository : IPictureRepository
    {
        private readonly EcommerceContext context;
        public PictureRepository(EcommerceContext context)
        {
            this.context = context;

        }

        public async Task<IEnumerable<Picture>> GetPictures()
        {
            return await context.Pictures
            .Where(x => x.IsMain == true)
            .Include("Product")
            .ToListAsync();
        }


        public async Task<IEnumerable<Picture>> GetPictures(int productId)
        {
            return await context.Pictures
              .Where(p => p.ProductId == productId)
              .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await context.Products
            .Include(x => x.SubCategory)
            .ThenInclude(y => y.Category)
            .ToListAsync();
        }
    }
}