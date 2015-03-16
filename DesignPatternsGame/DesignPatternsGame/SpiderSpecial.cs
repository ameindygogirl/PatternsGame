using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class SpiderSpecial : SpecialAction
    {

        public SpiderSpecial() : base("Cobweb") { }


        public override void execute()
        {
            Random rand = new Random();
            
            dmg += rand.Next(primary.MinDamage, primary.MaxDamage * (3/2));
            
            target.subtractHP(dmg);
        }
        public override String toString()
        {
            return primary.Name + " spun his web in a doorway! "  + target.Name + " walked into the cobweb and took " + dmg + " damage.  EW!!";
        }
    }
}
