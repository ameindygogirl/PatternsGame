using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class FireBallSpecial : SpecialAction
    {
        public override void execute()
        {
            dmg = new Random().Next(primary.MaxDamage, primary.MaxDamage * 2);
            target.HP = target.HP - dmg;
        }
        public override String toString()
        {
            return primary.Name + " hurls a fireball at " + target.Name + " for " + dmg + "dmg!";
        }
    }
}
