using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak
{
    using HighwayToPeak.Core;
    using HighwayToPeak.Core.Contracts;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();


           // IController controller = new Controller();

            //IPeak musala = new Peak("Musala", 2975, "Moderate");
            //IPeak everest = new Peak("Everest", 8848, "Extreme");

            //controller.AddPeak("Musala", 2975, "Moderate");
            //controller.AddPeak("Musala", 2975, "Moderate");
            //controller.AddPeak("Everest", 8848, "Extreme");


            //OxygenClimber pesho = new OxygenClimber("Pesho");
            //NaturalClimber ivan = new NaturalClimber("Ivan");

            //controller.NewClimberAtCamp("Pesho", false);
            //controller.NewClimberAtCamp("Ivan", true);

            //controller.AttackPeak("Pesho", "Musala");

            //IRepository<IClimber> climberRepository = new ClimberRepository();


            //climberRepository.Add(pesho);
            //climberRepository.Add(ivan);

            //var allClimbers = climberRepository.All;
            //Console.WriteLine(pesho);
        }
    }
}