using Inventory.Domain.Base;
using Inventory.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Categories
{
    public class Category : BaseEntity<short>
    {
        //This is an Anemic domain model(CRUD only - no behavior.
        public Category(string name) : base()
        {
            if (name.Length > 255)
                throw new ArgumentOutOfRangeException("Name should be less than 255 char");
            Name = name;
        }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; internal set; }
    }
}
