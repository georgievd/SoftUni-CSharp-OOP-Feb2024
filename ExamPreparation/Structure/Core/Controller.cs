using System.Text;
using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private IRepository<IPeak> _peaksRepository;
        private IRepository<IClimber> _climbersRepository;
        private IBaseCamp _baseCamp;

        public Controller()
        {
            _peaksRepository = new PeakRepository();
            _climbersRepository = new ClimberRepository();
            _baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (_peaksRepository.Get(name) is not null)
            {
                return $"{name} is already added as a valid mountain destination.";
            }

            if (difficultyLevel is not ("Extreme" or "Hard" or "Moderate"))
            {
                return $"{difficultyLevel} peaks are not allowed for international climbers.";
            }

            IPeak newPeak = new Peak(name, elevation, difficultyLevel);
            _peaksRepository.Add(newPeak);
            return
                $"{name} is allowed for international climbing. See details in {_peaksRepository.GetType().Name}.";
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (_climbersRepository.Get(name) is not null)
            {
                return $"{name} is a participant in {_climbersRepository.GetType().Name} and cannot be duplicated.";
            }

            IClimber newClimber;
            if (isOxygenUsed)
            {
                newClimber = new OxygenClimber(name);
            }
            else
            {
                newClimber = new NaturalClimber(name);
            }

            _climbersRepository.Add(newClimber);
            _baseCamp.ArriveAtCamp(name);
            return $"{name} has arrived at the BaseCamp and will wait for the best conditions.";
        }

        public string AttackPeak(string climberName, string peakName)
        {
            IClimber currentClimber;
            IPeak currentPeak;

            if ((currentClimber = _climbersRepository.Get(climberName)) == null)
            {
                return $"Climber - {climberName}, has not arrived at the BaseCamp yet.";
            }

            if ((currentPeak = _peaksRepository.Get(peakName)) == null)
            {
                return $"{peakName} is not allowed for international climbing.";
            }

            if (_baseCamp.Residents.Contains(climberName) == false)
            {
                return $"{climberName} not found for gearing and instructions. The attack of {peakName} will be postponed.";
            }

            if (currentClimber.GetType().Name == "NaturalClimber"
                && currentPeak.DifficultyLevel == "Extreme")
            {
                return $"{climberName} does not cover the requirements for climbing {peakName}.";
            }

            _baseCamp.LeaveCamp(climberName);
            currentClimber.Climb(currentPeak);
            if (currentClimber.Stamina == 0)
            {
                return $"{climberName} did not return to BaseCamp.";
            }

            _baseCamp.ArriveAtCamp(currentClimber.Name);
            return $"{climberName} successfully conquered {peakName} and returned to BaseCamp.";
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (_baseCamp.Residents.Contains(climberName) == false)
            {
                return $"{climberName} not found at the BaseCamp.";
            }

            IClimber climber = _climbersRepository.Get(climberName);

            if (climber.Stamina == 10)
            {
                return $"{climberName} has no need of recovery.";
            }
            climber.Rest(daysToRecover);
            return $"{climberName} has been recovering for {daysToRecover} days" +
                   $" and is ready to attack the mountain.";
        }

        public string BaseCampReport()
        {
            if (_baseCamp.Residents.Count == 0)
            {
                return "BaseCamp is currently empty.";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BaseCamp residents:");
            foreach (var resident in _baseCamp.Residents)
            {
                var currentResident = _climbersRepository
                    .All.FirstOrDefault(c => c.Name == resident);

                if (currentResident != null)
                {
                    sb.AppendLine($"Name: {currentResident.Name}," +
                                  $" Stamina: {currentResident.Stamina}, " +
                                  $"Count of Conquered Peaks: {currentResident.ConqueredPeaks.Count}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");
            var sortedClimbers = _climbersRepository.All
                .OrderByDescending(c => c.ConqueredPeaks.Count)
                .ThenBy(c => c.Name);

            foreach (var climber in sortedClimbers)
            {
                sb.AppendLine(climber.ToString());

                // Option 1
                //List<IPeak> listOfPeaks = new List<IPeak>();
                //foreach (var peakName in climber.ConqueredPeaks)
                //{
                //    var peak = _peaksRepository.Get(peakName);
                //    listOfPeaks.Add(peak);
                //}

                // Option 2
                List<IPeak> listOfPeaks = climber.ConqueredPeaks
                    .Select(peakName => _peaksRepository.Get(peakName))
                    .OrderByDescending(p => p.Elevation)
                    .ToList();

                foreach (var peak in listOfPeaks)
                {
                    sb.AppendLine(peak.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
