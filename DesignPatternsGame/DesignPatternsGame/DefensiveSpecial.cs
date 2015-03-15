using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    abstract class DefensiveSpecial: SpecialAction
    {
        public DefensiveSpecial(String name) : base(name) { }
        public abstract override void execute();
        public abstract override String toString();
    }
}