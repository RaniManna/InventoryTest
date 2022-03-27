using Inventory.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Products
{
    public enum ProductStatus 
    {
        inStock = 1,
        sold = 2,
        damaged = 0
    }
}
