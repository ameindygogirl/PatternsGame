using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class CharmingPurrSpecial : SpecialAction
    {
        public CharmingPurrSpecial() : base("Charming Purr") { }

        public override void execute()
        {
            Random rand = new Random();
            dmg = rand.Next(primary.MinDamage, primary.MaxDamage);
            dmg += rand.Next(primary.MinDamage, primary.MaxDamage);
            
            target.subtractHP(dmg);
        }
        public override String toString()
        {
            return primary.Name + " tricked " + target.Name + " into thinking she wanted to be petted!  Scratched " + target.Name + " for " + dmg + " damage!";
        }

    }
}
