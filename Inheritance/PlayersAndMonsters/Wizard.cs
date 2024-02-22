using System;

namespace PlayersAndMonsters
{
    public class Wizard : Hero
    {
        public Wizard(string username, int level) : base(username, level)
        {
        }

        public virtual void CastSpell()
        {
            Console.WriteLine($"The {this.GetType().Name} casted a spell with power 10");
        }
    }
}
