using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class RobotDecorator : GameCharacter
    {
        GameCharacter pilot;

        public RobotDecorator(GameCharacter pilot) : base()
        {
            this.pilot = pilot;
        }

        public override ItemList getItems()
        {
            return this.pilot.getItems();
        }

        public override void useSpecial(GameCharacter target)
        {
            this.pilot.useSpecial(target);
        }

    }
}
