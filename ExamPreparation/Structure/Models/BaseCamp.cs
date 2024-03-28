using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    internal class BaseCamp : IBaseCamp
    {
        private SortedSet<string> _residents;
        public IReadOnlyCollection<string> Residents  => _residents;

        public BaseCamp()
        {
            _residents = new SortedSet<string>();
        }

        public void ArriveAtCamp(string climberName)
        {
            _residents.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            _residents.Remove(climberName);
        }
    }
}
