using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class SpecialAction: Action
    {
        public override void execute()
        {
            chooseTarget();
            Primary.useSpecial(Target);
        }
    }
}
