using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public abstract class SpecialAction: Action
    {
        public SpecialAction(String name) : base(name) { }

        protected int dmg;
        protected int hpUp;

        public abstract override void execute();
        public abstract override String toString();
    }
}
