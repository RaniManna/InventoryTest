using Inventory.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Products
{
    public partial class Product : IAggregateRoot
    {
        public Product(string name, string barcode, string description, float Weight
            , short categoryId, ProductStatus status)
        {

            this.Update(name, barcode, description, Weight, categoryId, status);
        }

        private void Update(string name, string barcode, string description, float weight, short categoryId, ProductStatus status)
        {
            Name = name;
            Barcode = barcode;
            Description = description;
            Weight = weight;
            CategoryId = categoryId;
            Status = status;
        }

        public void ChangeStauts(ProductStatus status)
        {
            Status = status;
        }

        public void SellProduct()
        {
            this.ChangeStauts(ProductStatus.sold);
        }

        public bool ProductAvaliblity()
        {
            if (this.Status == ProductStatus.sold || this.Status == ProductStatus.damaged)
                return false;
            return true;
        }

    }
}
