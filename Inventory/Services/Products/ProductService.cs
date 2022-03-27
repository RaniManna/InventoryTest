using AutoMapper;
using Inventory.API.DTOs.Product;
using Inventory.Domain.Interfaces;
using Inventory.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Services.Products
{
    public class ProductService : BaseService
    {
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        //add the dictionary in the end just to make the response for consumer unified ( all APIs Response maps)
        public async Task<Dictionary<string, List<ProductCountByStatusDTO>>> GetProductCountByStatus()
        {
            var repository = UnitOfWork.GenericRepository<Product>();
            var AllProducts = await repository.GetAll();
            Dictionary<string, List<ProductCountByStatusDTO>> ProductCounts = new Dictionary<string, List<ProductCountByStatusDTO>> {
                { "products", AllProducts.GroupBy(p => p.Status).Select(s => new ProductCountByStatusDTO { Status = s.Key.ToString(), Count = s.Count() }).ToList() }
            };
            
            return ProductCounts;
        }

        public async Task<GetProductDTO> UpdateProductStatus(long id, UpdateProductDTO updateProductDTO)
        {
            
            var repository = UnitOfWork.GenericRepository<Product>();
            var product = await repository.Get(p => p.Id.Equals(id));
            
            if (product == null)
                throw new Exception("Product not found");
            
            product.ChangeStauts(updateProductDTO.Status);
            repository.Update(product);
            await UnitOfWork.Save();
            return Mapper.Map<GetProductDTO>(product);
        }

        public async Task<GetProductDTO> SellProduct(SellProductDTO sellProductDTO)
        {
            var repository = UnitOfWork.GenericRepository<Product>();
            var product = await repository.Get(p => p.Id.Equals(sellProductDTO.ProductId));
            
            if (product == null)
                throw new Exception("Product not found");

            if (product.ProductAvaliblity() == false)
                throw new Exception("Product is not sold or dameged");
            
            product.SellProduct();
            repository.Update(product);
            await UnitOfWork.Save();
            return Mapper.Map<GetProductDTO>(product);
        }

    }
}
