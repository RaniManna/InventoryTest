using Inventory.Domain.Base;
using Inventory.Domain.Interfaces;
using Inventory.Domain.Products;
using Inventory.Infrastructure.Data;
using Inventory.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace Inventory.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryContext _dbContext;


        public UnitOfWork(InventoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<T> GenericRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_dbContext);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
