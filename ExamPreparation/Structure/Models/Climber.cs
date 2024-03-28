using System.Text;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string _name;
        private int _stamina;
        private HashSet<string> _peaksConquered;

        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            _peaksConquered = new();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }
                _name = value;
            }

        }

        public int Stamina
        {
            get => _stamina;
            protected set
            {
                if (value > 10)
                {
                    _stamina = 10;
                }
                else if (value < 0)
                {
                    _stamina = 0;
                }
                else
                {
                    _stamina = value;
                }
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => _peaksConquered;

        public void Climb(IPeak peak)
        {
            _peaksConquered.Add(peak.Name);
            if (peak.DifficultyLevel == "Extreme")
            {
                Stamina -= 6;
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                Stamina -= 4;
            }
            else if(peak.DifficultyLevel == "Moderate")
            {
                Stamina -= 2;
            }
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            if (_peaksConquered.Count == 0)
            {
                sb.AppendLine("Peaks conquered: no peaks conquered");
            }
            else
            {
                sb.AppendLine($"Peaks conquered: {this._peaksConquered.Count}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
