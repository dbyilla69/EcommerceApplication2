using System;
using System.Threading.Tasks;

namespace EcommerceApplication2.DataContext.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceContext context;

        public UnitOfWork(EcommerceContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}