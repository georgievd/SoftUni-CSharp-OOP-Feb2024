namespace Composite.Models
{
    public abstract class GiftBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public abstract decimal CalculateTotalPrice();
    }
}
