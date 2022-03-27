using Inventory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Extensions.Factories
{
    public class Seed
    {
        public static async Task SeedData(InventoryContext context)
        {
            if (context.Products.Any())
            {
                return;
            }
            await new CategoryFactory(context).Count(5).Create();
            await new ProductFactory(context).Count(30).Create();
        }

    }
}
