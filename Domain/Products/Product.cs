using Inventory.Domain.Base;
using Inventory.Domain.Categories;

namespace Inventory.Domain.Products
{
    public partial class Product : BaseEntity<long>
    {

        //This is a Rich domain model(have behavior).
        public Product(): base()
        {
            
        }

        public string Name { get; private set; }
        public string Barcode { get; private set; }
        public string Description { get; private set; }
        public float Weight{ get; private set; }
        public short CategoryId{ get; private set; }
        //It can Be an Enum or It can be a table, I prefer it to a table(but for this task there is no need for that)
        public ProductStatus Status{ get; private set; }

        public virtual Category Category { get; private set; }

    }
}
