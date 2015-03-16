using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class SharkSpecial : SpecialAction
    {
        public SharkSpecial() : base("Chomp") { }

        public override void execute()
        {
            
            dmg = new Random().Next(primary.MinDamage/2, primary.MaxDamage * 2);
            
            target.subtractHP(dmg);
        }
        public override String toString()
        {
            return primary.Name + " took a bite out of " + target.Name + " for " + dmg + " damage!";
        }
    }
}
