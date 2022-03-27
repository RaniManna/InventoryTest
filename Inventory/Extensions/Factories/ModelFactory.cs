using Inventory.Domain.Base;
using Inventory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Extensions.Factories
{
    public abstract class ModelFactory<T> where T : BaseEntity
    {
        protected int _count = 1;
        protected readonly InventoryContext _dataContext;
        public ModelFactory(InventoryContext dataContext)
        {
            _dataContext = dataContext;
        }

        public abstract Task<T> Make();

        public ModelFactory<T> Count(int count)
        {
            _count = count;
            return this;
        }

        public virtual async Task<int> Create()
        {
            var models = new List<T>();

            for (int i = 0; i < _count; i++)
            {
                models.Add(await Make());
            }

            await _dataContext.Set<T>().AddRangeAsync(models);

            return await _dataContext.SaveChangesAsync();
        }
    }
}
