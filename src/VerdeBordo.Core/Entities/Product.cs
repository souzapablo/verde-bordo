namespace VerdeBordo.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product(Guid supplierId, string description, decimal price)
        {
            SupplierId = supplierId;
            Description = description;
            Price = price;
        }

        public Guid SupplierId { get; private set; }
        public Supplier Supplier { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
    }
}
