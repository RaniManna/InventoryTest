using Inventory.Domain.Categories;
using Inventory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Extensions.Factories
{
    public class CategoryFactory : ModelFactory<Category>
    {
        public CategoryFactory(InventoryContext dataContext) : base(dataContext)
        { }
        public async override Task<Category> Make()
        {
            return new Category(Faker.Name.First());
        }
    }
}
