using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository : IRepository<IClimber>
    {
        private HashSet<IClimber> _climbers;

        public ClimberRepository()
        {
            _climbers = new HashSet<IClimber>();
        }

        public IReadOnlyCollection<IClimber> All => _climbers;

        public void Add(IClimber model)
        {
            _climbers.Add(model);
        }

        public IClimber Get(string name)
        {
            return _climbers.FirstOrDefault(x => x.Name == name);
        }
    }
}
