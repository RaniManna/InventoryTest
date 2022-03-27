using Inventory.Domain.Products;
using Inventory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly InventoryContext _context;
        public ProductRepository(InventoryContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

    }
}
