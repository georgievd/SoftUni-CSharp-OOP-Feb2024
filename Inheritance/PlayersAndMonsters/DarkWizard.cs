using System;

namespace PlayersAndMonsters
{
    public class DarkWizard : Wizard
    {
        public DarkWizard(string username, int level) : base(username, level)
        {
        }

        public override void CastSpell()
        {
            Console.WriteLine($"The {this.GetType().Name} casted a spell with power 100");
        }
    }
}
