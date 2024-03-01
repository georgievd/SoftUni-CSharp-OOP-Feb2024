using BorderControl.Models;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Models.BorderControl borderControl = new();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {

                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2) // We have a robot!
                {
                    Robot robot = new(tokens[1], tokens[0]);
                    borderControl.AddEntityForBorderCheck(robot);
                }
                else
                {
                    Citizen citizen = new Citizen(tokens[2], int.Parse(tokens[1]), tokens[0]);
                    borderControl.AddEntityForBorderCheck(citizen);
                }
            }
            string fakeIdEndSequence = Console.ReadLine();
            var detained = borderControl.EntitiesToBeChecked
                .Where(e => e.Id.EndsWith(fakeIdEndSequence));

            foreach (var baseEntity in detained)
            {
                Console.WriteLine(baseEntity.Id);
            }
        }
    }
}
