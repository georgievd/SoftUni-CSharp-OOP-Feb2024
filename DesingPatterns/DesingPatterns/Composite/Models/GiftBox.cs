using System.Text;
using Composite.Interfaces;

namespace Composite.Models
{
    // This is the 'Composite' in our case
    public class GiftBox : GiftBase, IBoxOperations
    {
        public List<GiftBase> _gifts { get; set; }

        public GiftBox(string name, decimal price)
        {
            _gifts = new List<GiftBase>();
            Name = name;
            Price = price;
        }

        public override decimal CalculateTotalPrice()
        {
            return Price + _gifts
                .Sum(c => c.CalculateTotalPrice());
        }

        public void Add(GiftBase gift)
        {
            _gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            _gifts.Remove(gift);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Box: {Name} costing {Price} and consisting of the following items: ");
            foreach (var gift in _gifts)
            {
                sb.AppendLine(gift.ToString());
            }

            sb.AppendLine($"Total for {Name} box:  {this.CalculateTotalPrice()}");

            return sb.ToString();
        }
    }
}
