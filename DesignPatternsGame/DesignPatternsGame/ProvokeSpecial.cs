using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class ProvokeSpecial : DefensiveSpecial
    {
        public ProvokeSpecial() : base("Provoke") { }

        public override void execute()
        {
            // see pickTarget() in Monster class
        }
        public override String toString()
        {
            return primary.Name + " tells the monsters to go suck an egg!";
        }
    }
}
