using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class LionSpecial : SpecialAction
    {
        public LionSpecial() : base("FURY SWIPES") { }

        int hits;

        public override void execute()
        {
            Random rand = new Random();
            hits = rand.Next(2, 6);
            dmg = 0;
            for (int i = 0; i < hits; i ++ )
            {
                dmg += rand.Next(primary.MinDamage/2, primary.MaxDamage /2);
            }
            target.subtractHP(dmg);
        }
        public override String toString()
        {
            return primary.Name.ToUpper() + " used FURY SWIPES! hit " + hits + " time(s)!  " + target.Name + " took " + dmg + " damage!";
        }
    }
}
