using Composite.Models;

namespace Composite.Interfaces
{
    public interface IBoxOperations
    {
        void Add(GiftBase gift);
        void Remove(GiftBase gift);
    }
}
