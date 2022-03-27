using Inventory.Domain.Products;
using Inventory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Extensions.Factories
{
    public class ProductFactory : ModelFactory<Product>
    {
        public ProductFactory(InventoryContext dataContext) : base(dataContext)
        { }
        public async override Task<Product> Make()
        {
            var categoryId = await _dataContext.Categorys.Select(u => u.Id).FirstOrDefaultAsync();
            var random = new Random();
            return new Product(Faker.Name.First(), Faker.Company.Suffix(),
                Faker.Lorem.Sentence(), Faker.RandomNumber.Next(10,100), 
                (short)categoryId, Faker.Enum.Random<ProductStatus>());
        }
    }
}
