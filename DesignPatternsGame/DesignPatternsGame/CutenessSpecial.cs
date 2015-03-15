using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class CutenessSpecial : SpecialAction
    {
        public CutenessSpecial() : base("Cuteness") { }

        public override void execute()
        {
            dmg = new Random().Next(primary.MaxDamage, primary.MaxDamage * 3);
            target.HP = target.HP - dmg;
        }

        public override string toString()
        {
            return primary.Name + " overwhelms " + target.Name + " with cuteness for " + dmg + " damage!";
        }
    }
}
