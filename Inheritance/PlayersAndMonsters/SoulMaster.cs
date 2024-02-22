using System;

namespace PlayersAndMonsters
{
    public class SoulMaster : DarkWizard
    {
        public SoulMaster(string username, int level) : base(username, level)
        {
        }

        public override void CastSpell()
        {
            Console.WriteLine($"The {this.GetType().Name} casted a spell with power 9999");
        }
    }
}
