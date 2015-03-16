using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class DeathSpecial : SpecialAction
    {
        public DeathSpecial() : base("Death") { }

        public override void execute()
        {
            target.subtractHP(target.HP);
        }

        public override string toString()
        {
            return primary.Name + " does the unspeakable...";
        }
    }
}
