using AutoMapper;
using Inventory.API.DTOs.Product;
using Inventory.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Extensions
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {

            CreateMap<Product, GetProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
        
        }
    }
}
