using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApplication2.DataContext;
using EcommerceApplication2.Entities;
using EcommerceApplication2.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication2.Service.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly EcommerceContext context;
        public ProductRepository(EcommerceContext context)
        {
            this.context = context;

        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await context.Products
            .Include(x => x.SubCategory)
            .ThenInclude(y => y.Category)
            .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            //Have to include relate with  .FindAsync(id); Look at vega
            return await context.Products
                .Include(x => x.SubCategory)
            .ThenInclude(y => y.Category)
            .SingleOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Product> GetProductWithPicture(int id)
        {
            return await context.Products
            .Include(x => x.Pictures)
            .SingleOrDefaultAsync(x => x.Id == id);

            // var product = await context.Products
            // .SingleOrDefaultAsync(x => x.Id == id);

            // context.Entry(product)
            // .Collection(p => p.Pictures)
            // .Query()
            // .Where(p => p.IsMain == true)
            // .Load();

            // return product;
        }

        public void Insert(Product product)
        {
            context.Products.Add(product);
        }

        public void Remove(Product product)
        {
            context.Products.Remove(product);
        }
    }
}