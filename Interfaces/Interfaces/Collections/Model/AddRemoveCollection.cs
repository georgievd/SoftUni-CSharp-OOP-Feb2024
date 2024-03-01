using Collections.Interfaces;

namespace Collections.Model
{
    public class AddRemoveCollection : AddCollection, IRemovable
    {
        public override int Add(string input)
        {
            _collection.Insert(0, input);
            return 0;
        }

        public virtual string Remove()
        {
            int indexOfItemToRemove = _collection.Count - 1;
            string removedItem = _collection[indexOfItemToRemove];
            _collection.RemoveAt(indexOfItemToRemove);
            return removedItem;
        }
    }
}
