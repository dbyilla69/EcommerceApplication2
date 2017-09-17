using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApplication2.DataContext;
using EcommerceApplication2.Entities;
using EcommerceApplication2.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication2.Service.Repository
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly EcommerceContext context;
        public CategoryRepository(EcommerceContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await context.Categories
            .Include(c => c.SubCategories)
            .ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await context.Categories
             .Include(c => c.SubCategories)
             .SingleOrDefaultAsync(x => x.Id == id);

        }

        public void Insert(Category category)
        {
            context.Categories.Add(category);
        }
    }
}