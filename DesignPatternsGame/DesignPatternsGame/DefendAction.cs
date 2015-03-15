using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class DefendAction : Action
    {
        public DefendAction() : base("Defend") { }

        public override void execute()
        {
            //see subtractHP in GameCharacter
        }

        public override String toString()
        {
            return Primary.Name + " defends";
        }
    }
}
