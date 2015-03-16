using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class DinosaurSpecial : SpecialAction
    {
        public DinosaurSpecial() : base("Meteor") { }

        public override void execute()
        {
            dmg = target.HP - 5;
            target.subtractHP(dmg);
            primary.subtractHP(primary.TotalHP);
        }
        public override String toString()
        {
            return primary.Name + " was hit by a meteor! " + target.Name + " almost went extinct!";
        }
    }
}
