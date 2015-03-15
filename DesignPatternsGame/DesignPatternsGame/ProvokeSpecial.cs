using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class ProvokeSpecial : SpecialAction
    {
        public ProvokeSpecial() : base("Provoke") { }

        public override void execute()
        {
            // see enemy.chooseAction()
        }
        public override String toString()
        {
            return primary.Name + " tells the monsters to go suck an egg!";
        }
    }
}
