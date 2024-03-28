using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        private HashSet<IPeak> _peaks;

        public PeakRepository()
        {
            _peaks = new HashSet<IPeak>();
        }

        public IReadOnlyCollection<IPeak> All => _peaks;

        public void Add(IPeak model)
        {
            _peaks.Add(model);
        }

        public IPeak Get(string name)
        {
            return _peaks.FirstOrDefault(p => p.Name == name);
        }
    }
}
