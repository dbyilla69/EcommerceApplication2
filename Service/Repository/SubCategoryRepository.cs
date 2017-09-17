using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApplication2.DataContext;
using EcommerceApplication2.Entities;
using EcommerceApplication2.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication2.Service.Repository
{
    ///REWORK THIS REPO
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly EcommerceContext context;
        public SubCategoryRepository(EcommerceContext context)
        {
            this.context = context;

        }
        public async Task<IEnumerable<SubCategory>> GetAll()
        {
            return await context.SubCategories
            //.Include(x => x.Categories)
            .ToListAsync();
        }

        public async Task<SubCategory> GetById(int id)
        {
            return await context.SubCategories
             //.Include(x => x.Categories)
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Insert(SubCategory subCategory)
        {
            context.SubCategories.Add(subCategory);
        }
    }
}