using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.DTOs.Product
{
    public class GetProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public string Status { get; set; }
    }
}
