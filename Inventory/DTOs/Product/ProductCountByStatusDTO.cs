using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.DTOs.Product
{
    public class ProductCountByStatusDTO
    {
        public string Status { get; set; }
        public int Count { get; set; }
    }
}
