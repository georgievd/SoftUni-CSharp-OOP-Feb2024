namespace Composite.Models
{

    // This is the leaf node, cannot contain more nodes - gifts or boxes
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override decimal CalculateTotalPrice()
        {
            return Price;
        }

        public override string ToString()
        {
            return $"Item: {Name} with price: {Price}";
        }
    }
}
