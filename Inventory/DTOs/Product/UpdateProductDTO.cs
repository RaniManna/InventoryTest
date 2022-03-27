using Inventory.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.DTOs.Product
{
    public class UpdateProductDTO
    {
        public ProductStatus Status { get; set; }
    }
}
