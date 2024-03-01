namespace Collections.Model
{
    public class MyList : AddRemoveCollection
    {
        public ICollection<string> Used { get; set; }

        public MyList()
        {
            Used = new List<string>();
        }

        public override string Remove()
        {
            string removedItem = _collection[0];
            _collection.RemoveAt(0);
            Used.Add(removedItem);
            return removedItem;
        }
    }
}
