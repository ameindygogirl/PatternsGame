using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public abstract class Hero: GameCharacter
    {
        public override abstract void useSpecial(GameCharacter target);
        public bool isHero() { return true; }
    }
}
