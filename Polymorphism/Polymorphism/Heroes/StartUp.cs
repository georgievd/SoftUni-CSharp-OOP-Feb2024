using Heroes.Models;

namespace Heroes
{
    public class StartUp
    {
        static void Main()
        {
            List<BaseHero> list = new();

            int heroCount = int.Parse(Console.ReadLine());

            HeroFactory heroFactory = new HeroFactory();

            while (list.Count < heroCount)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                try
                {
                    list.Add(heroFactory.CreateHero(heroType, heroName));
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Invalid hero!");
                }

                foreach (var hero in list)
                {
                    Console.WriteLine($"{hero.CastAbility()}");
                }

                int result = list.Sum(h => h.Power);
                int bossPower = int.Parse(Console.ReadLine());

                Console.WriteLine(result >= bossPower ? "Victory!" : "Defeat...");
            }
        }
    }
}