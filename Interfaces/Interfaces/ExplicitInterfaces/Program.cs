using ExplicitInterfaces.Interfaces;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[2]), tokens[1]);

                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
