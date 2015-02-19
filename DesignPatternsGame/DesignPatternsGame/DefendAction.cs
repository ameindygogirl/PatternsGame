using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class DefendAction: Action
    {
        public override void execute()
        {
            //Primary.Defends = true;
        }

        public override String ToString()
        {
            return Primary.Name + " defends";
        }
    }
}
