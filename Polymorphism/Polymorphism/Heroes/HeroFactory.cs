using Heroes.Models;

namespace Heroes
{
    public class HeroFactory
    {
        public BaseHero CreateHero(string type, string name)
        {
            return type switch
            {
                "Druid" => new Druid(name),
                "Paladin" => new Paladin(name),
                "Rogue" => new Rogue(name),
                "Warrior" => new Warrior(name),
                _ => throw new NotImplementedException()
            };
        }
    }
}
