using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public class Peak : IPeak
    {
        private string _name;
        private int _elevation;

        public Peak(string name, int elevation, string difficultyLevel)
        {
            Name = name;
            Elevation = elevation;
            DifficultyLevel = difficultyLevel;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);
                }
                _name = value;
            }
        }

        public int Elevation
        {
            get => _elevation;
            private set
            {   
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.PeakElevationNegative);
                }
                _elevation = value;
            }

        }

        public string DifficultyLevel { get; }

        public override string ToString()
        {
            return $"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}";
        }
    }
}
