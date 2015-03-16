using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class SnakeSpecial : SpecialAction
    {
        public SnakeSpecial() : base("Venom") { }

        public override void execute()
        {
            dmg = 5* (new Random().Next(5) + 1);
            target.subtractHP(dmg);
        }

        public override String toString()
        {
            return primary.Name + " spits venom at " + target.Name + " for " + dmg + " damage!";
        }
    }
}
