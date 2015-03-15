using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class ExtraStrengthSpecial : SpecialAction
    {
        public ExtraStrengthSpecial() : base("Strong Attack") { }
        public override void execute()
        {
            dmg = new Random().Next(primary.MaxDamage, primary.MaxDamage * 5);
            target.subtractHP(dmg);
        }

        public override string toString()
        {
            return primary.Name + " gained extra strength and attacked " + target.Name + " for " + dmg + " damage!";
        }
    }
}
